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

namespace DIMonitor
{
    public partial class SourceFilesForm : BaseForm
    {
        public SourceFilesForm(Utility.ENV eNV, Utility.BU bU, Utility.PERIOD period, Int64 ssisRunID)
        {
            InitializeComponent();
            Init(eNV, bU, period, ssisRunID);
        }
        public override void Refresh()
        {
            try
            {
                 DataTable dtSourceFiles = new DataTable();
                dtSourceFiles.Columns.Add("Folder Name", typeof(String));
                dtSourceFiles.Columns.Add("File Count", typeof(Int32));

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
                    string targetFolder = dir + "\\IN\\" + EnglishPeriod;
                    if (Directory.Exists(targetFolder))
                    {
                        DataRow dr = dtSourceFiles.NewRow();
                        dr["Folder Name"] = targetFolder;
                        dr["File Count"] = Directory.GetFiles(targetFolder, "*.*").Length;
                        dtSourceFiles.Rows.Add(dr);
                    }
                }
                dgvSourceFiles.DataSource = dtSourceFiles;
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
    }
}
