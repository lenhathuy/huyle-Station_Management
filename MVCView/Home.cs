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
        }
    }
}
