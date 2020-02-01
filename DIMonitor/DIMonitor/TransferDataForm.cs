using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DIMonitor
{
    public partial class TransferDataForm : Form
    {
        public TransferDataForm()
        {
            InitializeComponent();

            //Load transfer batch file list
            if(System.IO.Directory.Exists(@"C:\Temp\bcp"))
            {
                string[] files = new System.IO.DirectoryInfo(@"C:\Temp\bcp").GetFiles("*.bat").Select(o => o.Name).ToArray();
                this.cbTransferBatchFile.Items.AddRange(files);
            }
            else
                tssLabel.Text = "Directory c:\temp\bcp does not exist";
        }

        private void btnRunBcp_Click(object sender, EventArgs e)
        {
            if ((this.cbTransferBatchFile.SelectedItem != "") && (MessageBox.Show("Execute batch file " + this.cbTransferBatchFile.SelectedItem + "?", "Data Transfer", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                try
                {
                    Process.Start("C:\\temp\\bcp\\" + this.cbTransferBatchFile.SelectedItem);
                }
                catch (Exception ex)
                {
                    tssLabel.Text = ex.Message;
                };
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
