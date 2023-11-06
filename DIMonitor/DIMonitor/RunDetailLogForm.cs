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
    public partial class RunDetailLogForm : Form
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private Boolean _sortAsc = false;
        private int _runID = 0;

        public RunDetailLogForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, int runID)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;
            _runID = runID;

            this.dgvRunDetailLog.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvRunDetailLog_RowPrePaint);

            Refresh();

        }
        public override void Refresh()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            string runDetailStatus = cbErrors.Checked == true ? "'Invalid Count or Sum'" : "[Status]";
            string query = SQLQueries.SQL_RUNDETAILLOG.Replace("<RunID>", _runID.ToString()).Replace("<RunDetailStatus>", runDetailStatus);
            if (_sortAsc == false)
                query += " order by CycleLogDetailId desc";
            try
            {
                DataSet dsRunDetailLog = _sqlDA.GetQueryDataSet(cs, query, false);
                dgvRunDetailLog.DataSource = dsRunDetailLog.Tables[0];
                dgvRunDetailLog.Refresh();
                // Show last refresh in toolstripstatuslabel
                toolStripStatusLabel1.Text = "Last Refreshed: " + DateTime.Now.ToString(); ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void switchOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _sortAsc = _sortAsc == true ? false : true;
        }

        private void dgvRunDetailLog_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvRunDetailLog.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "Invalid Count or Sum") 
            {
                dgvRunDetailLog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else if (dgvRunDetailLog.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "In Progress")
            {
                dgvRunDetailLog.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige;
            }
        }

        private void cbErrors_CheckedChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
