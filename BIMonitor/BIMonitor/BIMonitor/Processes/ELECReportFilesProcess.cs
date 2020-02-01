using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace BIMonitor
{
    class ELECReportFilesProcess : BaseProcess
    {
        private System.Windows.Forms.TextBox _tbELECFilesLogFile;

        internal override String ProcessName
        {
            get
            {
                return "ELEC Report Files";
            }
        }

        internal override void RefreshTabData()
        {
            Status = ProcessStatus.Success;
            base.RefreshTabData();      // Call base class to refresh data grid views
            UpdateELECFilesLogFile();
        }

        internal TextBox ELECFilesLogFile
        {
            get { return _tbELECFilesLogFile; }
            set { _tbELECFilesLogFile = value; }
        }

        private void UpdateELECFilesLogFile()
        {
            try
            {
                string fileName = "\\\\advbi3\\CognosFiles\\Logs\\TELEC_errors.log";
                string lines = "";
                if (File.Exists(fileName))
                {
                    StreamReader fileStream = new StreamReader(fileName);
                    string line;
                    line = fileStream.ReadLine();
                    while (line != null)
                    {
                        if (line.Contains("error"))
                            Status = ProcessStatus.Failed;

                        lines = lines + "\r\n" + line;
                        line = fileStream.ReadLine();
                    }
                    fileStream.Close();
                }
                else
                    lines = "File " + fileName + " does not exist";

                // Fill text box
                _tbELECFilesLogFile.Clear();
                _tbELECFilesLogFile.Text = lines;
            }
            catch (System.IO.IOException e)
            {    // Ignore IO exceptions: sometimes it is not possible to read the file when another process is writing to the file
                System.Diagnostics.EventLog.WriteEntry("BI Monitor", e.Message);
            }
        }

        // Load datatable with file list from ELEC Files location
        internal DataSet UpdateELECFilesListView()
        {
            DataSet ds = new DataSet();
            try
            {
                System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo("\\\\fsgroups\\groups\\Everyone\\IT\\BusinessIntelligence\\Telecom\\ClientInventory");
                System.IO.FileInfo[] fFileArray = folder.GetFiles();

                DataTable listItems = new DataTable();
                listItems.Columns.Add("Filename");
                listItems.Columns.Add("Extension");
                listItems.Columns.Add("Size (KB)");
                listItems.Columns.Add("Date Modified", System.Type.GetType("System.DateTime"));

                foreach (System.IO.FileInfo fFile in fFileArray)
                {
                    DataRow rCurrent = listItems.NewRow();
                    rCurrent["Filename"] = fFile.Name;
                    rCurrent["Extension"] = fFile.Extension;
                    rCurrent["Size (KB)"] = (fFile.Length / 1024) + 1;
                    rCurrent["Date Modified"] = fFile.LastWriteTime;
                    listItems.Rows.Add(rCurrent);

                    if (IsCurrentFile(fFile.LastWriteTime) == false)
                        Status = ProcessStatus.Failed;
                }
                listItems.DefaultView.Sort = "[Date Modified] desc";
                ds.Tables.Add(listItems);
            }
            catch (ApplicationException)
            {
                System.Windows.Forms.MessageBox.Show("Invalid File Location ");
            }
            return ds;
        }
        // Determine if the file is current
        internal bool IsCurrentFile(DateTime dateTime)
        {
            return dateTime >= DateTime.Now.AddDays(-1);
        }
    }
}
