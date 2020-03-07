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
    public partial class SolutionForm : Form
    {
        public SolutionForm(string problem, string solution)
        {
            InitializeComponent();
            this.tbProblem.Text = problem;
            this.tbSolution.Text = solution;
        }

        private void tbSolution_DoubleClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(tbSolution.Text);
            toolStripStatusLabel1.Text = "Solution copied to clipboard";
        }
    }
}
