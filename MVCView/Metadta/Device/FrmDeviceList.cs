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
                StringBuilder mySql = new StringBuilder(" SELECT * ");
                mySql.Append(" FROM Device d ");       
                SqlCommand query = new SqlCommand(mySql.ToString());
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvList.DataSource = dt;

                BindingSource bs = new BindingSource();
                DataSet dset = new DataSet();
                da.Fill(dset);
                bs = new BindingSource();
                bs.DataSource = dt;
                bindingNavigator1.BindingSource = bs;

                dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

                //DataGridViewImageColumn delbut = new DataGridViewImageColumn();
                //delbut.Width = 20;
                //delbut.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvList.Columns.Add(delbut);
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
                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //mail.From = new MailAddress("huy.le@hoanghacgroup.com");
                //mail.To.Add("huy.le@hoanghacgroup.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";

                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("huy.le@hoanghacgroup.com", "nhatquynh");
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Send(mail);
                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            FrmEditDevice frm = new FrmEditDevice();
            frm.lblInfo.Text = "Thêm Mới Trạm";
            frm.ShowDialog();
        }

        private void gbSearch_Enter(object sender, EventArgs e)
        {

        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvList.Rows[e.RowIndex];
               
            }
        }
    }
}
