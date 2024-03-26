using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace DIMonitor
{
    class OwnVisitor : TSqlFragmentVisitor
    {
        private string _sourceDB = "";
        private string _sourceSchema = "";
        private string _sourceTable = "";
        private string _sourceColumn = "";
        private string _targetSchema = "";
        private string _targetTable = "";
        private string _targetColumn = "";
        //private string _sourceTableAlias = "";

        private DataTable _dtMappingLines;

        private class TableAlias
        {
            public string sourceDB;
            public string schemaName;
            public string tableName;
            public string aliasName;
        }

        public string SourceTable { get => _sourceTable; set => _sourceTable = value; }
        public string SourceSchema { get => _sourceSchema; set => _sourceSchema = value; }
        public DataTable DtMappingLines { get => _dtMappingLines; set => _dtMappingLines = value; }
        public string TargetTable { get => _targetTable; set => _targetTable = value; }
        public string TargetSchema { get => _targetSchema; set => _targetSchema = value; }


        public override void ExplicitVisit(SelectStatement node)
        {
            // Set up mapping datatable if it does not exist yet
            if (_dtMappingLines == null)
                _dtMappingLines = CreateMappingTable();

            List<TableAlias> tableAliases = new List<TableAlias>(); ;

            QuerySpecification querySpecification = node.QueryExpression as QuerySpecification;

            string sqlString = node.ToSqlString();

            if ((!sqlString.Contains("@UpdateDate")) && (!sqlString.Contains("@SourceCount")) && (!sqlString.Contains("@DestCount")) && (!sqlString.Contains("SELECT @LastUpdateDate")))
            {
                FromClause fromClause = querySpecification.FromClause;
                // There could be more than one TableReference!
                // TableReference is not sure to be a NamedTableReference, could be as example a QueryDerivedTable
                NamedTableReference namedTableReference = fromClause.TableReferences[0] as NamedTableReference;
                TableReferenceWithAlias tableReferenceWithAlias = fromClause.TableReferences[0] as TableReferenceWithAlias;

                JoinParenthesisTableReference joinParenthesisTableReference = fromClause.TableReferences[0] as JoinParenthesisTableReference;
                JoinTableReference joinTableReference = fromClause.TableReferences[0] as JoinTableReference;
                OdbcQualifiedJoinTableReference odbcQualifiedJoinTableReference = fromClause.TableReferences[0] as OdbcQualifiedJoinTableReference;


                if ((namedTableReference != null) && (tableReferenceWithAlias != null))
                {
                    _sourceTable = namedTableReference?.SchemaObject.BaseIdentifier?.Value;
                    _sourceSchema = namedTableReference?.SchemaObject.SchemaIdentifier?.Value;
                    _sourceDB = namedTableReference?.SchemaObject.DatabaseIdentifier?.Value;
                    string serverIdentifier = namedTableReference?.SchemaObject.ServerIdentifier?.Value;
                    string alias = tableReferenceWithAlias.Alias?.Value;
                    Console.WriteLine("From:");
                    Console.WriteLine($"  {"Server:",-10} {serverIdentifier}");
                    Console.WriteLine($"  {"Database:",-10} {_sourceDB}");
                    Console.WriteLine($"  {"Schema:",-10} {_sourceSchema}");
                    Console.WriteLine($"  {"Table:",-10} {_sourceTable}");
                    Console.WriteLine($"  {"Alias:",-10} {alias}");
                }
                else if (joinTableReference != null)
                {
                    // Split the string into join clauses
                    string[] separators = new string[] { "LEFT OUTER JOIN", "INNER JOIN", "RIGHT OUTER JOIN", "LEFT JOIN", "RIGHT JOIN", "JOIN" };
                    string[] joinClauses = joinTableReference.ToSqlString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    // Loop through join clauses
                    int i = 0;
                    int length = 0;
                    foreach (string joinClause in joinClauses)
                    {
                        TableAlias tableAlias = new TableAlias();

                        string fullSourceTable = joinClause.TrimStart(new char[]{'\n', '\r'});
                        fullSourceTable = fullSourceTable.Replace('\r', ' ');   // Replace any Carriage Return characters to spaces to allow detection of aliases
                        //_sourceTable = joinTableReference.FirstTableReference.ToSqlString();

                        int indexOfFirstPeriod = NthIndexOf(fullSourceTable, ".", 1);
                        int indexOfSecondPeriod = NthIndexOf(fullSourceTable, ".", 2);

                        // determine source database
                        if (indexOfFirstPeriod > 0)
                            tableAlias.sourceDB = fullSourceTable.Substring(0, indexOfFirstPeriod);

                        // determine source schema
                        if (indexOfSecondPeriod > 0)
                            tableAlias.schemaName = fullSourceTable.Substring(indexOfFirstPeriod + 1, indexOfSecondPeriod - indexOfFirstPeriod - 1);
                        else if (indexOfFirstPeriod > 0)
                            tableAlias.schemaName = fullSourceTable.Substring(0, indexOfFirstPeriod - 1);

                        // Determine source table
                        int sourceTableIndex = (indexOfSecondPeriod > 0 ? indexOfSecondPeriod : (indexOfFirstPeriod > 0 ? indexOfFirstPeriod : 1));
                        length = fullSourceTable.IndexOf(" ") - sourceTableIndex - 1;
                        if (length > 0)
                            tableAlias.tableName = fullSourceTable.Substring(sourceTableIndex + 1, length);
                        else
                            tableAlias.tableName = fullSourceTable;

                        // Determine source table alias
                        int firstSpaceIndex = NthIndexOf(fullSourceTable, " ", 1);
                        int secondSpaceIndex = NthIndexOf(fullSourceTable, " ", 2);
                        if (secondSpaceIndex == -1)
                            secondSpaceIndex = fullSourceTable.Length + 1;
                        int thirdSpaceIndex = NthIndexOf(fullSourceTable, " ", 3);
                        if (thirdSpaceIndex == -1)
                            thirdSpaceIndex = fullSourceTable.Length + 1;
                        int firstAsIndex = NthIndexOf(fullSourceTable, " AS ", 1);

                        length = thirdSpaceIndex - firstAsIndex - 4;
                        if (length > 0)
                            tableAlias.aliasName = fullSourceTable.Substring(firstAsIndex + 4, thirdSpaceIndex - firstAsIndex - 4);
                        else
                            tableAlias.aliasName = fullSourceTable;
                        tableAliases.Add(tableAlias);

                        i++;
                    };
                }
                // Loop through select columns
                foreach (SelectElement column in querySpecification.SelectElements)
                {
                    DataRow mdr = _dtMappingLines.NewRow();
                    if (column is SelectScalarExpression)
                    {
                        var expression = (column as SelectScalarExpression).Expression;
                        if (expression is ColumnReferenceExpression)
                        {
                            var columnExpression = expression as ColumnReferenceExpression;
                            //var columnName = columnExpression.MultiPartIdentifier.Identifiers.First().Value;
                            var columnName = columnExpression.MultiPartIdentifier.Identifiers.Last().Value;
                            // You can validate or process the extracted column name here
                            Console.WriteLine($"Column name: {columnName}");
                            _sourceColumn = columnName;
                            // Determine alias and look up alias in table aliases list
                            var aliasName = columnExpression.MultiPartIdentifier.Identifiers.First().Value;
                            TableAlias ta = tableAliases.Find(alias => alias.aliasName == aliasName);
                            if (ta != null)
                            {
                                _sourceDB = ta.sourceDB;
                                _sourceTable = ta.tableName;
                                _sourceSchema = ta.schemaName;
                            }
                        }
                        else
                        {
                            _sourceColumn = column.ToSqlString();
                            // Extract source field from COALESCE if present
                            string functionCall = column.ToSourceSqlString();
                            if (column.ToSqlString().ToUpper().IndexOf(" AS ") > 0)
                                functionCall = column.ToSqlString().Substring(0, column.ToSqlString().IndexOf(" AS "));
                            string pattern = "";
                            if (functionCall.Contains("."))
                                pattern = @"(?i)(?<=COALESCE(?:\s*)\()(\w+)(?=\s*)(?:\.)?(\w+)";
                            else
                                pattern = @"(?i)(?<=COALESCE(?:\s*)\()(\w+)(?=\s*)(?:\.)?(\w+)";

                            Match match = Regex.Match(functionCall, pattern);
                            if (match.Success)
                            {
                                if (match.Groups.Count > 2)
                                {
                                    if (functionCall.Contains("."))
                                    {    // column name with alias
                                        var aliasName = match.Groups[1].Value;
                                        _sourceColumn = match.Groups[2].Value;
                                        TableAlias ta = tableAliases.Find(alias => alias.aliasName == aliasName);
                                        if (ta != null)
                                        {
                                            _sourceDB = ta.sourceDB;
                                            _sourceTable = ta.tableName;
                                            _sourceSchema = ta.schemaName;
                                        }
                                    }
                                    else
                                    {   // column name without alias
                                        _sourceColumn = match.Value;
                                    }
                                }
                                else
                                {
                                    _sourceColumn = match.Groups[1].Value;
                                }
                            }
                        }
                    }
                    else
                    {
                        _sourceColumn = column.ToSqlString();
                    }
                    var asIndex = column.ToSqlString().ToUpper().IndexOf(" AS ");
                    if (asIndex > 0)
                        _targetColumn = column.ToSqlString().Substring(asIndex + 4);
                    else
                        _targetColumn = _sourceColumn;

                    // Add row to mapping datatable if row is not a dummy fact ID row
                    string transformation = column.ToSqlString();
                    if ((_targetTable.Substring(0, 4).ToUpper() != "FACT") || (transformation.Substring(0, 5).ToUpper() != "0 AS ") || (transformation.Substring(transformation.Length-2).ToUpper() != "ID"))
                    {
                        mdr["LineText"] = column.ToSourceSqlString();
                        mdr["SourceDB"] = _sourceDB;
                        mdr["SourceSchema"] = _sourceSchema;
                        mdr["SourceTable"] = _sourceTable;
                        mdr["SourceColumn"] = _sourceColumn;
                        mdr["TargetTable"] = _targetTable;
                        //mdr[4] = targetField.Trim().TrimEnd(']').TrimStart('[');
                        mdr["Transformation"] = transformation;
                        mdr["SourceDataType"] = ""; // todo
                        mdr["TargetSchema"] = _targetSchema; // todo
                        mdr["TargetTable"] = _targetTable; // todo
                        mdr["TargetColumn"] = _targetColumn;

                        _dtMappingLines.Rows.Add(mdr);
                    }
                }
            }
            // Example of changing the alias:
            //(fromClause.TableReferences[0] as NamedTableReference).Alias = new Identifier() { Value = baseIdentifier[0].ToString() };

            Console.WriteLine("Statement:");
            Console.WriteLine(node.ToSqlString().Indent(2));

            Console.WriteLine("¯".Multiply(40));

            base.ExplicitVisit(node);
        }

        private DataTable CreateMappingTable()
        {
            DataTable dtMappingLines = new DataTable();
            dtMappingLines.Columns.Add(new DataColumn("LineText"));
            dtMappingLines.Columns.Add(new DataColumn("SourceDB"));
            dtMappingLines.Columns.Add(new DataColumn("SourceSchema"));
            dtMappingLines.Columns.Add(new DataColumn("SourceTable"));
            dtMappingLines.Columns.Add(new DataColumn("SourceColumn"));
            dtMappingLines.Columns.Add(new DataColumn("SourceDataType"));
            dtMappingLines.Columns.Add(new DataColumn("PH1"));
            dtMappingLines.Columns.Add(new DataColumn("PH2"));
            dtMappingLines.Columns.Add(new DataColumn("Transformation"));
            dtMappingLines.Columns.Add(new DataColumn("PH3"));
            dtMappingLines.Columns.Add(new DataColumn("TargetSchema"));
            dtMappingLines.Columns.Add(new DataColumn("TargetTable"));
            dtMappingLines.Columns.Add(new DataColumn("TargetColumn"));

            return dtMappingLines;
        }

        private int NthIndexOf(string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n - 1].Index;
            else
                return -1;
        }
    }

    public static class TSqlDomHelpers
    {
        public static string ToSourceSqlString(this TSqlFragment fragment)
        {
            StringBuilder sqlText = new StringBuilder();
            for (int i = fragment.FirstTokenIndex; i <= fragment.LastTokenIndex; i++)
            {
                sqlText.Append(fragment.ScriptTokenStream[i].Text);
            }
            return sqlText.ToString();
        }

        public static string ToSqlString(this TSqlFragment fragment)
        {
            SqlScriptGenerator generator = new Sql120ScriptGenerator();
            string sql;
            generator.GenerateScript(fragment, out sql);
            return sql;
        }
    }
    public static class StringHelpers
    {
        public static string Indent(this string Source, int NumberOfSpaces)
        {
            string indent = new string(' ', NumberOfSpaces);
            return indent + Source.Replace("\n", "\n" + indent);
        }
        public static string Multiply(this string Source, int Multiplier)
        {
            StringBuilder stringBuilder = new StringBuilder(Multiplier * Source.Length);
            for (int i = 0; i < Multiplier; i++)
            {
                stringBuilder.Append(Source);
            }
            return stringBuilder.ToString();
        }
    }
}
