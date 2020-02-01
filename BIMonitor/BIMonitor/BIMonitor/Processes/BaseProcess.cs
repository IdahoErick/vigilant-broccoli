using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace BIMonitor
{
    class BaseProcess
    {
        internal enum ProcessStatus
        {
            Unknown,
            Success,
            Running,
            Failed,
            Waiting,
            UserActionRequired
        };
        
        protected ProcessStatus _previousStatus = ProcessStatus.Unknown;

        private ProcessStatus _processStatus = ProcessStatus.Unknown;
        private ArrayList _webPages = new ArrayList();
        private string _processName = "Unknown process";
        private BIMonitor.Properties.Settings _appSettings;
        private string _BIAdminEmail = "dwgroup@advantageiq.com";
        private string _BIAdminOncallEmail = "bioncall@advantageiq.com"; //"bioncall@advantageiq.com";
        private string _SMTPHost = "SPOMAIL.AIQ.local";
        private bool _showSummaryStatus = true;    // Show the process status on the Summary page?

        public bool ShowSummaryStatus
        {
            get { return _showSummaryStatus; }
            set { _showSummaryStatus = value; }
        }

        internal BIMonitor.Properties.Settings AppSettings
        {
            get { return _appSettings; }
            set { 
                _appSettings = value;
                _BIAdminEmail = _appSettings.BIAdminEmail;
                _BIAdminOncallEmail = _appSettings.BIAdminOncallEmail;
                _SMTPHost = _appSettings.SMTPHost;
            }
        }

        protected ProcessStatus Status {
            get
            {
                return _processStatus;
            }
            set {
                _processStatus = value;
            }
        }
        protected ArrayList WebPages
        {
            get
            {
                return _webPages;
            }
        }

        protected class WebPageMetadata
        {
            internal string webPageName;
            internal WebBrowser webBrowser;
            private ProcessStatus _status;
            internal DateTime startTime;
            internal DateTime endTime;
            internal Int32 nbrCubes;
            public ProcessStatus Status
            {
                get { return _status; }
                set { _status = value; }
            }
        };

        internal delegate System.Data.DataSet RetrieveBIMonitorData();

        internal struct DataGridRefreshMetadata
        {
            internal DataGridView dataGridView;
            internal RetrieveBIMonitorData getDataMethod;
        };

        private ArrayList _dataGridViews = new ArrayList();

        internal void AddGridView(DataGridView dgv, RetrieveBIMonitorData retrieveMethod)
        {
            DataGridRefreshMetadata dgvMetadata;
            dgvMetadata.dataGridView = dgv;
            dgvMetadata.getDataMethod = retrieveMethod;
            _dataGridViews.Add(dgvMetadata);
        }

        internal virtual ProcessStatus GetCurrentStatus()
        {
            if ((_previousStatus != BaseProcess.ProcessStatus.UserActionRequired) && (Status == BaseProcess.ProcessStatus.UserActionRequired))
                SendEmailItem(_BIAdminOncallEmail, "User action required for process " + ProcessName, "");

            //update previous status
            _previousStatus = Status;

            return Status;
        }

        internal virtual String ProcessName
        { 
            get {return _processName;}
        }

        internal virtual void RefreshTabData(){
            RefreshGridViews();
        }

        private void RefreshGridViews()
        {
            foreach (DataGridRefreshMetadata dgvMetdata in _dataGridViews)
            {
                dgvMetdata.dataGridView.DataSource = GetDataView(dgvMetdata.dataGridView.Name, dgvMetdata.getDataMethod());
            }
        }

        protected virtual DataView GetDataView(string dataGridViewName, System.Data.DataSet viewDataSet)
        {
            if (viewDataSet.Tables.Count > 0)
                return viewDataSet.Tables[0].DefaultView;
            else
                return new DataView();
        }
        
        internal string GetWorkflowStatusDescription(string statusCode)
        {
            int statusCodeID;
            string statusDescription = "Unknown";
            try
            {
                statusCodeID = Convert.ToInt16(statusCode);
                switch (statusCodeID)
                {
                    case 1:
                        statusDescription = "Success";
                        break;
                    case 3:
                        statusDescription = "Failed";
                        break;
                    case 4:
                        statusDescription = "Stopped";
                        break;
                    case 5:
                        statusDescription = "Aborted";
                        break;
                    case 6:
                        statusDescription = "Running";
                        break;
                    case 15:
                        statusDescription = "Cancelled (15)";
                        break;
                    default:
                        statusDescription = statusCode.ToString();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            return statusDescription;
        }

        //Sets the process status usign the input status string
        protected void SetWorkflowStatus(string statusValue)
        {
            switch (GetWorkflowStatusDescription(statusValue))
            {
                case "Success":
                    Status = ProcessStatus.Success;
                    break;
                case "Running":
                    Status = ProcessStatus.Running;
                    break;
                case "Failed":
                    Status = ProcessStatus.Failed;
                    break;
                default:
                    Status = ProcessStatus.Unknown;
                    break;
            }
        }

        internal void AddWebPages(String name, WebBrowser webBrowser)
        {
            WebPageMetadata metadata = new WebPageMetadata();
            metadata.webPageName = name;
            metadata.webBrowser = webBrowser;
            metadata.Status = ProcessStatus.Unknown;
            _webPages.Add(metadata);
        }

        // Get the metadata for a specific web page 
        protected WebPageMetadata FindWebPage(string webPageName)
        {
            foreach (WebPageMetadata m in _webPages)
            {
                if (m.webPageName == webPageName)
                    return m;
            }
            throw new ApplicationException("Unknown web page name: " + webPageName);
        }
 
        private void SendEmailItem(string to, string subjectEmail, string bodyEmail)
        {
            try
            {
                //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(BI_ADMIN_EMAIL, to);
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new System.Net.Mail.MailAddress(_BIAdminEmail);
                message.To.Add(to);
                message.Subject = subjectEmail;
                message.Body = bodyEmail;
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(_SMTPHost);
                client.Send(message);
            }
            catch (System.FormatException e)
            {   // Email address does not have the correct format
                System.Diagnostics.EventLog.WriteEntry("BI Monitor", e.Message);
            }
        }

        // Override for derived classes so they do not have to store the email address
        protected void SendEmailItem(string subjectEmail, string bodyEmail)
        {
            SendEmailItem(_BIAdminEmail, subjectEmail, bodyEmail);
        }
 
        /// <summary>
        /// Executes a shell command synchronously.
        /// </summary>
        /// <param name="command">string command</param>
        /// <returns>string, as output of the command.</returns>
        protected string ExecuteCommandSync(object command)
        {
            string result = "";
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                //System.Windows.Forms.MessageBox.Show(result);
            }
            catch (Exception e)
            {
                System.Diagnostics.EventLog.WriteEntry("BI Monitor", e.Message);
            }
            return result;
        }

//        public void ScheduleInfaWorkflow(string workflowName)
//        {
//            ExecuteCommandSync(_InfaPMCMDExePath + " " + scheduleworkflow  -sv " + _InfaISName + " -u AdminErick -p MacyMarle2 -d " + _InfaDomainName + " " + workflowName);
//        }

#region "Events"
        public class StatusUpdatedEventArgs : EventArgs
        {
            private string _message = "";
            public StatusUpdatedEventArgs(string s)
            {
                _message = s;
            }
            public string Message
            {
                get { return _message; }
            }
        }

        // Declare the delegate (if using non-generic pattern).
        public delegate void StatusUpdatedEventHandler(object sender, StatusUpdatedEventArgs e);
        
        // Declare the event.
        public event StatusUpdatedEventHandler StatusUpdateEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseStatusUpdatedEvent()
        {
            // Raise the event by using the () operator.
            StatusUpdateEvent(this, new StatusUpdatedEventArgs("Hello"));
        }
    }
#endregion
}
