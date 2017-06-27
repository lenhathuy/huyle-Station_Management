using MVCView.ViewModel;
using System;
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
    public partial class FrmDetailStation : Form
    {
        FrmStation frmStation;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        StationViewModel station;
        public FrmDetailStation(StationViewModel station, FrmStation parentForm)
        {
            this.frmStation = parentForm;
            this.station = station;
            InitializeComponent();
        }


        private void FrmDetailStation_Load(object sender, EventArgs e)
        {
            txtMaTram.Text = station.StationCode;
            txtTenTram.Text = station.StationName;
            txtLocation.Text = station.StationLocation;
            txtLat.Text = station.StationLatitude.ToString();
            txtLng.Text = station.StationLongtitude.ToString() ;
            loadStationGroup();
            loadKhuVuc();
            cbChannel.DataSource = InitializeChannelData();
            cbChannel.DisplayMember = "Display";
            if (station.StationID > 0)
                loadDevice2Station();
        }

        private void loadStationGroup()
        {
            try
            {
                string sql = "select ID, Name from StationGroup ";
                SqlCommand query = new SqlCommand(sql);
                SqlConnection con = new SqlConnection(connectionString);
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds, "StationGroup");
                cbGroup.DisplayMember = "Name";
                cbGroup.ValueMember = "ID";
                cbGroup.DataSource = ds.Tables["StationGroup"];
                if (station.GroupID != null)
                    cbGroup.SelectedValue = station.GroupID;
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
            }
        }

        private void loadKhuVuc()
        {
            try
            {
                string sql = "select ID, TENKV from KHUVUC ";
                SqlCommand query = new SqlCommand(sql);
                SqlConnection con = new SqlConnection(connectionString);
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataSet ds = new DataSet();
                da.Fill(ds, "KHUVUC");
                cbKhuVuc.DisplayMember = "TENKV";
                cbKhuVuc.ValueMember = "ID";
                cbKhuVuc.DataSource = ds.Tables["KHUVUC"];
                if (station.kvID != null)
                    cbKhuVuc.SelectedValue = station.kvID;
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
            }
        }


        private void loadDevice2Station()
        {
            try
            {
                listView1.Items.Clear();
                SqlConnection con = new SqlConnection(connectionString);
                StringBuilder sql = new StringBuilder("select d.Name from Device d");
                sql.Append(" Where exists (select 1 from StationDevice sd where sd.deviceId = d.ID and sd.stationID = @stationID )");
                SqlCommand query = new SqlCommand(sql.ToString());
                SqlParameter stationID = new SqlParameter("@stationID", SqlDbType.Int);
                stationID.Value = station.StationID;
                query.Connection = con;
                query.Parameters.Add(stationID);
                SqlDataAdapter da = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["Name"].ToString();
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateData())
                {
                    if (station.StationID != null && station.StationID > 0)
                    {
                        Edit();
                    }
                    else
                    {
                        Add();
                    }
                    if(this.frmStation != null)
                        this.frmStation.GetStation(string.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validateData()
        {
            if (txtMaTram.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTram.Focus();
                return false;
            }
            if (txtTenTram.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTram.Focus();
                return false;
            }
            if (txtLat.Text == "")
            {
                MessageBox.Show("Please enter first name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLat.Focus();
                return false;
            }
            if (txtLng.Text == "")
            {
                MessageBox.Show("Please enter last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLng.Focus();
                return false;
            }
            if (cbGroup.SelectedText != "")
            {
                MessageBox.Show("Please enter last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLng.Focus();
                return false;
            }

            return true;
        }

        private void Edit()
        {
            SqlCommand myCommand = new SqlCommand(" UPDATE Station Set Code = @Code, Name = @Name, Location = @Location, Lat = @Lat, Lng = @Lng, StationGroupID = @StationGroupID, ChannelNoActive = @ChannelNoActive Where ID = @StationID");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            myCommand.Connection = con;

            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter location = new SqlParameter("@Location", SqlDbType.VarChar);
            SqlParameter lat = new SqlParameter("@Lat", SqlDbType.Float);
            SqlParameter lng = new SqlParameter("@Lng", SqlDbType.Float);
            SqlParameter stationGroupID = new SqlParameter("@StationGroupID", SqlDbType.Int);
            SqlParameter stationID = new SqlParameter("@StationID", SqlDbType.Int);
            SqlParameter ChannelNoActive = new SqlParameter("@ChannelNoActive", SqlDbType.Int);

            code.Value = txtMaTram.Text;
            name.Value = txtTenTram.Text;
            location.Value = txtLocation.Text;
            lat.Value = float.Parse(txtLat.Text);
            lng.Value = float.Parse(txtLng.Text);
            stationGroupID.Value = cbGroup.SelectedValue;
            stationID.Value = station.StationID;
            ChannelNoActive.Value = ((ChannelModel)cbChannel.SelectedItem).ID;

            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(location);
            myCommand.Parameters.Add(lat);
            myCommand.Parameters.Add(lng);
            myCommand.Parameters.Add(stationGroupID);
            myCommand.Parameters.Add(stationID);
            myCommand.Parameters.Add(ChannelNoActive);
            myCommand.ExecuteNonQuery();

            //updateChannelActive(station.StationID);
            con.Close();
            MessageBox.Show("Sửa thành công", "Thông báo");
        }

        private void Add()
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO Station (Code, Name, Location, Lat, Lng, Description, KV_ID, StationGroupID, Status, ChannelNoActive) OUTPUT Inserted.ID VALUES (@Code, @Name, @Location, @Lat, @Lng, @Description, @KV_ID, @StationGroupID, @Status, @ChannelNoActive) ");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            myCommand.Connection = con;

            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter location = new SqlParameter("@Location", SqlDbType.VarChar);
            SqlParameter description = new SqlParameter("@Description", SqlDbType.VarChar);
            SqlParameter lat = new SqlParameter("@Lat", SqlDbType.Float);
            SqlParameter lng = new SqlParameter("@Lng", SqlDbType.Float);
            SqlParameter stationGroupID = new SqlParameter("@StationGroupID", SqlDbType.Int);
            SqlParameter kvID = new SqlParameter("@KV_ID", SqlDbType.VarChar);
            SqlParameter status = new SqlParameter("@Status", SqlDbType.Int);
            SqlParameter ChannelNoActive = new SqlParameter("@ChannelNoActive", SqlDbType.Int);

            code.Value = txtMaTram.Text;
            name.Value = txtTenTram.Text;
            location.Value = txtLocation.Text;
            lat.Value = float.Parse(txtLat.Text);
            lng.Value = float.Parse(txtLng.Text);
            description.Value = txtDescription.Text;
            stationGroupID.Value = cbGroup.SelectedValue;
            kvID.Value = cbKhuVuc.SelectedValue;
            ChannelNoActive.Value = ((ChannelModel)cbChannel.SelectedItem).ID;
            status.Value = rdActive.Checked ? 1 : 0;

            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(location);
            myCommand.Parameters.Add(lat);
            myCommand.Parameters.Add(lng);
            myCommand.Parameters.Add(stationGroupID);
            myCommand.Parameters.Add(description);
            myCommand.Parameters.Add(kvID);
            myCommand.Parameters.Add(status);
            myCommand.Parameters.Add(ChannelNoActive);

            myCommand.ExecuteNonQuery();
            //updateChannelActive(idNew);
            con.Close();
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void updateChannelActive(int stationID)
        {
            SqlCommand myCommand = new SqlCommand(" UPDATE StationChannelDevive Set active = 1 Where ID = @StationID And ChannelNo = @ChannelNo ");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            myCommand.Connection = con;

            SqlParameter station = new SqlParameter("@StationID", SqlDbType.Int);
            SqlParameter channel = new SqlParameter("@ChannelNo", SqlDbType.Int);

            station.Value = stationID;
            channel.Value = cbChannel.SelectedValue;

            myCommand.Parameters.Add(station);
            myCommand.Parameters.Add(channel);

            myCommand.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
    }
}
