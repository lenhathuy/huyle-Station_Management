using MVCView.Metadta.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVCView
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void menuTram_MapView_Click(object sender, EventArgs e)
        {
            Test frm = new Test();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();           
        }

        private void menuMetadata_Device_Click(object sender, EventArgs e)
        {
            FrmDeviceList frm = new FrmDeviceList();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void menuMetadata_User_Click(object sender, EventArgs e)
        {
            FrmUser frm = new FrmUser();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();     
        }

        private void menuSetting_Alert_Click(object sender, EventArgs e)
        {
            FrmAlert frm = new FrmAlert();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();     
        }

        private void menuTram_TableView_Click(object sender, EventArgs e)
        {
            FrmStation frm = new FrmStation();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void menuStationInfo_Click(object sender, EventArgs e)
        {
            FrmStationConfig frm = new FrmStationConfig();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();     
        }
    }
}
