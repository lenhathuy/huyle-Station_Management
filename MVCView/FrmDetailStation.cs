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
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        StationViewModel station;
        public FrmDetailStation(StationViewModel station)
        {
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
                da.Fill(ds, "StationGroup");
                cbGroup.DisplayMember = "TENKV";
                cbKhuVuc.ValueMember = "ID";
                cbKhuVuc.DataSource = ds.Tables["StationGroup"];
                cbKhuVuc.SelectedValue = station.;
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
            if (cbGroup.SelectedValue == "")
            {
                MessageBox.Show("Please enter last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLng.Focus();
                return false;
            }

            return true;
        }

        private void Edit()
        {
            SqlCommand myCommand = new SqlCommand(" UPDATE Station Set Code = @Code, Name = @Name, Location = @Location, Lat = @Lat, Lng = @Lng, StaionGroupID = @StaionGroupID Where ID = @StationId");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            myCommand.Connection = con;

            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter location = new SqlParameter("@Location", SqlDbType.VarChar);
            SqlParameter lat = new SqlParameter("@Lat", SqlDbType.VarChar);
            SqlParameter lng = new SqlParameter("@Lng", SqlDbType.Int);
            SqlParameter stationGroupID = new SqlParameter("@StationGroupID", SqlDbType.Int);
            SqlParameter stationID = new SqlParameter("@StationID", SqlDbType.Int);

            code.Value = txtMaTram.Text;
            name.Value = txtTenTram.Text;
            location.Value = txtLocation.Text;
            lat.Value = int.Parse(txtLat.Text);
            lng.Value = int.Parse(txtLng.Text);
            stationGroupID.Value = cbGroup.SelectedValue;
            stationID.Value = station.StationID;

            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(location);
            myCommand.Parameters.Add(lat);
            myCommand.Parameters.Add(lng);
            myCommand.Parameters.Add(stationGroupID);
            myCommand.Parameters.Add(stationID);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sửa thành công", "Thông báo");
        }

        private void Add()
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO Users (UserName, Password, FirstName, LastName, Email, CreatedDate, ROLEID)  VALUES (@UserName, @Password, @FirstName, @LastName, @Email, @CreatedDate, @ROLEID) ");
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            myCommand.Connection = con;

            SqlParameter code = new SqlParameter("@Code", SqlDbType.VarChar);
            SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar);
            SqlParameter location = new SqlParameter("@Location", SqlDbType.VarChar);
            SqlParameter lat = new SqlParameter("@Lat", SqlDbType.VarChar);
            SqlParameter lng = new SqlParameter("@Lng", SqlDbType.Int);
            SqlParameter stationGroupID = new SqlParameter("@StationGroupID", SqlDbType.Int);

            code.Value = txtMaTram.Text;
            name.Value = txtTenTram.Text;
            location.Value = txtLocation.Text;
            lat.Value = int.Parse(txtLat.Text);
            lng.Value = int.Parse(txtLng.Text);
            stationGroupID.Value = cbGroup.SelectedValue;
            stationID.Value = station.StationID;

            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(location);
            myCommand.Parameters.Add(lat);
            myCommand.Parameters.Add(lng);
            myCommand.Parameters.Add(stationGroupID);
            myCommand.Parameters.Add(stationID);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
