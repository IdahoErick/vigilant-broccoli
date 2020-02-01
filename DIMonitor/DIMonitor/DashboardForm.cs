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
    public partial class DashboardForm : Form
    {
        private List<clsILProcess> _processList = new List<clsILProcess>();
        
        public DashboardForm()
        {
            InitializeComponent();

            // Add all IL processes
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.LOCAL, Utility.PERIOD.DAG, btnILVBLocalDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.LOCAL, Utility.PERIOD.MAAND, btnILVBLocalMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.DEV, Utility.PERIOD.MAAND, btnILVBDevDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.DEV, Utility.PERIOD.DAG, btnILVBDevMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.TEST, Utility.PERIOD.DAG, btnILVBTestDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.TEST, Utility.PERIOD.MAAND, btnILVBTestMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.ACC, Utility.PERIOD.MAAND, btnILVBAccDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.ACC, Utility.PERIOD.DAG, btnILVBAccMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.PROD, Utility.PERIOD.DAG, btnILVBProdDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVB, Utility.ENV.PROD, Utility.PERIOD.MAAND, btnILVBProdMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.LOCAL, Utility.PERIOD.DAG, btnILVVLocalDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.LOCAL, Utility.PERIOD.MAAND, btnILVVLocalMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.DEV, Utility.PERIOD.MAAND, btnILVVDevDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.DEV, Utility.PERIOD.DAG, btnILVVDevMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.TEST, Utility.PERIOD.DAG, btnILVVTestDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.TEST, Utility.PERIOD.MAAND, btnILVVTestMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.ACC, Utility.PERIOD.MAAND, btnILVVAccDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.ACC, Utility.PERIOD.DAG, btnILVVAccMaand));

            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.PROD, Utility.PERIOD.DAG, btnILVVProdDag));
            _processList.Add(new clsILProcess(Utility.BU.ILVV, Utility.ENV.PROD, Utility.PERIOD.MAAND, btnILVVProdMaand));

            RefreshStatus();
        }

        private void RefreshStatus()
        {
            foreach (clsILProcess p in _processList)
            {
                try
                {
                    p.GetStatus();
                }
                catch (Exception e)
                {
                    toolStripStatusLabel1.Text = e.Message;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshStatus();
        }
    }

}
