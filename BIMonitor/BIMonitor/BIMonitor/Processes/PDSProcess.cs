using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BIMonitor
{
    class PDSProcess : InfaBaseProcess
    {
        private BIFramework.SQLDBAccess _SQLAccess = new BIFramework.SQLDBAccess();
        private string _connectionString;
        private string _processName = "PDS Process";
        private BIFramework.SQLDBAccess sqlDA = new BIFramework.SQLDBAccess();

        public PDSProcess(string processName, string connectionString, string InfaISName, string InfaDomainName)
            : base(InfaISName, InfaDomainName)
        {
            _processName = processName;
            _connectionString = connectionString;
        }

        internal override String ProcessName
        {
            get
            {
                return _processName;
            }
        }
        internal DataSet GetLatestPDSRun()
        {
            DataSet ds = sqlDA.GetQueryDataSet(_connectionString, SQLQueries.SQL_WF_PDS_PROD_LATEST, false);

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
