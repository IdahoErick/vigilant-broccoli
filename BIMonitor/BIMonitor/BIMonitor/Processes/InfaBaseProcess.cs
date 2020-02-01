using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace BIMonitor
{
    class InfaBaseProcess : BaseProcess
    {
        private string _InfaISName;
        private string _InfaDomainName;
//        private const string INFA_PMCMD_EXE = "C:\\Informatica\\PowerCenter8.6.1\\CMD_Utilities\\PC\\server\\bin\\pmcmd.exe";

        public InfaBaseProcess(string InfaISName, string InfaDomainName)
            : base()
        {
            _InfaISName = InfaISName;
            _InfaDomainName = InfaDomainName;
        }

        public void ScheduleWorkflow(string workflowName)
        {
            ExecuteCommandSync(AppSettings.InformaticaPmCmdPath + "  scheduleworkflow -sv " + _InfaISName + " -u " + AppSettings.InformaticaUserName + " -p " + AppSettings.InformaticaPassword + " -d " + _InfaDomainName + " " + workflowName);
        }

        // Get the run time scheduled workflows and return a list of workflows
        // To make this work, add the following entries to your environmental variables:
        // INFA_DOMAINS_FILE = C:\Informatica\PowerCenter8.6.1\domains.infa
        // INFA_HOME = C:\Informatica\PowerCenter8.6.1
        protected ArrayList GetRunTimeScheduledWfs()
        {
            string pmCmdText = AppSettings.InformaticaPmCmdPath + " getservicedetails -sv " + _InfaISName + " -u " + AppSettings.InformaticaUserName + " -p " + AppSettings.InformaticaPassword + " -d " + _InfaDomainName + " -scheduled";
            string result = ExecuteCommandSync(pmCmdText);
            ArrayList workflows = new ArrayList();

            // remove all items that do not start with "Workflow:"
            foreach (string line in result.Split('\n'))
            {
                if (line.StartsWith("Workflow:"))
                {
                    string workflowName = line.Substring(line.IndexOf('[', 0) + 1, line.IndexOf(']', 0) - line.IndexOf('[', 0) - 1);
                    workflows.Add(workflowName);
                }
            }
            return workflows;
        }
        internal void StartWorkflow(string folderName, string workflowName)
        {
            ExecuteCommandSync(AppSettings.InformaticaPmCmdPath + " startworkflow -sv " + _InfaISName + " -u " + AppSettings.InformaticaUserName + " -p " + AppSettings.InformaticaPassword + " -d " + _InfaDomainName + " -f \"" + folderName + "\" \"" + workflowName + "\"");
            // Refresh workflow list
            RefreshTabData();
        }


    }
}
