using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class CinciSavingsTransferProcess : BaseProcess
    {
        private BIFramework.SQLDBAccess _SQLAccess = new BIFramework.SQLDBAccess();

        internal override String ProcessName
        {
            get
            {
                return "Cincinnati Savings Transfer";
            }
        }
        internal DataSet GetLatestCinciSavingsLoad()
        {
            DataSet ds = _SQLAccess.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_CINCI_SAVINGS_LATEST, false);

            // set process status
            SetWorkflowStatus(ds.Tables[0].Rows[0]["Status"].ToString());

            // set process status to failed if the last run was more than 49 hours ago.
            DateTime lastStartDate = System.DateTime.Parse(ds.Tables[0].Rows[0]["Start Time"].ToString());
            if (lastStartDate <= System.DateTime.Now.AddHours(-49))
                Status = ProcessStatus.Failed;

            return ds;
        }
    }
}
