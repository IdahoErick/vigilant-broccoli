/*
 * TODO:
 * - Make source and target database configurable
 * - Allow user to specify source / target query
 * - Compare between two servers
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using FastMember;

namespace DIMonitor
{
    public partial class ReplicateStatusForm : DIMonitor.BaseForm
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private const int BATCH_SIZE = 5;


        public ReplicateStatusForm()
        {
            InitializeComponent();
        }

        private void btnRunDataCompare_Click(object sender, EventArgs e)
        {
            RunReplicateStatusCheck();
        }

        public ReplicateStatusForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

            // Set end date to one month ago
            //dtmpEndDate.Value = DateTime.Today.AddMonths(-1);

            // Get available databases
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            DataSet DSAvailableDatabases = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_AVAILABLE_CONSOLIDATION_DATABASES, false);

            // Fill database comoboboxes
            DataTable dtSourceDBs = DSAvailableDatabases.Tables[0].Copy();
            //DataTable dtTargetDBs = DSAvailableDatabases.Tables[0].Copy();

            cbSourceDB.DataSource = dtSourceDBs;
            cbSourceDB.DisplayMember = "Name";
            cbSourceDB.ValueMember = "Name";
            //cbSourceDB.SelectedText = "IDS_Qlik";
            cbSourceDB.SelectedIndex = cbSourceDB.FindString("IDSConsolidated");
            cbSourceDB.Refresh();

            //cbTargetDB.DataSource = dtTargetDBs;
            //cbTargetDB.DisplayMember = "Name";
            //cbTargetDB.ValueMember = "Name";
            //cbTargetDB.SelectedText = "IDSConsolidated";
            //cbTargetDB.SelectedIndex = cbTargetDB.FindString("IDSConsolidated");
            //cbTargetDB.Refresh();

        }

        private void RunReplicateStatusCheck()
        {
            int batchSize = System.Convert.ToInt32(tbMaxTables.Text);
            int queryTimeout = System.Convert.ToInt32(tbQueryTimeout.Text);

            //string script = File.ReadAllText(@"ReplicateStatusCheck.sql");

            //string query = SQLQueries.SQL_RUNDETAILLOG.Replace("<RunID>", _runID.ToString()).Replace("<RunDetailStatus>", runDetailStatus);
            try
            {
/*
                List<BaseDBAccess.CommandParams> parameters = new List<BaseDBAccess.CommandParams>();
                parameters.Add(new BaseDBAccess.CommandParams("<TABLE_NAME>", tbTableName.Text.Replace("<ALL>", "")));
                parameters.Add(new BaseDBAccess.CommandParams("<SCHEMA_NAME>", tbSchemaName.Text.Replace("<ALL>", "")));
                parameters.Add(new BaseDBAccess.CommandParams("<START_DATE>", dtmpStartDate.Text));
                parameters.Add(new BaseDBAccess.CommandParams("<END_DATE>", dtmpEndDate.Text));
                parameters.Add(new BaseDBAccess.CommandParams("<CHECK_INSERTS>", cbCheckInserts.Checked ? "1" : "0"));
                parameters.Add(new BaseDBAccess.CommandParams("<CHECK_UPDATES>", cbCheckUpdates.Checked ? "1" : "0"));
                parameters.Add(new BaseDBAccess.CommandParams("<CHECK_DELETES>", cbCheckDeletes.Checked ? "1" : "0"));
                parameters.Add(new BaseDBAccess.CommandParams("<RUN_SYNC_SQL>", cbShowDifferences.Checked ? "1" : "0"));
                parameters.Add(new BaseDBAccess.CommandParams("<COMPARE_TABLE_SIZE_MAX>", tbMaxTableRows.Text));
                parameters.Add(new BaseDBAccess.CommandParams("<SHOW_DIFF>", cbShowDifferences.Checked ? "1" : "0"));
                parameters.Add(new BaseDBAccess.CommandParams("<SOURCE_DB>", cbSourceDB.Text));
                parameters.Add(new BaseDBAccess.CommandParams("<TARGET_DB>", cbTargetDB.Text));
*/
                Cursor.Current = Cursors.WaitCursor;

                // Get list of tables from Consolidated database
                string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, cbSourceDB.Text);
                DataSet dsTableList = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_DATABASE_TABLES, false);
                int totalNumberOfTables = dsTableList.Tables[0].Rows.Count;

                DataTable dtResults = new DataTable();
                dtResults.Columns.Add(new DataColumn("SchemaName", typeof(string)));
                dtResults.Columns.Add(new DataColumn("TableName", typeof(string)));
                dtResults.Columns.Add(new DataColumn("OLTPRowCount", typeof(int)));
                dtResults.Columns.Add(new DataColumn("QlikRowCount", typeof(int)));
                dtResults.Columns.Add(new DataColumn("ConsolidatedRowCount", typeof(int)));
                dtResults.Columns.Add(new DataColumn("OLTPMaxDateModified", typeof(DateTime)));
                dtResults.Columns.Add(new DataColumn("QlikMaxDateModified", typeof(DateTime)));
                dtResults.Columns.Add(new DataColumn("ConsolidatedMaxDateModified", typeof(DateTime)));
                dtResults.Columns.Add(new DataColumn("RowCountDiff", typeof(int)));
                dtResults.Columns.Add(new DataColumn("MaxDateModifiedDiff", typeof(TimeSpan)));
                dgvResults.DataSource = dtResults;

                // Resize the columns to fit the headers
                foreach (DataGridViewColumn column in dgvResults.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                // Loop through tables to get row count and Max Modified datetime
                int nbrTables = 0;
                foreach (DataRow dr in dsTableList.Tables[0].Rows)
                {
                    string schemaName = dr["TABLE_SCHEMA"].ToString();
                    string tableName = dr["TABLE_NAME"].ToString();
                    string dateColumnName = dr["DateColumnName"].ToString();
                    string dateColumnString = dateColumnName != "" ? dateColumnName : "CAST('1900-01-01' AS DATETIME)";

                    Console.WriteLine($"Table name: {schemaName}.{tableName}");

                    int oltpRowCount = 0;
                    DateTime oltpMaxDateValue = new DateTime();
                    int qlikRowCount = 0;
                    DateTime qlikMaxDateValue = new DateTime();
                    int consolidatedRowCount = 0;
                    DateTime consolidatedMaxDateValue = new DateTime();

                    try
                    {
                        string baseDatabaseName = cbSourceDB.Text.Replace("Consolidated", "");

                        // get row count and max modified date from OLTP
                        string csOLTP = Utility.GetWSSOLTPConnectionString(_eNV, baseDatabaseName);
                        DataSet dsOLTPTableStats = _sqlDA.GetQueryDataSet(csOLTP, SQLQueries.SQL_GET_TABLE_STATS.Replace("<COLUMN_NAME>", dateColumnString).Replace("<TABLE_NAME>", tableName).Replace("<SCHEMA_NAME>", schemaName), false, queryTimeout);
                        if ((dsOLTPTableStats.Tables.Count > 0) && (dsOLTPTableStats.Tables[0].Rows.Count > 0))
                        {
                            oltpRowCount = (int)dsOLTPTableStats.Tables[0].Rows[0]["NbrRows"];
                            if (oltpRowCount >= 0)
                                oltpMaxDateValue = (DateTime)dsOLTPTableStats.Tables[0].Rows[0]["MaxDateModified"];
                        }

                        // get row count and max modified date from QLIK
                        string csQlik = Utility.GetConnectionString(_eNV, _bU, _period, false, baseDatabaseName + "_Qlik");
                        DataSet dsQlikTableStats = _sqlDA.GetQueryDataSet(csQlik, SQLQueries.SQL_GET_TABLE_STATS.Replace("<COLUMN_NAME>", dateColumnString).Replace("<TABLE_NAME>", tableName).Replace("<SCHEMA_NAME>", schemaName), false, queryTimeout);
                        if ((dsQlikTableStats.Tables.Count > 0) && (dsQlikTableStats.Tables[0].Rows.Count > 0))
                        {
                            qlikRowCount = (int)dsQlikTableStats.Tables[0].Rows[0]["NbrRows"];
                            if (qlikRowCount >= 0)
                                qlikMaxDateValue = (DateTime)dsQlikTableStats.Tables[0].Rows[0]["MaxDateModified"];
                        }
                        // get row count and max modified date from Consolidated DB
                        string csConsolidated = Utility.GetConnectionString(_eNV, _bU, _period, false, baseDatabaseName + "Consolidated");
                        string query = SQLQueries.SQL_GET_TABLE_STATS_CONSOLIDATED.Replace("<COLUMN_NAME>", dateColumnString).Replace("<TABLE_NAME>", tableName).Replace("<SCHEMA_NAME>", schemaName);
                        query = query.Replace("<ISDELETED_COLUMN>", baseDatabaseName == "IDS" ? "DataLoadIsDeleted" : "IsDeleted");
                        DataSet dsConsolidatedTableStats = _sqlDA.GetQueryDataSet(csConsolidated, query, false, queryTimeout);
                        if ((dsConsolidatedTableStats.Tables.Count > 0) && (dsConsolidatedTableStats.Tables[0].Rows.Count > 0))
                        {
                            consolidatedRowCount = (int)dsConsolidatedTableStats.Tables[0].Rows[0]["NbrRows"];
                            if (qlikRowCount >= 0)
                                consolidatedMaxDateValue = (DateTime)dsConsolidatedTableStats.Tables[0].Rows[0]["MaxDateModified"];
                        }
                    }
                    catch (System.Data.SqlClient.SqlException se)
                    {
                        oltpRowCount = -2;
                        Console.WriteLine("Error: " + se.InnerException);
                    }

                    // Add row to results data table
                    DataRow rdr = dtResults.NewRow();
                    rdr["SchemaName"] = schemaName;
                    rdr["TableName"] = tableName;
                    rdr["OLTPRowCount"] = oltpRowCount;
                    rdr["OLTPMaxDateModified"] = oltpMaxDateValue;
                    rdr["QlikRowCount"] = qlikRowCount;
                    rdr["QlikMaxDateModified"] = qlikMaxDateValue;
                    rdr["ConsolidatedRowCount"] = consolidatedRowCount;
                    rdr["ConsolidatedMaxDateModified"] = consolidatedMaxDateValue;
                    rdr["RowCountDiff"] = oltpRowCount - qlikRowCount;
                    rdr["MaxDateModifiedDiff"] = oltpMaxDateValue - qlikMaxDateValue;
                    dtResults.Rows.Add(rdr);

                    nbrTables++;
                    lblNbrTables.Text = nbrTables.ToString() + " / " + totalNumberOfTables.ToString();
                    lblNbrTables.Refresh();

                    // Show the last added row
                    int lastRowIndex = dgvResults.Rows.Count - 1;
                    // Select the last row
                    dgvResults.ClearSelection();
                    dgvResults.Rows[lastRowIndex].Selected = true;
                    if (lastRowIndex > 10)
                        dgvResults.FirstDisplayedScrollingRowIndex = lastRowIndex-10;

                    // Show results
                    dgvResults.Refresh();

                    // check batch size - exit for loop if max batch size has been reached
                    if (batchSize <= nbrTables)
                        break;

                };

                // Calculate Max DateModified value
                if (dtResults.Rows.Count > 0)
                {
                    int maxDiffRowCount = dtResults.AsEnumerable().Max(row => row.Field<int>("RowCountDiff"));
                    TimeSpan maxDiffDT = dtResults.AsEnumerable().Max(row => row.Field<TimeSpan>("MaxDateModifiedDiff"));
                    lblMaxRowCountDiff.Text = maxDiffRowCount.ToString();
                    lblMaxDateDiff.Text = maxDiffDT.TotalMinutes.ToString();
                }
                else
                    lblMaxDateDiff.Text = "No differences";

                /*
                                DataSet dsOLTPReplicateStatusResults = _sqlDA.GetQueryDataSet(cs, script, false);

                                // Run data compare
                                //string cs = WSSConnectionStrings.SQL_IDSDWH_PROD;
                                //DataSet dsOLTPReplicateStatusResults = _sqlDA.GetQueryDataSet(cs, script, false);

                                // Show OLTP results
                                //dgvResults.DataSource = dsOLTPReplicateStatusResults.Tables[0];
                                //dgvResults.Refresh();

                                // Show Qlik results
                                cs = Utility.GetConnectionString(_eNV, _bU, _period, false, "IDS_Qlik");
                                DataSet dsQlikReplicateStatusResults = _sqlDA.GetQueryDataSet(cs, script, false);
                                //dgvQlikResults.DataSource = dsQlikReplicateStatusResults.Tables[0];
                                //dgvQlikResults.Refresh();

                                // Compare resultsets to determine the max datemodified difference
                                if (dsOLTPReplicateStatusResults.Tables[0].Rows.Count != dsQlikReplicateStatusResults.Tables[0].Rows.Count)
                                {
                                    // Rows count is different
                                    MessageBox.Show("Can't compare the resultsets because the number of rows is different");
                                }
                                else
                                {
                                    var results = from table1 in dsOLTPReplicateStatusResults.Tables[0].AsEnumerable()
                                                  join table2 in dsQlikReplicateStatusResults.Tables[0].AsEnumerable()
                                                  on (string)table1["TableName"] equals (string)table2["TableName"]
                                                  select new
                                                  {
                                                      SchemaName = (string)table1["SchemaName"],
                                                      TableName = (string)table1["TableName"],
                                                      OLTPDateModified = (DateTime)table1["MaxModifiedDate"],
                                                      QlikDateModified = (DateTime)table2["MaxModifiedDate"],
                                                      TimeDifference = (DateTime)table1["MaxModifiedDate"] - (DateTime)table2["MaxModifiedDate"]
                                                  };
                                    // Copy results into data table
                                    DataTable dtResults = new DataTable();
                                    using (var reader = ObjectReader.Create(results))
                                    {
                                        dtResults.Load(reader);
                                    }

                                    // Show results
                                    dgvResults.DataSource = dtResults;
                                    dgvResults.Refresh();

                                    // Calculate Max DateModified value
                                    if (dtResults.Rows.Count > 0)
                                    {
                                        TimeSpan maxDiffDT = dtResults.AsEnumerable().Max(row => row.Field<TimeSpan>("TimeDifference"));
                                        lblMaxDateDiff.Text = maxDiffDT.TotalMinutes.ToString();
                                    }
                                    else
                                        lblMaxDateDiff.Text = "No differences";
                                }
                */
                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_3(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
