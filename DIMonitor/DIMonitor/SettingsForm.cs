using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DIMonitor
{
    public partial class SettingsForm : Form
    {
        private DIMonitor.Properties.Settings _appSettings;

        public SettingsForm()
        {
            InitializeComponent();

            pgSettings.SelectedObject = _appSettings;
            System.Configuration.UserScopedSettingAttribute userAttr = new System.Configuration.UserScopedSettingAttribute();
            System.ComponentModel.AttributeCollection attrs = new System.ComponentModel.AttributeCollection(userAttr);
            pgSettings.BrowsableAttributes = attrs;
        }

        internal DIMonitor.Properties.Settings AppSettings
        {
            get { return _appSettings; }
            set
            {
                _appSettings = value;
                pgSettings.SelectedObject = _appSettings;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
