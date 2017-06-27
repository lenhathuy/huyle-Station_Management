using MVCView.Metadta.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace MVCView
{
    public partial class Home : Form
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        private string smtpAddress = "smtp.gmail.com";
        private int portNumber = 587;
        private bool enableSSL = true;

        private string emailFrom = "bknight092@gmail.com";
        private string password = "12345678x@X";
        private string subject = "Alert";

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
            Timer timer;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Start();
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            GetNotify();
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

        public void GetNotify()
        {
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("spGetNotify", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            try
            {
                con.Open();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(item["Email"].ToString());
                        mail.Subject = subject;
                        mail.Body = "Alert Email";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential(emailFrom, password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
                }
            }
        }
    }
}
