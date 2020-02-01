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
    public partial class TroublehsootingForm : Form
    {
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        Utility.ENV _env;
        Utility.BU _bu;
        Utility.PERIOD _period;
        DateTime _kalenderDatum;

        public TroublehsootingForm(Utility.ENV env, Utility.BU bu, Utility.PERIOD period, DateTime kalenderDatum)
        {
            InitializeComponent();

            _env = env;
            _bu = bu;
            _period = period;
            _kalenderDatum = kalenderDatum;

            // Get Failure Details
            string cs = Utility.GetConnectionString(_env, _bu, _period, false);

            DataSet dsFailureDetails = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_RUN_FAILURES, false);
            dgvFailureDetails.DataSource = dsFailureDetails.Tables[0];
            dgvFailureDetails.Refresh();

            // Get SSIS Errors
            DataSet dsFSSISErrors = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_SSIS_ERRORS, false);
            dgvSSISErrors.DataSource = dsFSSISErrors.Tables[0];
            dgvSSISErrors.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
