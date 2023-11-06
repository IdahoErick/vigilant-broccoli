using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIMonitor
{
    public partial class TroublehsootingForm : BaseForm
    {
         public TroublehsootingForm(Utility.ENV env, Utility.BU bu, Utility.PERIOD period, DateTime kalenderDatum, long ILRunID, Int64 ssisRunID)
        {
            InitializeComponent();

            Init(env, bu, period, (int)ILRunID, ssisRunID, kalenderDatum);
 
             // Get Failure Details
            string cs = Utility.GetConnectionString(ENV, BU, Period, false);

            DataSet dsFailureDetails = SqlDA.GetQueryDataSet(cs, SQLQueries.SQL_RUN_FAILURES.Replace("<RunID>", ILRunID.ToString()), false);
            dgvFailureDetails.DataSource = dsFailureDetails.Tables[0];
            dgvFailureDetails.Refresh();

            // Get SSIS Errors
            DataSet dsFSSISErrors = SqlDA.GetQueryDataSet(cs, SQLQueries.SQL_SSIS_ERRORS.Replace("<RunID>", SsisRunID.ToString()), false);
            dgvSSISErrors.DataSource = dsFSSISErrors.Tables[0];
            dgvSSISErrors.Refresh();
        }

        private void dgvFailureDetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dgvFailureDetails.DataSource;
            ShowPossibleILSolution(dt.Rows[e.RowIndex]);
        }
        private void ShowPossibleILSolution(DataRow dr)
        {
            SolutionFactory solFac = new SolutionFactory();
            Solution solution = solFac.FindILSolution(dr["Controletype"].ToString(), dr["Packagenaam"].ToString(), dr["opmerkingen"].ToString());
            if (solution != null)
            {
                SolutionForm solutionForm = new SolutionForm(solution.Problem, solution.SolutionQuery);
                solutionForm.Show();
            }
            else
                MessageBox.Show("No solution found");
        }
        private void ShowPossibleSSISSolution(DataRow dr)
        {
            SolutionFactory solFac = new SolutionFactory();
            Solution solution = solFac.FindSSISSolution(dr["message"].ToString(), dr["message_source_name"].ToString(), dr["execution_path"].ToString());

            if (solution != null)
            {
                SolutionForm solutionForm = new SolutionForm(solution.Problem, solution.SolutionQuery);
                solutionForm.Show();
            }
            else
                MessageBox.Show("No solution found");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                DataTable dt = (DataTable)dgvFailureDetails.DataSource;
                ShowPossibleILSolution(dt.Rows[dgvFailureDetails.CurrentRow.Index]);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
