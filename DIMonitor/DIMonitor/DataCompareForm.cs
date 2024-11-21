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
using System.Threading.Tasks;

namespace DIMonitor
{
    public partial class DataCompareForm : DIMonitor.BaseForm
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();

        public DataCompareForm()
        {
            InitializeComponent();
        }

        private async void btnRunDataCompare_Click(object sender, EventArgs e)
        {
            Task<bool> result;
            if ((tbScriptAName.Text != "") && (tbScriptBName.Text != ""))
                result = RunDataCompareFromScriptFiles();
            else  // Run data compare in DB
                result = RunDataCompareInDB();

            await Task.WhenAll(result);
        }

        public DataCompareForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

            // Set form title
            this.Text += " - " + _eNV.ToString();

            // Set end date to one month ago
            dtmpEndDate.Value = DateTime.Today.AddMonths(-1);

            // Get available databases
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            DataSet DSAvailableDatabases = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_AVAILABLE_DATABASES, false);

            // Fill database comoboboxes
            DataTable dtSourceDBs = DSAvailableDatabases.Tables[0].Copy();
            DataTable dtTargetDBs = DSAvailableDatabases.Tables[0].Copy();

            cbSourceDB.DataSource = dtSourceDBs;
            cbSourceDB.DisplayMember = "Name";
            cbSourceDB.ValueMember = "Name";
            //cbSourceDB.SelectedText = "IDS_Qlik";
            cbSourceDB.SelectedIndex = cbSourceDB.FindString("IDS_Qlik");
            cbSourceDB.Refresh();

            cbTargetDB.DataSource = dtTargetDBs;
            cbTargetDB.DisplayMember = "Name";
            cbTargetDB.ValueMember = "Name";
            //cbTargetDB.SelectedText = "IDSConsolidated";
            cbTargetDB.SelectedIndex = cbTargetDB.FindString("IDSConsolidated");
            cbTargetDB.Refresh();

        }

        private async Task<bool> RunDataCompareInDB()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            //string runDetailStatus = cbErrors.Checked == true ? "'Invalid Count or Sum'" : "[Status]";

            //string query = LoadSQLQuery('SourceTargetComparison.sql');
            string script = File.ReadAllText(@"SourceTargetComparison.sql");

            //string query = SQLQueries.SQL_RUNDETAILLOG.Replace("<RunID>", _runID.ToString()).Replace("<RunDetailStatus>", runDetailStatus);
            try
            {
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

                toolStripStatusLabel1.Text = "Starting data compare...";

                Cursor.Current = Cursors.WaitCursor;

                // Run data compare
                DataSet DataCompareResults = _sqlDA.GetQueryDataSet(cs, script, false, parameters);

                // Show summary results
                dgvDataCompareResultsSummary.DataSource = DataCompareResults.Tables[0];
                dgvDataCompareResultsSummary.Refresh();

                // Show table level results
                dgvDataCompareResultsPerTable.DataSource = DataCompareResults.Tables[1];
                dgvDataCompareResultsPerTable.Refresh();

                // Show row level data differences
                if (cbShowDifferences.Checked)
                {
                    dgvRowLevelDataDifferences.DataSource = DataCompareResults.Tables[2];
                    dgvRowLevelDataDifferences.Refresh();
                    dgvRowLevelDataDifferences.Visible = true;
                    lblRowLevelDataDifferences.Visible = true;
                    this.Height = 1000;
                }
                else
                {
                    dgvRowLevelDataDifferences.Visible = false;
                    lblRowLevelDataDifferences.Visible = false;
                    this.Height = 600;
                }
                Cursor.Current = Cursors.Default;
                toolStripStatusLabel1.Text = "Data Compare Complete";
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        private async Task<bool> RunDataCompareFromScriptFiles()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);

            string fileAPath = $"{tbScriptAName.Text}";
            string fileBPath = $"{tbScriptBName.Text}";

            string queryA = File.ReadAllText(fileAPath);
            string queryB = File.ReadAllText(fileBPath);

            if (queryA == "")
                MessageBox.Show("Could not retrieve the source query from file: " + tbScriptAName.Text);
            else if (queryB == "")
                MessageBox.Show("Could not retrieve the target query from file: " + tbScriptBName.Text);
            else
            {
                try
                {
                    toolStripStatusLabel1.Text = "Starting data compare...";

                    Cursor.Current = Cursors.WaitCursor;

                    // Get results from query A and B
                    toolStripStatusLabel1.Text = "Retrieving source data set ...";
                    statusStrip1.Refresh();

                    DateTime startDTM = DateTime.Now;
                    Task<DataSet> tdsDataQueryA = GetCompareResults(5000, _sqlDA, cs, queryA);
                    await Task.WhenAll(tdsDataQueryA);

                    //DataSet dsDataQueryA = _sqlDA.GetQueryDataSet(cs, queryA, false, 5000);
                    TimeSpan queryADuration = DateTime.Now.Subtract(startDTM);

                    toolStripStatusLabel1.Text = "Retrieving target data set ...";
                    statusStrip1.Refresh();
                    startDTM = DateTime.Now;

                    Task<DataSet> tdsDataQueryB = GetCompareResults(5000, _sqlDA, cs, queryB);
                    await Task.WhenAll(tdsDataQueryB);

                    //DataSet dsDataQueryB = _sqlDA.GetQueryDataSet(cs, queryB, false, 5000);
                    TimeSpan queryBDuration = DateTime.Now.Subtract(startDTM);

                    // Compare result sets
                    toolStripStatusLabel1.Text = "Comparing results ...";
                    statusStrip1.Refresh();
                    DataTable dtResults = new DataTable();
                    int nbrDifferences = 0;
                    if ((tdsDataQueryA.Result.Tables.Count > 0) && (tdsDataQueryB.Result.Tables.Count > 0))
                    {
                        // Find all rows in set A that are not in set B or are different
                        var differences = tdsDataQueryA.Result.Tables[0].AsEnumerable().Except(tdsDataQueryB.Result.Tables[0].AsEnumerable(), DataRowComparer.Default);
                        nbrDifferences = differences.Count();

                        if (nbrDifferences > 0)
                        {
                            dtResults = differences.CopyToDataTable();
                        }

                        // Find all rows in set B that are not in set A or are different
                        differences = tdsDataQueryB.Result.Tables[0].AsEnumerable().Except(tdsDataQueryA.Result.Tables[0].AsEnumerable(), DataRowComparer.Default);
                        nbrDifferences = differences.Count();

                        if (nbrDifferences > 0)
                        {
                            dtResults.Merge(differences.CopyToDataTable());
                        }

                        // Copy results into data table
                        //using (var reader = ObjectReader.Create(differences))
                        //{
                        //    dtResults.Load(reader);
                        //}
                    }
                    else
                        MessageBox.Show("Returned dataset is empty");

                    // Show summary results
                    dgvDataCompareResultsSummary.DataSource = dtResults;
                    dgvDataCompareResultsSummary.Refresh();

                    /* Show all data */
                    // Add Source column and set appropriately
                    AddSourceField(tdsDataQueryA.Result.Tables[0], "S");
                    AddSourceField(tdsDataQueryB.Result.Tables[0], "E");

                    DataTable dtCombined = tdsDataQueryA.Result.Tables[0].Copy();
                    dtCombined.Merge(tdsDataQueryB.Result.Tables[0]);
                    if ((tbFilterField.Text != "") && (tbFilterValue.Text != ""))
                    {
                        toolStripStatusLabel1.Text = "Filtering result set ...";

                        if (cbUseLike.Checked)
                            dtCombined.DefaultView.RowFilter = $"[{tbFilterField.Text}] LIKE '%{tbFilterValue.Text}%'";
                        else
                            dtCombined.DefaultView.RowFilter = $"[{tbFilterField.Text}] = {tbFilterValue.Text}";
                    }

                    dgvDataCompareResultsPerTable.DataSource = dtCombined;

                    Cursor.Current = Cursors.Default;

                    toolStripStatusLabel1.Text = $"Data Compare complete; Source row count: {tdsDataQueryA.Result.Tables[0].Rows.Count} - Target row count {tdsDataQueryB.Result.Tables[0].Rows.Count}; Rows different: {nbrDifferences}; Source query duration: {queryADuration.ToString()}; Target query duration: {queryBDuration.ToString()}";
                    statusStrip1.Refresh();

                }
                catch (Exception e)
                {
                    //throw e;
                    MessageBox.Show(e.Message);
                }
            }
            return true;
        }

        private void AddSourceField(DataTable dt, string value)
        {
            DataColumn newColumn = new DataColumn("Source", typeof(string));
            newColumn.DefaultValue = value;

            // Add the new column to the DataTable
            dt.Columns.Add(newColumn);

            //dt.Columns.Add(new DataColumn("Source", typeof(string), value));
        }

        public void SetQueryAScript(string scriptName)
        {
            tbScriptAName.Text = scriptName;
        }
        public void SetQueryBScript(string scriptName)
        {
            tbScriptBName.Text = scriptName;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDataCompareResultsPerTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgvDataCompareResultsPerTable.Rows[e.RowIndex];
                DataTable dt = (DataTable)dgvDataCompareResultsPerTable.DataSource;
                
                if (dt.Columns.Contains("Source"))
                {
                    string source = Convert.ToString(dr.Cells["Source"].Value);

                    if (source == "E")
                    {
                        dr.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                }
            }
                /*
                int volume = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                int targetValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value); // Assuming column index 2 for Target Value

                if (volume > targetValue)
                {
                    e.CellStyle.BackColor = Color.Green; // Set green background
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red; // Set red background
                }
            }

            foreach (DataGridViewRow row in dgvDataCompareResultsPerTable.Rows)
            {
                // Assuming column indices: 1 for Volume and 2 for Target Value
                string source = Convert.ToString(row.Cells["Source"].Value);

                if (source == "E")
                {
                    row.DefaultCellStyle.BackColor = Color.Green; // Set green background
                }
            }
                */
        }
        public static async Task<DataSet> GetCompareResults(int queryTimeout, SQLDBAccess sqlDA, string cs, string sqlQuery)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(1);
                DataSet dsTableStats = sqlDA.GetQueryDataSet(cs, sqlQuery, false, queryTimeout);
                return dsTableStats;
            });
        }

    }
}
