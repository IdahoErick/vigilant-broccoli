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
    public partial class QueryOutputForm : Form
    {
        public QueryOutputForm(string query)
        {
            InitializeComponent();
            this.tbQuery.Text = query;
        }
    }
}
