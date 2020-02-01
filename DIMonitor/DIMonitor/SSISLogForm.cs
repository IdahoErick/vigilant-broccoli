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
        //private Utility.BU _bU;
        //private Utility.ENV _eNV;
        //private Utility.PERIOD _period;
        //private SQLDBAccess _sqlDA = new SQLDBAccess();
        //private Boolean _sortAsc = true;
        //private Int64 _ssisRunID = 0;

        public SSISLogForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, Int64 ssisRunID)
        {
            InitializeComponent();
            Init(eNV, bU, period, ssisRunID);
        }

//            _eNV = eNV;
//            _period = period;
//            _bU = bU;
//            _ssisRunID = ssisRunID;

//            Refresh();
//        }
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
