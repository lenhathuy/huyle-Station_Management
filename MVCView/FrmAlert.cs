﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVCView
{
    public partial class FrmAlert : Form
    {
        public FrmAlert()
        {
            InitializeComponent();
        }
        public DataSet DeviceDataSet { get; private set; }

        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        private void FrmAlert_Load(object sender, EventArgs e)
        {
            loadNotify();
            cbType.DataSource = InitializeTyleAlertData();
            cbType.DisplayMember = "Display";

            cbTypeNotify.DataSource = InitializeKieuThongBaoData();
            cbTypeNotify.DisplayMember = "Display";

            cbLevelAlert.DataSource = InitializeLevel();
            cbLevelAlert.DisplayMember = "Display";

            cbKenh.DataSource = InitializeChannelData();
            cbKenh.DisplayMember = "Display";

            GetDevice();

            cbDevice.DataSource = DeviceDataSet.Tables["Device"].Copy();
            cbDevice.DisplayMember = "Name";
            cbDevice.ValueMember = "ID";


            dgvList.Columns[0].HeaderText = "ID";
            dgvList.Columns[1].HeaderText = "Tên sự kiện";
            dgvList.Columns[2].HeaderText = "Thiết bị";
            dgvList.Columns[3].HeaderText = "Kênh";
            dgvList.Columns[4].HeaderText = "Mức báo động";
            dgvList.Columns[5].HeaderText = "Kiểu thông báo";
            dgvList.Columns[6].HeaderText = "Trạng thái";
            dgvList.Columns[7].HeaderText = "Ngày tạo";
        }

        private int GetChannelDevice(int channelId, int deviceId, int type)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(cs);
            StringBuilder sql = new StringBuilder("select top 1 * from [dbo].[ChannelDevice] ");
            sql.Append("where ChannelId = @channelId ");
            sql.Append("and DeviceId = @deviceId");
            sql.Append(" and typeId = @typeId ");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            SqlParameter channel = cmd.Parameters.Add("@channelId", SqlDbType.Int);
            channel.Value = channelId;
            SqlParameter device = cmd.Parameters.Add("@deviceId", SqlDbType.Int);
            device.Value = deviceId;
            SqlParameter typeId = cmd.Parameters.Add("@typeId", SqlDbType.Int);
            typeId.Value = type;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                da.Fill(dataTable);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            var row = dataTable.Rows[0];
            var result = Int32.Parse(row["ID"].ToString());
            return result;
        }

        private void loadNotify()
        {
            StringBuilder mySql = new StringBuilder(" SELECT n.ID, n.Name, d.Name, n.ChannelID, n.AlertLevel, n.MessageType, n.Status , n.createdDate ");
            mySql.Append(" FROM Notify n ");
            mySql.Append(" Left Join Device d ON d.ID = n.DeviceID ");
            SqlConnection con = new SqlConnection(cs);  
            SqlCommand query = new SqlCommand(mySql.ToString(), con);
            SqlDataAdapter da = new SqlDataAdapter(query);
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                da.Fill(dt);
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

            // Build the SQL string
            bindingNavigator1.BindingSource = bsAlert;
            bsAlert.DataSource = dt;
            dgvList.DataSource = bsAlert;
        }

        private List<TypeAlertModel> InitializeTyleAlertData()
        {
            return new List<TypeAlertModel>()
            {
                new TypeAlertModel(1, "Báo dữ liệu"),
                new TypeAlertModel(2, "Pin yếu"),
            };
        }

        private List<TypeAlertModel> InitializeKieuThongBaoData()
        {
            return new List<TypeAlertModel>()
            {
                new TypeAlertModel(1, "EMAIL"),
                new TypeAlertModel(2, "POPUP"),
                new TypeAlertModel(3, "SMS"),
                new TypeAlertModel(4, "DATABASE"),
            };
        }

        private List<TypeAlertModel> InitializeLevel()
        {
            return new List<TypeAlertModel>()
            {
                new TypeAlertModel(1, "Mức 1"),
                new TypeAlertModel(2, "Mức 2"),
                new TypeAlertModel(3, "Mức 3"),
                new TypeAlertModel(4, "Mức 4"),
            };
        }

        private List<ChannelModel> InitializeChannelData()
        {
            return new List<ChannelModel>()
            {
                new ChannelModel(1, "Kênh 1"),
                new ChannelModel(2, "Kênh 2"),
                new ChannelModel(3, "Kênh 3"),
                new ChannelModel(4, "Kênh 4"),
                new ChannelModel(5, "Kênh 5"),
                new ChannelModel(6, "Kênh 6"),
                new ChannelModel(7, "Kênh 7"),
                new ChannelModel(8, "Kênh 8")
            };
        }

        private void addIcon_Click(object sender, EventArgs e)
        {

        }

        private void editIcon_Click(object sender, EventArgs e)
        {

        }

        private void delIcon_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(" INSERT Notify (Name,  MessageType, AlertType, AlertLevel, Status,CreatedDate) OUTPUT Inserted.ID  VALUES (@Name, @MessageType, @AlertType, @AlertLevel, @Status, @CreatedDate) ");
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                
                myCommand.Connection = con;

                SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
                //SqlParameter LowFLow = new SqlParameter("@LowFLow", SqlDbType.Float);
                //SqlParameter LowPressure = new SqlParameter("@LowPressure", SqlDbType.Float);
                //SqlParameter LowBattery = new SqlParameter("@LowBattery", SqlDbType.Float);
                //SqlParameter HighFlow = new SqlParameter("@HighFlow", SqlDbType.Float);
                //SqlParameter HighPressure = new SqlParameter("@HighPressure", SqlDbType.Float);
                //SqlParameter HighBattery = new SqlParameter("@HighBattery", SqlDbType.Float);

                SqlParameter AlertType = new SqlParameter("@AlertType", SqlDbType.Int);
                SqlParameter AlertLevel = new SqlParameter("@AlertLevel", SqlDbType.Int);
                SqlParameter MessageType = new SqlParameter("@MessageType", SqlDbType.VarChar);
                SqlParameter Status = new SqlParameter("@Status", SqlDbType.Int);
                //SqlParameter ChannelID = new SqlParameter("@ChannelID", SqlDbType.Int);
                //SqlParameter DeviceID = new SqlParameter("@DeviceID", SqlDbType.Int);
                SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                name.Value = txtName.Text;
                //LowFLow.Value = float.Parse(txtLowApLuc.Text);
                //LowPressure.Value = float.Parse(txtLowLuuLuong.Text);
                //LowBattery.Value = float.Parse(txtLowBattery.Text);
                //HighFlow.Value = float.Parse(txtHighApLuc.Text);
                //HighPressure.Value = float.Parse(txtHighLuuLuong.Text);
                //HighBattery.Value = float.Parse(txtHighBattery.Text);
                AlertType.Value = ((TypeAlertModel)cbType.SelectedValue).ID;
                AlertLevel.Value = ((TypeAlertModel)cbLevelAlert.SelectedValue).ID;
                MessageType.Value = ((TypeAlertModel)cbTypeNotify.SelectedValue).Display; 
                Status.Value = rdActive.Checked ? 1 : 0;
                //DeviceID.Value = cbDevice.SelectedValue;
                //ChannelID.Value = ((ChannelModel)cbKenh.SelectedValue).ID;
                createdDate.Value = DateTime.Now;


                myCommand.Parameters.Add(name);
                //myCommand.Parameters.Add(LowFLow);
                //myCommand.Parameters.Add(LowPressure);
                //myCommand.Parameters.Add(LowBattery);
                //myCommand.Parameters.Add(HighFlow);
                //myCommand.Parameters.Add(HighBattery);
                //myCommand.Parameters.Add(HighPressure);
                myCommand.Parameters.Add(AlertType);
                myCommand.Parameters.Add(AlertLevel);
                myCommand.Parameters.Add(MessageType);
                myCommand.Parameters.Add(Status);
                //myCommand.Parameters.Add(DeviceID);
                //myCommand.Parameters.Add(ChannelID);
                myCommand.Parameters.Add(createdDate);

                int notifyId = (int)myCommand.ExecuteScalar();

                int ChannelDeviceID1 = GetChannelDevice(((ChannelModel)cbKenh.SelectedValue).ID, (int)cbDevice.SelectedValue, 8);

                TrackingChannelDevice(ChannelDeviceID1, float.Parse(txtLowApLuc.Text), float.Parse(txtHighApLuc.Text), notifyId);

                int ChannelDeviceID2 = GetChannelDevice(((ChannelModel)cbKenh.SelectedValue).ID, (int)cbDevice.SelectedValue, 9);

                TrackingChannelDevice(ChannelDeviceID2, float.Parse(txtLowLuuLuong.Text), float.Parse(txtHighLuuLuong.Text), notifyId);

                int ChannelDeviceID3 = GetChannelDevice(((ChannelModel)cbKenh.SelectedValue).ID, (int)cbDevice.SelectedValue, 10);

                TrackingChannelDevice(ChannelDeviceID3, float.Parse(txtLowBattery.Text), float.Parse(txtHighBattery.Text), notifyId);

                MessageBox.Show("Thêm sự kiện thành công", "Thông báo");
                clearData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrackingChannelDevice(int ChannelDeviceID1, float p1, float p2, int notifyId)
        {
            SqlCommand myCommand = new SqlCommand(" INSERT TrackingChannelDevice (ChannelDeviceID,  High, Low, CreatedDate) OUTPUT Inserted.ID  VALUES (@ChannelDeviceID,  @High, @Low, @CreatedDate) ");
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            myCommand.Connection = con;

            SqlParameter channelDevice = new SqlParameter("@ChannelDeviceID", SqlDbType.Int);
            SqlParameter low = new SqlParameter("@High", SqlDbType.Float);
            SqlParameter high = new SqlParameter("@Low", SqlDbType.Float);
            SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

            channelDevice.Value = ChannelDeviceID1;
            low.Value = p1;
            high.Value = p2;
            createdDate.Value = DateTime.Now;

            myCommand.Parameters.Add(channelDevice);
            myCommand.Parameters.Add(low);
            myCommand.Parameters.Add(high);
            myCommand.Parameters.Add(createdDate);

            int TrackingChannelDeviceID = (int)myCommand.ExecuteScalar();

            TrackingNotify(TrackingChannelDeviceID, notifyId);
        }

        private void TrackingNotify(int TrackingChannelDeviceID, int notifyId)
        {
            SqlCommand myCommand = new SqlCommand(" INSERT TrackingNotify (NotifyId,  TrackingChannelDeviceID)  VALUES (@NotifyId,  @TrackingChannelDeviceID) ");
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            myCommand.Connection = con;

            SqlParameter noId = new SqlParameter("@NotifyId", SqlDbType.Int);
            SqlParameter trackId = new SqlParameter("@TrackingChannelDeviceID", SqlDbType.Int);

            noId.Value = TrackingChannelDeviceID;
            trackId.Value = notifyId;

            myCommand.Parameters.Add(noId);
            myCommand.Parameters.Add(trackId);

           myCommand.ExecuteNonQuery();
        }

        private void TrackingChannelDevice(int ChannelDeviceID1)
        {
            throw new NotImplementedException();
        }

        

        private void clearData() {
            txtId.Clear();
            txtName.Clear();
            txtLowApLuc.Clear();
            txtLowApLuc.Clear();
            txtLowApLuc.Clear();
            txtHighApLuc.Clear();
            txtHighLuuLuong.Clear();
            txtHighBattery.Clear();
        }

        private void GetDevice()
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(cs);
            StringBuilder sql = new StringBuilder("select d.ID, d.Name from Device d ");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DeviceDataSet = new DataSet();
            try
            {
                conn.Open();
                da.Fill(DeviceDataSet, "Device");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void grpDetails_Enter(object sender, EventArgs e)
        {

        }

        private void rdActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdInactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class TypeAlertModel
    {
        /// <summary>
        /// Channel model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="display"></param>
        public TypeAlertModel(int id, string display)
        {
            ID = id;
            Display = display;
        }

        /// <summary>
        /// Identity
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Display
        /// </summary>
        public string Display { get; set; }
    }
}
