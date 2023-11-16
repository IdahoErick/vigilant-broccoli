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
            RunDataCompare();
        }

        public DataCompareForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            // Set end date to one month ago
            dtmpEndDate.Value = DateTime.Today.AddMonths(-1);

            _eNV = eNV;
            _period = period;
            _bU = bU;
        }

        private void RunDataCompare()
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
                parameters.Add(new BaseDBAccess.CommandParams("<SOURCE_DB>", tbSourceDB.Text));
                parameters.Add(new BaseDBAccess.CommandParams("<TARGET_DB>", tbTargetDB.Text));

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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
