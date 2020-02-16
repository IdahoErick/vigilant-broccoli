using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace DIMonitor
{
    public partial class SourceFilesForm : BaseForm
    {
        private List<SourceFolderInfo> _sourceFolderInfo = new List<SourceFolderInfo>() 
        { 
            // Day
            new SourceFolderInfo("Close", true, 66, @"_\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("House", false, 144,@"\b\d{8}_", Utility.PERIOD.DAG ), 
            new SourceFolderInfo("Close_CM", true, 14, @"_\d{8}.csv", Utility.PERIOD.DAG), 
            new SourceFolderInfo("DAYBREAK", true, 2, @"\b\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("MIDAS", true, 74, @"\b\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("MIDAS_CK", true,	2, @"\b\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("QUION", true, 20, @"_\d{4}_\d{2}_\d{2}", Utility.PERIOD.DAG),
            new SourceFolderInfo("SAP_ICM", true,	2, @"_\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("SAPBW", true,	5, @"_\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("HOMES", true,	74, @"\b\d{8}_", Utility.PERIOD.DAG),
            new SourceFolderInfo("HIST_HOMES", true, 76, @"\b\d{8}_", Utility.PERIOD.DAG),
            // Month
            new SourceFolderInfo("Close", true, 66, @"_\d{8}_", Utility.PERIOD.MAAND),
            new SourceFolderInfo("House", false, 144,@"\b\d{8}_", Utility.PERIOD.MAAND ), 
            new SourceFolderInfo("Close_CM", true, 14, @"_\d{8}.csv", Utility.PERIOD.MAAND), 
            new SourceFolderInfo("DAYBREAK", true, 2, @"\b\d{8}_", Utility.PERIOD.MAAND),
            new SourceFolderInfo("MIDAS", true, 74, @"\b\d{8}_", Utility.PERIOD.MAAND),
            new SourceFolderInfo("MIDAS_CK", true,	2, @"\b\d{8}_", Utility.PERIOD.MAAND),
            new SourceFolderInfo("QUION", true, 26, @"_\d{4}_\d{2}_\d{2}", Utility.PERIOD.MAAND),
            new SourceFolderInfo("SAP_ICM", true,	2, @"_\d{8}_", Utility.PERIOD.MAAND),
            new SourceFolderInfo("SAPBW", true,	5, @"_\d{8}_", Utility.PERIOD.MAAND),
        };
             
        public SourceFilesForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, Int64 ssisRunID)
        {
            InitializeComponent();
            Init(eNV, bU, period, ssisRunID);
        }
        
        public SourceFilesForm()
        {
            InitializeComponent();
        }

        private void dgvSourceFiles_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvSourceFiles.Rows[e.RowIndex].Cells["File Count"].Value != null && dgvSourceFiles.Rows[e.RowIndex].Cells["# Expected Files"].Value != null)
            {
                if (dgvSourceFiles.Rows[e.RowIndex].Cells["File Count"].Value.ToString() == dgvSourceFiles.Rows[e.RowIndex].Cells["# Expected Files"].Value.ToString())
                {
                    dgvSourceFiles.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LawnGreen;
                }
            }
        }
        
        public override void Refresh()
        {
            try
            {
                 DataTable dtSourceFiles = new DataTable();
                dtSourceFiles.Columns.Add("Folder Name", typeof(String));
                dtSourceFiles.Columns.Add("Date", typeof(String));
                dtSourceFiles.Columns.Add("File Count", typeof(Int32));
                dtSourceFiles.Columns.Add("# Expected Files", typeof(Int32));
                
                string baseFolder = "";

                if ((ENV == Utility.ENV.LOCAL) && (BU == Utility.BU.ILVB))
                    baseFolder = Properties.Settings.Default.ILH_MAPPED_DRIVE + ":\\ILH";
                else if ((ENV == Utility.ENV.LOCAL) && (BU == Utility.BU.ILVV)) 
                    baseFolder = Properties.Settings.Default.ILSB_MAPPED_DRIVE + ":\\ILSB";
                else if ((ENV==Utility.ENV.ACC) && (BU == Utility.BU.ILVB))
                    baseFolder = "\\\\SRAZZSQL0049\\P\\ILH";
                else if ((ENV == Utility.ENV.DEV) && (BU == Utility.BU.ILVB))
                    baseFolder = "\\\\SRDZZSQL0028\\P\\ILH";
                else if ((ENV == Utility.ENV.TEST) && (BU == Utility.BU.ILVB))
                    baseFolder = "\\\\SRTZZSQL0053\\P\\ILH";
                else if ((ENV == Utility.ENV.PROD) && (BU == Utility.BU.ILVB))
                    baseFolder = "\\\\SRPZZSQL0050\\P\\ILH";
                else if ((ENV == Utility.ENV.ACC) && (BU == Utility.BU.ILVV))
                    baseFolder = "\\\\SRAZZSQL0051\\P\\ILSB";
                else if ((ENV == Utility.ENV.DEV) && (BU == Utility.BU.ILVV))
                    baseFolder = "\\\\SRDZZSQL0029\\P\\ILSB";
                else if ((ENV == Utility.ENV.TEST) && (BU == Utility.BU.ILVV))
                    baseFolder = "\\\\SRTZZSQL0051\\P\\ILSB";
                else if ((ENV == Utility.ENV.PROD) && (BU == Utility.BU.ILVV))
                    baseFolder = "\\\\SRPZZSQL0052\\P\\ILSB";


                List<string> dirs = new List<string>(Directory.EnumerateDirectories(baseFolder));
                foreach (var dir in dirs)
                {
                    string sourceName = dir.Substring(baseFolder.Length+1);
                    string targetFolder = dir + "\\IN\\" + EnglishPeriod;
                    if (Directory.Exists(targetFolder) && !targetFolder.ToUpper().Contains("SAPBW"))
                    {
                        int numberOfExpectedFiles = -1;

                        // Find folder in list of source folders
                        SourceFolderInfo folderInfo = _sourceFolderInfo.Find(x => x.SourceFolderName.ToUpper().Equals(sourceName.ToUpper()) && x.Period == this.Period);
                        if (folderInfo != null)
                        {
                            numberOfExpectedFiles = folderInfo.NumberOfFiles;
                        }

                        // Loop through files and make array of file dates and count
                        string pattern = @"_\d{8}_";
                        if (folderInfo != null)
                            pattern = folderInfo.FilePattern;

                        List<FileCount> filesPerDate = new List<FileCount>();

                        foreach (string fileName in Directory.GetFiles(targetFolder))
                        {
                            //if (sourceName.ToUpper() == "CLOSE")
                            //{
                                Match m = Regex.Match(fileName, pattern, RegexOptions.IgnoreCase);
                                if (m.Length > 0)
                                {
                                    string date = m.Value.Trim('_');
                                    FileCount fc = filesPerDate.Find(x => x.FileDate.Equals(date));
                                    if (fc != null)
                                        fc.NumberOfFiles++;
                                    else
                                        filesPerDate.Add(new FileCount(date, 1));
                                }
                            //}
                        }
                        // Add dummy row if there are no files
                        if (filesPerDate.Count == 0)
                            filesPerDate.Add(new FileCount("", 0));

                        // Create data row for every file date
                        foreach (FileCount fc in filesPerDate)
                        {
                            DataRow dr = dtSourceFiles.NewRow();
                            dr["Folder Name"] = targetFolder;

                            //string fileName = Directory.GetFiles(dir).First().ToString();
                            dr["Date"] = fc.FileDate;
                            dr["File Count"] = fc.NumberOfFiles; // Directory.GetFiles(targetFolder, "*.*").Length;
                            dr["# Expected Files"] = numberOfExpectedFiles;
                            dtSourceFiles.Rows.Add(dr);
                        }
                     }
                }
                dgvSourceFiles.DataSource = dtSourceFiles;

                //dgvSourceFiles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); // (DataGridViewAutoSizeColumnsMode.Fill);
                
                dgvSourceFiles.Columns["Folder Name"].Width = 250;
                dgvSourceFiles.Refresh();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    public class SourceFolderInfo
    {
        private int _numberOfFiles = -1;

        public int NumberOfFiles
        {
            get { return _numberOfFiles; }
            set { _numberOfFiles = value; }
        }
        private string _sourceFolderName = "";

        public string SourceFolderName
        {
            get { return _sourceFolderName; }
            set { _sourceFolderName = value; }
        }
        private bool _hasFixedNumberOfFiles = false;

        public bool HasFixedNumberOfFiles
        {
            get { return _hasFixedNumberOfFiles; }
            set { _hasFixedNumberOfFiles = value; }
        }

        private string _filePattern;

        public string FilePattern
        {
            get { return _filePattern; }
            set { _filePattern = value; }

        }

        Utility.PERIOD _period;

        public Utility.PERIOD Period
        {
            get { return _period; }
            set { _period = value; }
        }
        
        public SourceFolderInfo(string sourceFolderName, bool hasFixedNumberOfFile, int numberOfFiles, string filePattern, Utility.PERIOD period)
        {
            _numberOfFiles = numberOfFiles;
            _sourceFolderName = sourceFolderName;
            _hasFixedNumberOfFiles = hasFixedNumberOfFile;
            _filePattern = filePattern;
            _period = period;
        }
    }
    public class FileCount
    {
        private int _numberOfFiles = -1;

        public int NumberOfFiles
        {
            get { return _numberOfFiles; }
            set { _numberOfFiles = value; }
        }

        private string _fileDate;

        public string FileDate
        {
            get { return _fileDate; }
            set { _fileDate = value; }
        }
        public FileCount(string fileDate, int numberOfFiles)
        {
            _numberOfFiles = numberOfFiles;
            _fileDate = fileDate;
        }
    }

}
