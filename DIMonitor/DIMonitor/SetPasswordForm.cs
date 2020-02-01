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
    public partial class SetPasswordForm : Form
    {
        public SetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text.Length > 0)
            {
                //DIMonitor.Properties.Settings appSettings = new DIMonitor.Properties.Settings();
                //appSettings.LocalAdminPassword = tbPassword.Text;

                Properties.Settings.Default.LocalAdminPassword = Utility.EncryptString(tbPassword.Text);
                Properties.Settings.Default.Save();
            }
            this.Close();
        }
    }
}
