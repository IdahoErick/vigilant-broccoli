using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.SqlServer.Management.SqlParser.Parser.ParseResult;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace DIMonitor
{
    public partial class TransformSPForm : DIMonitor.BaseForm
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private string _tableName;
        private string _schemaName;
        private string _SPText;
        private bool _SPTextRetrieved = false;

        public TransformSPForm()
        {
            InitializeComponent();
        }

        public TransformSPForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, string schemaName, string tableName)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;
            _schemaName = schemaName;
            _tableName = tableName;

            // Get stored procedure text
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, "EDWTransform");
            DataSet dsSP = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_EDW_TRANSFORM_SP.Replace("<TABLE_NAME>", _tableName).Replace("<SCHEMA_NAME>", _schemaName), false);

            // Load SP text into text box
            if (dsSP.Tables.Count > 0)
            {
                _SPText = dsSP.Tables[0].Rows[0][1].ToString();
                _SPTextRetrieved = true;
            }

            if (_SPTextRetrieved == true)
                rtbSPText.Text = _SPText;
            else
                rtbSPText.Text = "No Transformation stored procedure found!";

            // Process Stored Procedure text and display results
            ProcessStoredProcedureText();
        }
        private int ProcessStoredProcedureText()
        {
            DataTable spDT = ConvertTextToDataTable(_SPText);

            DataTable dtMappingLines = new DataTable();
            dtMappingLines.Columns.Add(new DataColumn("LineText"));
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

            //bool isMappingLine = false;
            //bool isSelectClause = false;

            TSqlParser parser = new TSql140Parser(true, SqlEngineType.Standalone);
            IList<ParseError> parseErrors;
            //TSqlFragment sqlFragment = parser.Parse(new StringReader(item.Body), out parseErrors);
            TSqlFragment sqlFragment = parser.Parse(new System.IO.StringReader(_SPText), out parseErrors);
            //sqlFragment.Accept(new OwnVisitor(ref AuditList, item.Name, item.Parameters));
            //        SQLParser.Parser.Parse("select 1 from dbo.MyTable", null, SQLParser.Enums.SQLType.TSql);

            OwnVisitor visitor = new OwnVisitor();
            visitor.TargetSchema = _schemaName;
            visitor.TargetTable = _tableName;
            sqlFragment.Accept(visitor);

            string newSourceTable = visitor.SourceTable;
            /*
                        // Loop through lines and extract useful info
                        foreach (DataRow dr in spDT.Rows)
                        {
                            string sourceDB = "";
                            string sourceSchema = "";
                            string sourceTable ="";
                            string sourceTableAlias = "";
                            string sourceField = "";
                            string targetField = "";
                            string transformation = "";
                            bool isFromClause = false;
                            bool isJoinClause = false;

                            if (dr[0].ToString().Contains("Populate temp table with rows that have been inserted"))
                                isMappingLine = true;

                            if (isMappingLine == true && dr[0].ToString().Trim().Equals(""))
                                isMappingLine = false;

                            if (isMappingLine == true)
                            {
                                string lineText = dr[0].ToString().Trim().TrimStart(',');
                                lineText = Regex.Replace(lineText, @"\s+", " "); // Replace multiple spaces with 1 space

                                if (lineText.ToUpper().Contains("SELECT ") || lineText.ToUpper() == "SELECT")
                                    isSelectClause = true;

                                if (lineText.ToUpper().Contains("INTO "))
                                    isSelectClause = false;

                                if ((isSelectClause == true) && (lineText.ToUpper().Trim() != "SELECT"))
                                {
                                    // remove SELECT
                                    int selectIndex = lineText.ToUpper().IndexOf("SELECT");
                                    if ((selectIndex >= 0) && (lineText.TrimEnd().Length > 6))
                                        lineText = lineText.Substring(selectIndex+7);
                                    transformation = lineText.TrimEnd('\n').TrimEnd(',');

                                    if (lineText.ToUpper().Contains(" AS "))
                                    {
                                        sourceField = lineText.Substring(1, lineText.ToUpper().IndexOf(" AS "));
                                        targetField = lineText.Substring(lineText.ToUpper().IndexOf(" AS ") + 4);
                                    }
                                    else if (lineText.Contains("="))
                                    {
                                        sourceField = lineText.Substring(lineText.IndexOf("=") + 1);
                                        // Extract source field from COALESCE if present
                                        //string input = "COALESCE(Description, 'Unknown'),";
                                        string pattern = @"(?i)(?<=COALESCE\()(\w+)(?=\s*,)";
                                        Match match = Regex.Match(sourceField, pattern);
                                        if (match.Success)
                                            sourceField = match.Groups[1].Value;

                                        targetField = lineText.Substring(0, lineText.IndexOf("=") - 1);
                                    }
                                    else
                                    {
                                        sourceField = lineText;
                                        targetField = lineText;
                                    }

                                    // Remove alias from source field and trailing comma
                                    sourceField = sourceField.Substring(sourceField.IndexOf(".") + 1);
                                    // Remove anything from source field after comma
                                    int commaIndex = sourceField.IndexOf(',');
                                    if (commaIndex > 0)
                                        sourceField = sourceField.Substring(0, commaIndex);

                                    // Add row to mapping datatable
                                    DataRow mdr = dtMappingLines.NewRow();
                                    mdr["LineText"] = dr[0].ToString();
            //                        mdr[1] = sourceTable.Trim();
                                    mdr["SourceColumn"] = sourceField.Trim();
                                    mdr["TargetTable"] = _tableName;
                                    mdr[4] = targetField.Trim().TrimEnd(']').TrimStart('[');
                                    mdr["Transformation"] = transformation;

                                    mdr["SourceSchema"] = ""; // todo
                                    mdr["SourceDataType"] = ""; // todo
                                    mdr["TargetSchema"] = ""; // todo
                                    dtMappingLines.Rows.Add(mdr);
                                }

                                // FROM or JOIN clauses
                                string fullSourceTable = "";
                                if (isSelectClause == false && lineText.ToUpper().Contains("FROM "))
                                {
                                    isFromClause = true;
                                    // Remove FROM
                                    fullSourceTable = lineText.Substring(lineText.ToUpper().IndexOf("FROM ") + 5);
                                }
                                else if (isSelectClause == false && lineText.ToUpper().Contains("JOIN "))
                                {
                                    isJoinClause = true;
                                    // Remove JOIN
                                    fullSourceTable = lineText.Substring(lineText.ToUpper().IndexOf("JOIN ") + 5);
                                }

                                // Parse FROM or JOIN Clause
                                if (isFromClause == true || isJoinClause == true)
                                {
                                    int indexOfFirstPeriod = NthIndexOf(fullSourceTable, ".", 1);
                                    int indexOfSecondPeriod = NthIndexOf(fullSourceTable, ".", 2);

                                    // determine source database
                                    if (indexOfFirstPeriod > 0)
                                        sourceDB = fullSourceTable.Substring(0, indexOfFirstPeriod);

                                    // determine source schema
                                    if (indexOfSecondPeriod > 0)
                                        sourceSchema = fullSourceTable.Substring(indexOfFirstPeriod + 1, indexOfSecondPeriod - indexOfFirstPeriod - 1);
                                    else if (indexOfFirstPeriod > 0)
                                        sourceSchema = fullSourceTable.Substring(0, indexOfFirstPeriod - 1);

                                    // Determine source table
                                    int sourceTableIndex = (indexOfSecondPeriod > 0 ? indexOfSecondPeriod : (indexOfFirstPeriod > 0 ? indexOfFirstPeriod : 1));
                                    sourceTable = fullSourceTable.Substring(sourceTableIndex + 1, fullSourceTable.IndexOf(" ") - sourceTableIndex - 1);

                                    // Determine source table alias
                                    int firstSpaceIndex = NthIndexOf(fullSourceTable, " ", 1);
                                    int secondSpaceIndex = NthIndexOf(fullSourceTable, " ", 2);
                                    if (secondSpaceIndex == -1)
                                        secondSpaceIndex = fullSourceTable.Length + 1;

                                    sourceTableAlias = fullSourceTable.Substring(firstSpaceIndex + 1, secondSpaceIndex - firstSpaceIndex - 1);
                                }

                                // Set source table
                                if (isFromClause == true)
                                {
                                    // update source table in every row in mapping table and get data type
                                    foreach (DataRow r in dtMappingLines.Rows)
                                    {
                                        r["SourceSchema"] = sourceSchema.Trim();
                                        r["SourceTable"] = sourceTable.Trim();

                                        // get data type
                                        r["SourceDataType"] = GetFieldDataType(sourceDB, sourceSchema, sourceTable, r["SourceColumn"].ToString());
                                    }
                                }
                            }
                        }
            */

            // update column data type in every row in mapping table
            foreach (DataRow r in visitor.DtMappingLines.Rows)
            {
                // get data type
                r["SourceDataType"] = GetFieldDataType(r["SourceDB"].ToString(), r["SourceSchema"].ToString(), r["SourceTable"].ToString(), r["SourceColumn"].ToString());
            }

            dgvMapping.DataSource = visitor.DtMappingLines;
            dgvMapping.Refresh();
            return 0;
        }

        private string GetFieldDataType(string DBName, string schemaName, string tableName, string fieldName)
        {
            string dataType = "";
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);

            try
            {
                DataSet dsDT = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_FIELD_DATA_TYPE.Replace("<DB_NAME>", DBName).Replace("<TABLE_NAME>", tableName).Replace("<SCHEMA_NAME>", schemaName).Replace("<FIELD_NAME>", fieldName), false);

                // Load SP text into text box
                if (dsDT.Tables.Count > 0)
                {
                    if (dsDT.Tables[0].Rows.Count > 0)
                        dataType = dsDT.Tables[0].Rows[0]["data_type"].ToString();
                }
            }
            catch
            {
                // ignore error messages
            }
            return dataType;
        }

        private DataTable ConvertTextToDataTable(string objectText)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("LineText"));

            foreach (string line in objectText.Split('\n'))
            {
                DataRow dr = tbl.NewRow();
                dr[0] = line;
                tbl.Rows.Add(dr);
            }
            return tbl;
        }
        private int NthIndexOf(string target, string value, int n)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?){" + n + "}");

            if (m.Success)
                return m.Groups[2].Captures[n - 1].Index;
            else
                return -1;
        }

        /*
        /// <summary>
        /// This method takes DataSet as input paramenter and it exports the same to excel
        /// </summary>
        /// <param name="ds"></param>
        private void ExportDataSetToExcel(DataSet ds)
        {
            //Creae an Excel application instance
            Excel.Application excelApp = new Excel.Application();

            //Create an Excel workbook instance and open it from the predefined location
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@"E:\Org.xlsx");

            foreach (DataTable table in ds.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.Save();
            excelWorkBook.Close();
            excelApp.Quit();
        */
    }
}

