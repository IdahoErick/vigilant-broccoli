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
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace DIMonitor
{
    public partial class RunHistoryStatsForm : DIMonitor.BaseForm
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _period;
        private SQLDBAccess _sqlDA = new SQLDBAccess();

        public RunHistoryStatsForm()
        {
            InitializeComponent();
        }

        public RunHistoryStatsForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period)
        {
            InitializeComponent();

            _eNV = eNV;
            _period = period;
            _bU = bU;

            // Set form title
            this.Text += " - " + _eNV.ToString();

            // Get Run History Stats
            string cs = Utility.GetConnectionString(_eNV, _bU, _period, false, "SSISFramework");
            DataSet dsRunHistoryStats = _sqlDA.GetQueryDataSet(cs, SQLQueries.SQL_GET_RUN_HISTORY_STATS, false);

            dgvResults.DataSource = dsRunHistoryStats.Tables[0];
            dgvResults.Refresh();
        }
    }
}
