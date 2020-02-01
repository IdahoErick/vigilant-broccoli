using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BIFramework;
using System.Collections;

namespace BIMonitor
{
    class InfaStatistics : InfaBaseProcess
    {
        internal struct InfraWorkflow
        {
            internal string folderName;
            internal string workflowName;
        };

        private BaseDBAccess _DBAccess;
        private string _connectionString;
        private BaseDBAccess.DBType _DBType;
        private ArrayList _requiredScheduledWorkflows = new ArrayList();
        private ArrayList _missingScheduledWorkflows = new ArrayList();
        private string _processName = "Informatica Statistics";
        private BIFramework.SQLDBAccess sqlDA = new BIFramework.SQLDBAccess();

        public const string NOT_SCHEDULED_LABEL = "NOT SCHEDULED";
        public const string UNSCHEDULED_LABEL = "UNSCHEDULED";
        
        internal override String ProcessName
        {
            get
            {
                return _processName;
            }
        }


        public void AddRequiredScheduledWorkflow(String folderName, String workflowName)
        {
            InfraWorkflow workflow;
            workflow.folderName = folderName;
            workflow.workflowName = workflowName;
            _requiredScheduledWorkflows.Add(workflow);
        }

        public InfaStatistics(string processName, BIFramework.BaseDBAccess.DBType DBType, string connectionString, string InfaISName, string InfaDomainName)
            : base(InfaISName, InfaDomainName)
        {
            _processName = processName;
            _DBType = DBType;
            _connectionString = connectionString;
            switch (DBType)
            {
                case BaseDBAccess.DBType.Oracle:
                    _DBAccess = new BIFramework.OracleDBAccess();
                    break;
                case BaseDBAccess.DBType.SQLServer:
                    _DBAccess = new BIFramework.SQLDBAccess();
                    break;
                default:
                    break;
            }
        }

        public DataSet GetWFPast7Days()
        {
            return _DBAccess.GetQueryDataSet(_connectionString, _DBType == BaseDBAccess.DBType.Oracle ? SQLQueries.ORA_WF_LAST7DAYS : SQLQueries.SQL_WF_LAST7DAYS, false);
        }

        public DataSet GetWFScheduled()
        {
            // Get scheduled workflows from repository
            DataSet dsScheduledWfs;
            dsScheduledWfs = _DBAccess.GetQueryDataSet(_connectionString, _DBType == BaseDBAccess.DBType.Oracle ? SQLQueries.ORA_WF_Scheduled : SQLQueries.SQL_WF_Scheduled, false);

            // Get run-time scheduled workflows from pmcmd
            ArrayList runTimeScheduledWfs = GetRunTimeScheduledWfs();
            // Get running workflows
            DataSet dsRunningWfs = GetWFRunning();

            _missingScheduledWorkflows.Clear();
            //Loop through required workflows. Add workflow to missing scheduled workflows if it is not in the list.
            foreach (InfraWorkflow wf in _requiredScheduledWorkflows)
            {
                string workflowStatus = "";
                if (dsScheduledWfs.Tables[0].Select("subj_name = '" + wf.folderName + "' and task_name = '" + wf.workflowName + "'").Length == 0)
                    workflowStatus = NOT_SCHEDULED_LABEL;
                else if ((runTimeScheduledWfs.IndexOf(wf.workflowName) == -1) && (dsRunningWfs.Tables[0].Select("name = '" + wf.workflowName + "'").Length == 0))
                    workflowStatus = UNSCHEDULED_LABEL;
                if (workflowStatus != "")
                {
                    DataRow newRow = dsScheduledWfs.Tables[0].NewRow();
                    newRow["subj_name"] = wf.folderName;
                    newRow["task_name"] = wf.workflowName;
                    newRow["startDate"] = workflowStatus;
                    dsScheduledWfs.Tables[0].Rows.InsertAt(newRow, 0);
                    _missingScheduledWorkflows.Add(wf);
                }
            }
            return dsScheduledWfs;
        }

        public DataSet GetWFRunning()
        {
            return _DBAccess.GetQueryDataSet(_connectionString, _DBType == BaseDBAccess.DBType.Oracle ? SQLQueries.ORA_WF_RUNNING : SQLQueries.SQL_WF_RUNNING, false);
        }
        internal override ProcessStatus GetCurrentStatus()
        {
            // Check web page status
            Status = (_missingScheduledWorkflows.Count == 0)? ProcessStatus.Success : ProcessStatus.Failed;

            // set Status to UserActionRequired to trigger email when status is failed and it is after 4pm
            if ((Status == ProcessStatus.Failed) && (_previousStatus == ProcessStatus.Success) && (DateTime.Now.Hour >= 16))
                Status = ProcessStatus.UserActionRequired;

            // call base function to handle notifications
            return base.GetCurrentStatus();
        }
    }
}
