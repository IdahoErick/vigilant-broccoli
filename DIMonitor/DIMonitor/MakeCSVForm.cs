using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIMonitor
{
    public partial class MakeCSVForm : BaseForm
    {
        const int TIMEOUT = 5000; // milliseconds

        public MakeCSVForm()
        {
            InitializeComponent();
            timer1.Interval = TIMEOUT;
            toolStripStatusLabel1.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rtbInputList_SelectionChanged(object sender, EventArgs e)
        {
            MakeCSVString();
        }

        private void MakeCSVString()
        {
            String[] strlist = rtbInputList.Text.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            // Add quotes if checked
            if (cbAddQuotes.Checked == true)
            {
                for (int i = 0; i < strlist.Length; i++)
                {
                    strlist[i] = "'" + strlist[i] + "'";
                }
            }
            rtbResult.Text = String.Join(",", strlist);
            System.Windows.Forms.Clipboard.SetText(rtbResult.Text);
            toolStripStatusLabel1.Text = "Result copied to clipboard";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            timer1.Stop();
        }

        private void cbAddQuotes_CheckedChanged(object sender, EventArgs e)
        {
            MakeCSVString();
        }
    }
}
