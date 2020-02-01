using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Data;

namespace BIMonitor
{
    class FIQBIProcess : BaseProcess
    {
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
                        Status = ProcessStatus.Failed;
                        break;
                    default:
                        Status = ProcessStatus.Unknown;
                        break;
                }
            }

            // If any page has state running or failed : process state is running or failed
            // If all are complete but start date on advibi2 or advcog1 < start date on advbi2 or advbi3 -> status = waiting

            if (Status == ProcessStatus.Success)
            {
                if ((FindWebPage("ADVCOG1").startTime < FindWebPage("ADVBI3").startTime)
                    || (FindWebPage("ADVIBI2").startTime < FindWebPage("ADVBI2").startTime))
                        Status = ProcessStatus.Waiting;
            }
            
            // If ADVCOG1 or ADVIBI2 have been running longer than expected set status to UserActionRequired
            WebPageMetadata advcog1Page = FindWebPage("ADVCOG1");
            WebPageMetadata advibi2Page = FindWebPage("ADVIBI2");
            if (((advcog1Page.Status == ProcessStatus.Running) && (advcog1Page.startTime.Add(new TimeSpan(0,30,0)) < DateTime.Now))
                || ((advibi2Page.Status == ProcessStatus.Running) && (advibi2Page.startTime.Add(new TimeSpan(0,30,0)) < DateTime.Now)))
                Status = ProcessStatus.UserActionRequired;

            // Send email if everything is done
            if ((Status == BaseProcess.ProcessStatus.Success) && (_previousStatus == BaseProcess.ProcessStatus.Running || _previousStatus == BaseProcess.ProcessStatus.UserActionRequired))
                SendEmailItem("FIQ Cube Migration completed succesfully", "");

            // call base function to handle notifications
            return base.GetCurrentStatus();
        }

        internal override String ProcessName
        {
            get
            {
                return "FIQ BI";
            }
        }
        internal override void RefreshTabData()
        {
            base.RefreshTabData();  // call base function first

            Status = ProcessStatus.Success;

            // refresh web pages
            foreach (WebPageMetadata m in WebPages)
            {
                m.webBrowser.Refresh(); // Refresh the current web page
                // Update the page status. This call will update the status based on the current page, because it did not have enough time to get the new page.
                // When the page is refreshed a "DocumentCompleted" event is raised. The event handler in the main app class will call the UpdateWebPageStatus again.
                // This call below is needed because it is possible that we miss the "DocumentCompleted" event.
                UpdateWebPageStatus(m.webPageName);
            }
        }

        internal void UpdateWebPageStatus(string webPageName)
        {
            // Find web page in page array
            WebPageMetadata currentWebPage = GetWebPage(webPageName);
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
            try
            {
                string docText = currentWebPage.webBrowser.DocumentText;
                switch (webPageName)
                {
                    case "ADVBI2":
                    case "ADVBI3":
                        if (docText.Contains("Completed Cube Build Process"))
                            currentWebPage.Status = ProcessStatus.Success;
                        else if (docText.Contains("Begin Cube Build Process"))
                            currentWebPage.Status = ProcessStatus.Running;
                        else
                            currentWebPage.Status = ProcessStatus.Failed;
                        break;
                    case "ADVCOG1":
                    case "ADVIBI2":
                        if (docText.Contains("Successful Cube Migration process"))
                            currentWebPage.Status = ProcessStatus.Success;
                        else if (docText.Contains("Start Migration process"))
                            currentWebPage.Status = ProcessStatus.Running;
                        else
                            currentWebPage.Status = ProcessStatus.Failed;
                        break;
                    default:
                        break;
                }

                //docText = "Start Migration process...[10/21/2009 9:30:02 AM]<BR>";
                // Update start and end times
                if (docText.Contains("Start Time: ") == true)
                    currentWebPage.startTime = ParseDateTime(docText, "Start Time: ", "<BR>");
                else if (docText.Contains("Start Migration process") == true)
                    currentWebPage.startTime = ParseDateTime(docText, "Start Migration process...[", "]");
                else
                    currentWebPage.startTime = DateTime.Parse("1/1/1990");

                if (docText.Contains("End Time: "))
                    currentWebPage.endTime = ParseDateTime(docText, "End Time: ", "<BR>");
                else
                    currentWebPage.endTime = DateTime.Parse("1/1/1990");

                if (docText.Contains("Cubes Built: "))
                    currentWebPage.nbrCubes = ParseInt32(docText, "Cubes Built: ", "\n");
                else if (docText.Contains("Cubes Moved: "))
                    currentWebPage.nbrCubes = ParseInt32(docText, "Cubes Moved: ", "<BR>");
                else
                    currentWebPage.endTime = DateTime.Parse("1/1/1990");

                // Notify parent class instance that status has been updated
                RaiseStatusUpdatedEvent();

            }
            catch (System.IO.FileNotFoundException e)
            {    // Ignore file not found exceptions: sometimes it is not possible to get the page
                //MessageBox.Show(e.Message);
                System.Diagnostics.EventLog.WriteEntry("BI Monitor", e.Message);
            }
        }
        // Find the web page in the array of web pages
        private WebPageMetadata GetWebPage(string webPageName)
        {
            WebPageMetadata currentWebPage = null;
            foreach (WebPageMetadata m in WebPages)
            {
                if (m.webPageName == webPageName)
                {
                    currentWebPage = m;
                    break;
                }
            }
            return currentWebPage;
        }

        // Finds the caption in the docText and parses the following date time string
        private DateTime ParseDateTime(string docText, string caption, string dateTimeSuffix)
        {
            string dateTimePart = docText.Substring(docText.IndexOf(caption) + caption.Length);
            dateTimePart = dateTimePart.Substring(0, dateTimePart.IndexOf(dateTimeSuffix));
            return DateTime.Parse(dateTimePart);
        }
        // Finds the caption in the docText and parses the following date time string
        private Int32 ParseInt32(string docText, string caption, string numberSuffix)
        {
            string numberPart = docText.Substring(docText.IndexOf(caption) + caption.Length);
            numberPart = numberPart.Substring(0, numberPart.IndexOf(numberSuffix));
            return Int32.Parse(numberPart);
        }
        public DataSet GetFIQBISummary()
        {
            // Create data table
            DataTable summaryTable = new DataTable();
            DataColumn dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName="Date";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName="BI2Start";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "BI2End";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.TimeSpan");
            dc.ColumnName = "BI2Duration";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "BI2Cubes";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "BI3Start";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "BI3End";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.TimeSpan");
            dc.ColumnName = "BI3Duration";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "BI3Cubes";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "IBI2Start";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "IBI2End";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.TimeSpan");
            dc.ColumnName = "IBI2Duration";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "IBI2Cubes";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "COG1Start";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.DateTime");
            dc.ColumnName = "COG1End";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.TimeSpan");
            dc.ColumnName = "COG1Duration";
            summaryTable.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "COG1Cubes";
            summaryTable.Columns.Add(dc);

            // Create row
            DataRow row = summaryTable.NewRow();
            // ADVBI2
            WebPageMetadata page = GetWebPage("ADVBI2");
            row["Date"] = page.endTime;
            row["BI2Start"] = page.startTime;
            row["BI2End"] = page.endTime;
            row["BI2Duration"] = page.endTime - page.startTime;
            row["BI2Cubes"] = page.nbrCubes;
            // ADVBI3
            page = GetWebPage("ADVBI3");
            row["Date"] = page.endTime;
            row["BI3Start"] = page.startTime;
            row["BI3End"] = page.endTime;
            row["BI3Duration"] = page.endTime - page.startTime;
            row["BI3Cubes"] = page.nbrCubes;
            // ADVIBI2
            page = GetWebPage("ADVIBI2");
            row["Date"] = page.endTime;
            row["IBI2Start"] = page.startTime;
            row["IBI2End"] = page.endTime;
            row["IBI2Duration"] = page.endTime - page.startTime;
            row["IBI2Cubes"] = page.nbrCubes;
            // ADVIBI2
            page = GetWebPage("ADVCOG1");
            row["Date"] = page.endTime;
            row["COG1Start"] = page.startTime;
            row["COG1End"] = page.endTime;
            row["COG1Duration"] = page.endTime - page.startTime;
            row["COG1Cubes"] = page.nbrCubes;
            summaryTable.Rows.Add(row);

            // Create a table from the query.
            DataSet summaryData = new DataSet();
            summaryData.Tables.Add(summaryTable);

            return summaryData;
        }
    }

}
