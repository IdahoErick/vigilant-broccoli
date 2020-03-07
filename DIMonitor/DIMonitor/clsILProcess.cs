using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace DIMonitor
{
    class clsILProcess
    {
        private Utility.BU _bU;
        private Utility.ENV _eNV;
        private Utility.PERIOD _pERIOD;
        private SQLDBAccess _sqlDA = new SQLDBAccess();
        private System.Windows.Forms.Button _dashboardStatusButton;

        public clsILProcess(Utility.BU bU, Utility.ENV eNV, Utility.PERIOD pERIOD, System.Windows.Forms.Button btn)
        {
            // TODO: Complete member initialization
            this._bU = bU;
            this._eNV = eNV;
            this._pERIOD = pERIOD;
            this._dashboardStatusButton = btn;
        }

        internal void GetStatus()
        {
            string cs = Utility.GetConnectionString(_eNV, _bU, _pERIOD);
            string query = (_bU == Utility.BU.ILVB ? SQLQueries.SQL_RUN_STATUS_ILH : SQLQueries.SQL_RUN_STATUS_ILSB);

            try
            {

                DataSet dsStatus = _sqlDA.GetQueryDataSet(cs, query, false);
                string runStatus = dsStatus.Tables[0].Rows[0]["RunStatus"].ToString();
                if (runStatus == "OK")
                {
                    _dashboardStatusButton.BackColor = Color.LightGreen;
                }
                else if (runStatus == "NOK")
                {
                    _dashboardStatusButton.BackColor = Color.Red;
                }
                else
                {
                    _dashboardStatusButton.BackColor = Color.Yellow;
                }
            }
            catch(Exception)
            {
                _dashboardStatusButton.BackColor = Color.Yellow;
                throw;
            }

        }
    }
}
