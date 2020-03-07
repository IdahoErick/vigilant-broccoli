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
    public partial class SSISLogForm : BaseForm
    {
        public SSISLogForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, int ILRunID, Int64 ssisRunID, DateTime calenderDate)
        {
            InitializeComponent();
            Init(eNV, bU, period, ILRunID, ssisRunID, calenderDate);
        }
        public SSISLogForm()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            string cs = Utility.GetConnectionString(ENV, BU, Period, false);
            string query = SQLQueries.SQL_LATEST_SSIS_MESSAGES.Replace("<RunID>", SsisRunID.ToString());
            //if (_sortAsc == false)
            //    query += " order by LogId desc";
            try
            {
                DataSet dsSSISLog = SqlDA.GetQueryDataSet(cs, query, false);
                dgvSSISLog.DataSource = dsSSISLog.Tables[0];
                dgvSSISLog.Refresh();
                // Show last refresh in toolstripstatuslabel
                toolStripStatusLabel1.Text = "Last Refreshed: " + DateTime.Now.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
