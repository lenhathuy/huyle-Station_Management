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
using MVCView.ViewModel;

namespace MVCView.Metadta.Device
{
    public partial class FrmDeviceList : Form
    {

        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        SqlConnection con;
        int ID = 0;


        /// <summary>
        /// Source data
        /// </summary>
        private List<DeviceViewModel> sourceData = new List<DeviceViewModel>();

        /// <summary>
        /// Constant for page size
        /// </summary>
        public const int pageSize = 10;

        /// <summary>
        /// Total records
        /// </summary>
        private int _totalRecords;


        public FrmDeviceList()
        {
            InitializeComponent();
        }

        private void FrmDeviceList_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'scadaReceiveValueDataSet.Device' table. You can move, or remove it, as needed.
            //this.deviceTableAdapter.Fill(this.scadaReceiveValueDataSet.Device);
            try
            {
                connectDB();
                LoadDevice();
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

        public void LoadDevice()
        {
            sourceData.Clear();
            // Build the SQL string
            StringBuilder mySql = new StringBuilder(" SELECT * ");
            mySql.Append(" FROM Device d ");
            SqlCommand com = new SqlCommand(mySql.ToString());
            com.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
                
            try
            {
                
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

            if (dt.Rows.Count > 0)
            {
                //totalRecords = dtSource.Rows.Count;  
                foreach (DataRow item in dt.Rows)
                {
                    var device = new DeviceViewModel
                    {
                        ID = int.Parse(item["ID"].ToString()),
                        Name = item["Name"].ToString(),
                        Code = item["Code"].ToString(),
                        Serial = item["Serial"].ToString(),
                        Status = Convert.ToBoolean(item["Status"].ToString()),
                        ReceiptDate = Convert.ToDateTime(item["ReceiptDate"].ToString()),
                        SetupDate = Convert.ToDateTime(item["SetupDate"].ToString()),
                        CreatedDate = Convert.ToDateTime(item["CreatedDate"].ToString())
                    };

                    sourceData.Add(device);
                }
            }

            _totalRecords = sourceData.Count;
            bindingNavigator1.BindingSource = bsDevice;
            bsDevice.DataSource = dt;
            dgvList.DataSource = bsDevice;

            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            //bsStation.CurrentChanged += new EventHandler(stationCurrentChanged);
            //bsStation.DataSource = new PageOffsetList(pageSize, _totalRecords);
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

        public void connectDB()
        {
            try
            {
                con = new SqlConnection(cs);
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            FrmEditDevice frm = new FrmEditDevice(this, new DeviceViewModel());
            frm.lblInfo.Text = "Thêm Mới Thiết Bị";
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

        private void delIcon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ID > 0)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete Users where ID=@id", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!");
                }
                else
                {
                    MessageBox.Show("Please Select Record to Delete");
                }
            }
        }

        private void editIcon_Click(object sender, EventArgs e)
        {
            if (ID > 0) {
                DeviceViewModel model = sourceData.Where(x => x.ID == ID).FirstOrDefault();
                FrmEditDevice frm = new FrmEditDevice(this, model);
                frm.lblInfo.Text = "Chỉnh sửa Thiết bị";
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select Record to Edit");
            }
        }

        private void dgvList_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void dgvList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dgvList.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void lblDeviceCode_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
