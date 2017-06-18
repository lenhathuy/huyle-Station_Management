using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace MVCView.Metadta.Device
{
    public partial class FrmDeviceList : Form
    {

        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        private SqlConnection con;

        public FrmDeviceList()
        {
            InitializeComponent();
        }

        private void FrmDeviceList_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
                // Build the SQL string
                StringBuilder mySql = new StringBuilder(" SELECT tb.ID, kv.TENKV, tb.status, tb.Latitude, tb.Longitude  ");
                mySql.Append(" FROM DANHSACHTB tb ");
                mySql.Append(" LEFT JOIN KHUVUC kv ON tb.MAKV = kv.ID ");
                mySql.Append(" WHERE tb.ISSHOW = 1 ");
                SqlCommand query = new SqlCommand(mySql.ToString());
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvList.DataSource = dt;
                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FrmDeviceList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("huy.le@hoanghacgroup.com");
                mail.To.Add("huy.le@hoanghacgroup.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("huy.le@hoanghacgroup.com", "nhatquynh");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
