using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVCView.ViewModel;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCView.Metadta.Device
{
    public partial class FrmEditDevice : Form
    {
        public DeviceViewModel device;
        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        List<int> listIdAdd = new List<int>();
        List<int> listIdDelete = new List<int>();
        SqlConnection con;
        int ID = 0;
        FrmDeviceList frmDeviceList;

        public FrmEditDevice(FrmDeviceList parent ,DeviceViewModel device)
        {
            this.device = device;
            this.frmDeviceList = parent;
            InitializeComponent();
        }

        private void FrmEditDevice_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(cs);
            OpenConnection();
            txtName.Text = device.Name;
            txtId.Text = device.ID > 0 ? device.ID.ToString() : "";
            txtCode.Text = device.Code;
            txtSerial.Text = device.Serial;
            if (device.ID > 0 && device.ReceiptDate != null)
                dateTimePicker1.Value = device.ReceiptDate;

            if (device.ID > 0 &&  device.SetupDate != null)
                dateTimePicker2.Value = device.SetupDate;

            loadStationInDevice();
            loadStationNotInDevice();
            CloseConnection();
        }

        private void loadStationInDevice()
        {
            try
            {
                lv2.Items.Clear();
                StringBuilder mySql = new StringBuilder("select s.Name, s.ID from Station s ");
                mySql.Append(" Where EXISTS ( Select 1 from StationDevice sd where s.ID = sd.StationID and sd.DeviceID = @DeviceId ) ");

                SqlParameter DeviceId = new SqlParameter("@DeviceId", SqlDbType.Int);
                DeviceId.Value = device.ID;

                OpenConnection();
                SqlCommand query = new SqlCommand(mySql.ToString(), con);
                query.Parameters.Add(DeviceId);

                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["name"].ToString();
                    item.Tag = dr["ID"].ToString();
                    lv2.Items.Add(item);
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
            }
        }

        private void loadStationNotInDevice()
        {
            try
            {
                lv1.Items.Clear();
                StringBuilder mySql = new StringBuilder("select s.Name, s.ID from Station s  ");
                if (device.ID > 0) {
                    mySql.Append(" Where NOT EXISTS( Select 1 from StationDevice sd where s.ID = sd.StationID AND sd.DeviceID = @DeviceId ) ");
                }
                OpenConnection();
                SqlParameter DeviceId = new SqlParameter("@DeviceId", SqlDbType.Int);
                DeviceId.Value = device.ID;
                
                SqlCommand query = new SqlCommand(mySql.ToString());
                if (device.ID > 0) {
                    query.Parameters.Add(DeviceId);
                }
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["name"].ToString();
                    item.Tag = dr["ID"].ToString();
                    lv1.Items.Add(item);
                }
                CloseConnection();
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lv1, lv2, true);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lv2, lv1, false);
        }

        private void MoveSelectedItems(ListView source, ListView target, bool checkAdd)
        {
            if (source.SelectedItems.Count > 0)
            {
                ListViewItem temp = source.SelectedItems[0];
                source.Items.Remove(temp);
                target.Items.Add(temp);
                if (checkAdd)
                {
                    listIdAdd.Add(int.Parse(temp.Tag.ToString()));
                }
                else
                {
                    listIdDelete.Add(int.Parse(temp.Tag.ToString()));
                }
            }
            else {
                MessageBox.Show("Bạn chưa chọn trạm nào !!!", "Thông báo");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OpenConnection();
            if (device.ID != null && device.ID > 0)
            {
                ID = device.ID;
                Edit();
            }
            else {
                Add();
            }
            if (listIdAdd.Count > 0 || listIdDelete.Count > 0)
            {
                 for (int i = 0; i < listIdAdd.Count; i++)
                 {
                     addDevice2Station(listIdAdd[i]);
                     i++;
                 }
                 for (int i = 0; i < listIdDelete.Count; i++)
                 {
                     DeleteDeviceStation(listIdDelete[i]);
                     i++;
                 }
            }
            listIdAdd.Clear();
            listIdDelete.Clear();
            MessageBox.Show("Cập nhật Thiết bị thành công", "Thông báo");
            CloseConnection();
        }

        private void Edit()
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand myCommand = new SqlCommand(" UPDATE Device Set Name = @name, Serial = @Serial, Code = @Code, Status = @Status, ReceiptDate = @ReceiptDate, SetupDate = @SetupDate Where ID = @DeviceId ");
            myCommand.Connection = con;
          

            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter serial = new SqlParameter("@Serial", SqlDbType.VarChar);
            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter status = new SqlParameter("@Status", SqlDbType.Int);
            SqlParameter setupDate = new SqlParameter("@SetupDate", SqlDbType.DateTime);
            SqlParameter receiptDate = new SqlParameter("@ReceiptDate", SqlDbType.DateTime);
            SqlParameter deviceId = new SqlParameter("@DeviceId", SqlDbType.Int);

            name.Value = txtName.Text;
            serial.Value = txtSerial.Text;
            code.Value = txtCode.Text;
            status.Value = rdActive.Checked == true ? 1 : 0;
            setupDate.Value = dateTimePicker1.Value;
            receiptDate.Value = dateTimePicker1.Value;
            deviceId.Value = Int32.Parse(txtId.Text);

            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(serial);
            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(status);
            myCommand.Parameters.Add(setupDate);
            myCommand.Parameters.Add(receiptDate);
            myCommand.Parameters.Add(deviceId);
            myCommand.ExecuteNonQuery();
        }

        private void Add()
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO Device (Name, Serial, Code, Status, CreatedDate, SetupDate, ReceiptDate) OUTPUT Inserted.ID VALUES (@Name, @Serial, @Code, @Status, @CreatedDate, @SetupDate, @ReceiptDate) ");
            myCommand.Connection = con;

            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter serial = new SqlParameter("@Serial", SqlDbType.VarChar);
            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter status = new SqlParameter("@Status", SqlDbType.Int);
            SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
            SqlParameter setupDate = new SqlParameter("@SetupDate", SqlDbType.DateTime);
            SqlParameter receiptDate = new SqlParameter("@ReceiptDate", SqlDbType.DateTime);

            name.Value = txtName.Text;
            serial.Value = txtSerial.Text;
            code.Value = txtCode.Text;
            status.Value = rdActive.Checked == true ? 1 : 0;
            createdDate.Value = DateTime.Now;
            setupDate.Value = dateTimePicker2.Value;
            receiptDate.Value = dateTimePicker1.Value;

            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(serial);
            myCommand.Parameters.Add(status);
             myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(setupDate);
            myCommand.Parameters.Add(createdDate);
            myCommand.Parameters.Add(receiptDate);
            ID = myCommand.ExecuteNonQuery();
        }

        private void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        private void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void addDevice2Station(int stationAddId)
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO StationDevice (DeviceID, StationID, CreatedDate)  VALUES (@DeviceID, @StationID, @CreatedDate) ");
            
            myCommand.Connection = con;

            SqlParameter deviceId = new SqlParameter("@DeviceID", SqlDbType.Int);
            SqlParameter stationId = new SqlParameter("@StationID", SqlDbType.Int);
            SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

            deviceId.Value = ID;
            stationId.Value = stationAddId;
            createdDate.Value = DateTime.Now;

            myCommand.Parameters.Add(deviceId);
            myCommand.Parameters.Add(stationId);
            myCommand.Parameters.Add(createdDate);
            myCommand.ExecuteNonQuery();
        }

        private void DeleteDeviceStation(int stationAddId)
        {
            SqlCommand myCommand = new SqlCommand(" Delete From StationDevice WHERE  DeviceID = @DeviceID AND StationID = @StationID ");

            myCommand.Connection = con;

            SqlParameter deviceId = new SqlParameter("@DeviceID", SqlDbType.Int);
            SqlParameter stationId = new SqlParameter("@StationID", SqlDbType.Int);

            deviceId.Value = ID;
            stationId.Value = stationAddId;

            myCommand.Parameters.Add(deviceId);
            myCommand.Parameters.Add(stationId);
            myCommand.ExecuteNonQuery();
        }

        private void FrmEditDevice_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmDeviceList.LoadDevice();
        }
    }
}
