using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class LoadIBIProcess : BaseProcess
    {
        private BIFramework.OracleDBAccess oDA = new BIFramework.OracleDBAccess();
        private BIFramework.SQLDBAccess sqlDA = new BIFramework.SQLDBAccess();

        internal override ProcessStatus GetCurrentStatus()
        {
            GetEDWWorkflowData();

            // call base function to handle notifications
            return base.GetCurrentStatus();
        }
        internal override String ProcessName
        {
            get
            {
                return "IBI Data Load";
            }
        }

        internal DataSet GetEDWWorkflowData()
        {
            DataSet ds = sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_EDW_LATEST, false);

            // set process status
            SetWorkflowStatus(ds.Tables[0].Rows[0]["STATUS"].ToString());

            return ds;
         }

        internal DataSet GetLatestEDWLoad()
        {
            return sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_EDW_LAST_30_DAYS, false);
        }

        internal DataSet GetLatestODSLoad()
        {
            return sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_ODS_LAST_30_DAYS, false);
        }
        internal DataSet GetEDWMetrics()
        {
            return oDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.ORA_EDW_PROD, SQLQueries.ORA_EDW_METRICS, true);
        }
        internal DataSet GetODSMetrics()
        {
            return oDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.ORA_ODS_PROD, SQLQueries.ORA_ODS_METRICS, false);
        }
        internal DataSet GetNumberC8ReportsRan()
        {
            return oDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.ORA_TOOLS_PROD, SQLQueries.ORA_TOOLS_NBR_C8_REPORTS_RAN, false);
        }
    }
}
