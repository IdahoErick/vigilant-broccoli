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

        private void btnRunDataCompare_Click(object sender, EventArgs e)
        {
            if ((tbScriptAName.Text != "") && (tbScriptBName.Text != ""))
                RunDataCompareFromScriptFiles();
            else  // Run data compare in DB
                RunDataCompareInDB();
        }

        public DataCompareForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

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

        private void RunDataCompareInDB()
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
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private void RunDataCompareFromScriptFiles()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);

            string queryA = File.ReadAllText(tbScriptAName.Text);
            string queryB = File.ReadAllText(tbScriptBName.Text);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Get results from query A and B
                DataSet dsDataQueryA = _sqlDA.GetQueryDataSet(cs, queryA, false);
                DataSet dsDataQueryB = _sqlDA.GetQueryDataSet(cs, queryB, false);

                // Compare result sets
                DataTable dtResults = new DataTable();
                if ((dsDataQueryA.Tables.Count > 0) && (dsDataQueryB.Tables.Count > 0))
                {
                    var differences = dsDataQueryA.Tables[0].AsEnumerable().Except(dsDataQueryB.Tables[0].AsEnumerable(), DataRowComparer.Default);

                    if (differences.Count() > 0)
                    {
                        dtResults = differences.CopyToDataTable();
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
                AddSourceField(dsDataQueryA.Tables[0], "S");
                AddSourceField(dsDataQueryB.Tables[0], "E");

                DataTable dtCombined = dsDataQueryA.Tables[0].Copy();
                dtCombined.Merge(dsDataQueryB.Tables[0]);
                if ((tbFilterField.Text != "") && (tbFilterValue.Text != ""))
                    dtCombined.DefaultView.RowFilter = $"[{tbFilterField.Text}] LIKE '%{tbFilterValue.Text}%'";

                dgvDataCompareResultsPerTable.DataSource = dtCombined;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                throw e;
            }

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
    }
}
