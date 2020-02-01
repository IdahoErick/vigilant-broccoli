using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace BIMonitor
{
    class Cognos8App : BaseProcess
    {
        internal int retryCount = 5;
        internal override ProcessStatus GetCurrentStatus()
        {
            // Check web page status
            Status = ProcessStatus.Success;
            foreach (WebPageMetadata m in WebPages)
            {
                switch (m.Status)
                {
                    case ProcessStatus.Success:
                        // Do nothing
                        break;
                    case ProcessStatus.Running:
                        if (Status != ProcessStatus.Failed)
                            Status = ProcessStatus.Running;
                        break;
                    case ProcessStatus.Failed:
                        if (_previousStatus == ProcessStatus.Success)
                            Status = ProcessStatus.UserActionRequired;
                        else
                            Status = ProcessStatus.Unknown;
                        break;
                    default:
                        Status = ProcessStatus.Unknown;
                        break;
                }
            }
            // call base function to handle notifications
            return base.GetCurrentStatus();
        }


        internal override String ProcessName
        {
            get
            {
                return "Cognos 8";
            }
        }
        internal override void RefreshTabData()
        {
            Status = ProcessStatus.Success;

            // refresh web pages
            foreach (WebPageMetadata m in WebPages)
            {
                //m.webBrowser.Refresh(); // Refresh the current web page
                m.webBrowser.Url = new Uri("http://advibi2/cognos8");
                //m.webBrowser = new WebBrowser();

                // Update the page status. This call will update the status based on the current page, because it did not have enough time to get the new page.
                // When the page is refreshed a "DocumentCompleted" event is raised. The event handler in the main app class will call the UpdateWebPageStatus again.
                // This call below is needed because it is possible that we miss the "DocumentCompleted" event.
                //UpdateWebPageStatus(m.webPageName);
            }
        }

        internal void UpdateWebPageStatus(string webPageName)
        {
            // Find web page in page array
            WebPageMetadata currentWebPage = null;
            foreach (WebPageMetadata m in WebPages)
            {
                if (m.webPageName == webPageName)
                {
                    currentWebPage = m;
                    break;
                }
            }
            if (currentWebPage == null)
                throw new ApplicationException("Unknown web page name: " + webPageName);
            
            // scrape web page contents to set status
            string docText = currentWebPage.webBrowser.DocumentText;
            switch (currentWebPage.webBrowser.Name)
            {
                case "webBrowserCognos8":
                    if (docText.Contains("Please type your credentials for authentication"))
                    {
                        currentWebPage.Status = ProcessStatus.Success;
                        retryCount = 5;
                    }
                    else if (retryCount == 0)
                        currentWebPage.Status = ProcessStatus.Failed;
                    else
                    {
                        currentWebPage.Status = ProcessStatus.Success;
                        retryCount -= 1;
                    }
                    break;
                default:
                    break;
            }
            // Notify parent class instance that status has been updated
            RaiseStatusUpdatedEvent();
        }
    }

}
