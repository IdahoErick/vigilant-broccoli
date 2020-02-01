using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class CinciDataTransferProcess : BaseProcess
    {
        private string _processName = "Cincinnati Data Transfer";
        
        private BIFramework.SQLDBAccess sqlDA = new BIFramework.SQLDBAccess();


        internal override String ProcessName
        {
            get {
                return _processName;
            }
        }
        internal DataSet GetLatestCinciDataLoad()
        {
            DataSet ds = sqlDA.GetQueryDataSet(BIFramework.AIQConnectionStrings.SQL_INFAREP86_PROD, SQLQueries.SQL_WF_CINCI_Latest, false);

            // set process status
            SetWorkflowStatus(ds.Tables[0].Rows[0]["STATUS"].ToString());
            // set process status to failed if the last run was more than 49 hours ago.
            DateTime lastStartDate = System.DateTime.Parse(ds.Tables[0].Rows[0]["Start Time"].ToString());
            if (lastStartDate <= System.DateTime.Now.AddHours(-49))
                Status = ProcessStatus.Failed;

            return ds;
        }
    }
}
