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
    public partial class LogBoekForm : Form
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private Boolean _sortAsc = true;

        public LogBoekForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

            Refresh();

        }
        public override void Refresh()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false);
            string query = (_bU == Utility.BU.ILVB ? SQLQueries.SQL_LOGBOEK_ILH : SQLQueries.SQL_LOGBOEK_ILSB);
            if (_sortAsc == false)
                query += " order by LogId desc";
            try
            {
                DataSet dsLogboek = _sqlDA.GetQueryDataSet(cs, query, false);
                dgvLogBoek.DataSource = dsLogboek.Tables[0];
                dgvLogBoek.Refresh();
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
    }
}
