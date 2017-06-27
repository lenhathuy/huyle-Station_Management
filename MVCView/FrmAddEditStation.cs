using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MVCView
{
    public partial class FrmAddEditStation : Form
    {
        /// <summary>
        /// Device data set
        /// </summary>
        public DataSet DeviceDataSet { get; private set; }
        int stationId;

        /// <summary>
        /// Channel list
        /// </summary>
        public List<ChannelModel> ChannelList = new List<ChannelModel>()
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

        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        public FrmAddEditStation(int stationId)
        {
            this.stationId = stationId;
            InitializeComponent();
            var station = GetStationById(stationId);
            lblStationText.Text = station.Name;

            GetDevice(stationId);
            //GetChannelDevice(1, 1);

            cbxChannel1Type1.DataSource = InitializeChannelData();
            cbxChannel1Type1.DisplayMember = "Display";

            cbxChannel1Type2.DataSource = InitializeChannelData();
            cbxChannel1Type2.DisplayMember = "Display";

            cbxChannel1Type3.DataSource = InitializeChannelData();
            cbxChannel1Type3.DisplayMember = "Display";

            cbxChannel2Type1.DataSource = InitializeChannelData();
            cbxChannel2Type1.DisplayMember = "Display";

            cbxChannel2Type2.DataSource = InitializeChannelData();
            cbxChannel2Type2.DisplayMember = "Display";

            cbxChannel2Type3.DataSource = InitializeChannelData();
            cbxChannel2Type3.DisplayMember = "Display";

            cbxChannel3Type1.DataSource = InitializeChannelData();
            cbxChannel3Type1.DisplayMember = "Display";

            cbxChannel3Type2.DataSource = InitializeChannelData();
            cbxChannel3Type2.DisplayMember = "Display";

            cbxChannel3Type3.DataSource = InitializeChannelData();
            cbxChannel3Type3.DisplayMember = "Display";

            cbxChannel4Type1.DataSource = InitializeChannelData();
            cbxChannel4Type1.DisplayMember = "Display";

            cbxChannel4Type2.DataSource = InitializeChannelData();
            cbxChannel4Type2.DisplayMember = "Display";

            cbxChannel4Type3.DataSource = InitializeChannelData();
            cbxChannel4Type3.DisplayMember = "Display";

            cbxChannel5Type1.DataSource = InitializeChannelData();
            cbxChannel5Type1.DisplayMember = "Display";

            cbxChannel5Type2.DataSource = InitializeChannelData();
            cbxChannel5Type2.DisplayMember = "Display";

            cbxChannel5Type3.DataSource = InitializeChannelData();
            cbxChannel5Type3.DisplayMember = "Display";

            cbxChannel6Type1.DataSource = InitializeChannelData();
            cbxChannel6Type1.DisplayMember = "Display";

            cbxChannel6Type2.DataSource = InitializeChannelData();
            cbxChannel6Type2.DisplayMember = "Display";

            cbxChannel6Type3.DataSource = InitializeChannelData();
            cbxChannel6Type3.DisplayMember = "Display";

            cbxChannel7Type1.DataSource = InitializeChannelData();
            cbxChannel7Type1.DisplayMember = "Display";

            cbxChannel7Type2.DataSource = InitializeChannelData();
            cbxChannel7Type2.DisplayMember = "Display";

            cbxChannel7Type3.DataSource = InitializeChannelData();
            cbxChannel7Type3.DisplayMember = "Display";

            cbxChannel8Type1.DataSource = InitializeChannelData();
            cbxChannel8Type1.DisplayMember = "Display";

            cbxChannel8Type2.DataSource = InitializeChannelData();
            cbxChannel8Type2.DisplayMember = "Display";

            cbxChannel8Type3.DataSource = InitializeChannelData();
            cbxChannel8Type3.DisplayMember = "Display";

            cbxDevice1Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice1Type1.DisplayMember = "Name";
            cbxDevice1Type1.ValueMember = "ID";

            cbxDevice1Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice1Type2.DisplayMember = "Name";
            cbxDevice1Type2.ValueMember = "ID";

            cbxDevice1Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice1Type3.DisplayMember = "Name";
            cbxDevice1Type3.ValueMember = "ID";

            cbxDevice2Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice2Type1.DisplayMember = "Name";
            cbxDevice2Type1.ValueMember = "ID";

            cbxDevice2Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice2Type2.DisplayMember = "Name";
            cbxDevice2Type2.ValueMember = "ID";

            cbxDevice2Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice2Type3.DisplayMember = "Name";
            cbxDevice2Type3.ValueMember = "ID";

            cbxDevice3Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice3Type1.DisplayMember = "Name";
            cbxDevice3Type1.ValueMember = "ID";

            cbxDevice3Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice3Type2.DisplayMember = "Name";
            cbxDevice3Type2.ValueMember = "ID";

            cbxDevice3Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice3Type3.DisplayMember = "Name";
            cbxDevice3Type3.ValueMember = "ID";

            cbxDevice4Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice4Type1.DisplayMember = "Name";
            cbxDevice4Type1.ValueMember = "ID";

            cbxDevice4Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice4Type2.DisplayMember = "Name";
            cbxDevice4Type2.ValueMember = "ID";

            cbxDevice4Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice4Type3.DisplayMember = "Name";
            cbxDevice4Type3.ValueMember = "ID";

            cbxDevice5Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice5Type1.DisplayMember = "Name";
            cbxDevice5Type1.ValueMember = "ID";

            cbxDevice5Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice5Type2.DisplayMember = "Name";
            cbxDevice5Type2.ValueMember = "ID";

            cbxDevice5Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice5Type3.DisplayMember = "Name";
            cbxDevice5Type3.ValueMember = "ID";

            cbxDevice6Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice6Type1.DisplayMember = "Name";
            cbxDevice6Type1.ValueMember = "ID";

            cbxDevice6Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice6Type2.DisplayMember = "Name";
            cbxDevice6Type2.ValueMember = "ID";

            cbxDevice6Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice6Type3.DisplayMember = "Name";
            cbxDevice6Type3.ValueMember = "ID";

            cbxDevice7Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice7Type1.DisplayMember = "Name";
            cbxDevice7Type1.ValueMember = "ID";

            cbxDevice7Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice7Type2.DisplayMember = "Name";
            cbxDevice7Type2.ValueMember = "ID";

            cbxDevice7Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice7Type3.DisplayMember = "Name";
            cbxDevice7Type3.ValueMember = "ID";

            cbxDevice8Type1.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice8Type1.DisplayMember = "Name";
            cbxDevice8Type1.ValueMember = "ID";

            cbxDevice8Type2.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice8Type2.DisplayMember = "Name";
            cbxDevice8Type2.ValueMember = "ID";

            cbxDevice8Type3.DataSource = DeviceDataSet.Tables["StationDevice"].Copy();
            cbxDevice8Type3.DisplayMember = "Name";
            cbxDevice8Type3.ValueMember = "ID";
        }

        /// <summary>
        /// Get station by identity
        /// </summary>
        /// <param name="stationID"></param>
        private Station GetStationById(int stationID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            StringBuilder sql = new StringBuilder("select top 1 * from Station ");
            sql.Append("where ID = @stationID");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            SqlParameter name = cmd.Parameters.Add("@stationID", SqlDbType.Int);
            name.Value = stationID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DeviceDataSet = new DataSet();
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

            if (dataTable.Rows.Count > 0)
            { 
            
            
            }

            var row = dataTable.Rows[0];
            Station station = new Station();
            station.ID = Int32.Parse(row["ID"].ToString());
            station.Code = row["Code"].ToString();
            station.Name = row["Name"].ToString();
            station.Description = row["Description"].ToString();
            station.Status = row["Status"].ToString();
            station.Location = row["Location"].ToString();
            station.Lat = float.Parse(row["Lat"].ToString());
            station.Lng = float.Parse(row["Lng"].ToString());
            station.KV_ID = row["KV_ID"].ToString();
            station.StationGroupID = Int32.Parse(row["StationGroupID"].ToString());

            return station;
        }

        /// <summary>
        /// Get device
        /// </summary>
        /// <param name="stationID"></param>
        private void GetDevice(int stationID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            StringBuilder sql = new StringBuilder("select d.ID, d.Name from StationDevice s ");
            sql.Append("inner join Device d on s.DeviceID = d.ID ");
            sql.Append("where s.StationID = @stationID");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            SqlParameter station = cmd.Parameters.Add("@stationID", SqlDbType.Int);
            station.Value = stationID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DeviceDataSet = new DataSet();
            try
            {
                conn.Open();
                da.Fill(DeviceDataSet, "StationDevice");
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

        /// <summary>
        /// Save click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DeleteStationDeviceChannel(stationId);

            InsertStationDeviceChannel(stationId, cbxChannel1Type1, cbxDevice1Type1, 1, 8);
            InsertStationDeviceChannel(stationId, cbxChannel1Type2, cbxDevice1Type2, 1, 9);
            InsertStationDeviceChannel(stationId, cbxChannel1Type3, cbxDevice1Type3, 1, 10);

            InsertStationDeviceChannel(stationId, cbxChannel2Type1, cbxDevice2Type1, 2, 8);
            InsertStationDeviceChannel(stationId, cbxChannel2Type2, cbxDevice2Type2, 2, 9);
            InsertStationDeviceChannel(stationId, cbxChannel2Type3, cbxDevice2Type3, 2, 10);

            InsertStationDeviceChannel(stationId, cbxChannel3Type1, cbxDevice3Type1, 3, 8);
            InsertStationDeviceChannel(stationId, cbxChannel3Type2, cbxDevice3Type2, 3, 9);
            InsertStationDeviceChannel(stationId, cbxChannel3Type3, cbxDevice3Type3, 3, 10);

            InsertStationDeviceChannel(stationId, cbxChannel4Type1, cbxDevice4Type1, 4, 8);
            InsertStationDeviceChannel(stationId, cbxChannel4Type2, cbxDevice4Type2, 4, 9);
            InsertStationDeviceChannel(stationId, cbxChannel4Type3, cbxDevice4Type3, 4, 10);

            InsertStationDeviceChannel(stationId, cbxChannel5Type1, cbxDevice5Type1, 5, 8);
            InsertStationDeviceChannel(stationId, cbxChannel5Type2, cbxDevice5Type2, 5, 9);
            InsertStationDeviceChannel(stationId, cbxChannel5Type3, cbxDevice5Type3, 5, 10);

            InsertStationDeviceChannel(stationId, cbxChannel6Type1, cbxDevice6Type1, 6, 8);
            InsertStationDeviceChannel(stationId, cbxChannel6Type2, cbxDevice6Type2, 6, 9);
            InsertStationDeviceChannel(stationId, cbxChannel6Type3, cbxDevice6Type3, 6, 10);

            InsertStationDeviceChannel(stationId, cbxChannel7Type1, cbxDevice7Type1, 7, 8);
            InsertStationDeviceChannel(stationId, cbxChannel7Type2, cbxDevice7Type2, 7, 9);
            InsertStationDeviceChannel(stationId, cbxChannel7Type3, cbxDevice7Type3, 7, 10);

            InsertStationDeviceChannel(stationId, cbxChannel8Type1, cbxDevice8Type1, 8, 8);
            InsertStationDeviceChannel(stationId, cbxChannel8Type2, cbxDevice8Type2, 8, 9);
            InsertStationDeviceChannel(stationId, cbxChannel8Type3, cbxDevice8Type3, 8, 10);

            MessageBox.Show("Cấu hình thành công", "Thông báo");
        }

        private void DeleteStationDeviceChannel(int stationId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("delete from StationDeviceChannel where StationID = @StationID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@StationID", stationId);
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        /// <summary>
        /// Get channel device
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private int GetChannelDevice(int channelId, int deviceId, int type)
        {
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
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

        /// <summary>
        /// Insert station device channel
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="channel"></param>
        /// <param name="device"></param>
        /// <param name="channelNumber"></param>
        /// <param name="type"></param>
        private void InsertStationDeviceChannel(int stationId, ComboBox channel, ComboBox device, int channelNumber, int type)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            StringBuilder sql = new StringBuilder("INSERT INTO [dbo].[StationDeviceChannel]([ChannelDeviceID],[StationID],[Status],[TypeID],[CreatedDate],[ModifiedDate],[ChannelNo])");
            sql.Append("VALUES (@ChannelDeviceID,@StationID,@Status,@TypeID,GETDATE(),GETDATE(),@ChannelNo)");
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);

            SqlParameter channelDeviceID = cmd.Parameters.Add("@ChannelDeviceID", SqlDbType.Int);
            channelDeviceID.Value = GetChannelDevice(((ChannelModel)channel.SelectedItem).ID, (int)device.SelectedValue, type);
            SqlParameter stationID = cmd.Parameters.Add("@StationID", SqlDbType.Int);
            stationID.Value = stationId;
            SqlParameter status = cmd.Parameters.Add("@Status", SqlDbType.Bit);
            status.Value = 1;
            SqlParameter typeID = cmd.Parameters.Add("@TypeID", SqlDbType.Int);
            typeID.Value = type;
            SqlParameter channelNo = cmd.Parameters.Add("@ChannelNo", SqlDbType.Int);
            channelNo.Value = channelNumber;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
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

        /// <summary>
        /// Intialize channel data
        /// </summary>
        /// <returns></returns>
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
    }

    /// <summary>
    /// Channel model
    /// </summary>
    public class ChannelModel
    {
        /// <summary>
        /// Channel model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="display"></param>
        public ChannelModel(int id, string display)
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

    /// <summary>
    /// Station
    /// </summary>
    public class Station
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public string KV_ID { get; set; }
        public int StationGroupID { get; set; }
    }

    public enum Type
    {
        APLUC = 8,
        LUULUONG = 9,
        BATTERY = 10,
    }
}
