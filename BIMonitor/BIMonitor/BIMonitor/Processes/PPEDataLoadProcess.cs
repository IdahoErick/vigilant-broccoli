using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class PPEDataLoadProcess : BaseProcess
    {
        private BIFramework.OracleDBAccess oDA = new BIFramework.OracleDBAccess();

        internal override String ProcessName
        {
            get
            {
                return "PPE Data Load";
            }
        }
        internal DataSet GetLatestDataLoads()
        {
            DataSet ds = oDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.ORA_INFREP_DEV, SQLQueries.ORA_WF_PPE_DATALOAD_Latest, false);

            // set process status
            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Columns["STATUS"] != null))
                SetWorkflowStatus(ds.Tables[0].Rows[0]["STATUS"].ToString());
            else if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count == 0))
                Status = ProcessStatus.Success;
            else
                Status = ProcessStatus.Failed;
            return ds;
        }
    }
}
