using MVCView.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MVCView
{
    public partial class FrmStation : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmStation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constant for page size
        /// </summary>
        public const int pageSize = 10;

        /// <summary>
        /// Total records
        /// </summary>
        private int _totalRecords;

        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        /// <summary>
        /// Source data
        /// </summary>
        private List<StationViewModel> sourceData = new List<StationViewModel>();

   

        /// <summary>
        /// Frame station load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStation_Load(object sender, EventArgs e)
        {
            GetStation(string.Empty);        
        }

        private void stationCurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset   
            int offset = (int)bsStation.Current;

            var records = new List<StationViewModel>();
            for (int i = offset; i < offset + pageSize && i < _totalRecords; i++)
            {
                records.Add(sourceData[i]);
            }

            grvStation.DataSource = records;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //if (!grvStation.CurrentRow.Selected)
            //{
            //    grvStation.CancelEdit();
            //}
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFind.Text))
            {
                return;
            }

            GetStation(txtFind.Text);
        }

        public void GetStation(string searchText)
        {
            sourceData.Clear();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("spGetStation", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@SearchText", SqlDbType.VarChar, 500).Value = searchText;
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
                //totalRecords = dtSource.Rows.Count;  
                foreach (DataRow item in dataTable.Rows)
                {
                    var station = new StationViewModel
                    {
                        Group = item["Group"].ToString(),
                        GroupID = int.Parse(item["GroupID"].ToString()),
                        StationCode = item["StationCode"].ToString(),
                        StationName = item["StationName"].ToString(),
                        StationLocation = item["StationLocation"].ToString(),
                        StationLatitude = float.Parse(item["StationLatitude"].ToString()),
                        StationLongtitude = float.Parse(item["StationLongtitude"].ToString()),
                        StationID = int.Parse(item["StationID"].ToString()),
                        kvID = item["kvID"].ToString()
                    };

                    sourceData.Add(station);
                }
            }

            _totalRecords = sourceData.Count;
            navigator.BindingSource = bsStation;
            bsStation.DataSource = dataTable;
            grvStation.DataSource = bsStation;

            grvStation.Columns[0].HeaderText = "ID";
            grvStation.Columns[1].HeaderText = "Mã trạm";
            grvStation.Columns[2].HeaderText = "Tên trạm";
            grvStation.Columns[3].HeaderText = "Group";
            grvStation.Columns[6].HeaderText = "Khu vực";
            grvStation.Columns[7].HeaderText = "Vị trí";
            grvStation.Columns[8].HeaderText = "Lat";
            grvStation.Columns[9].HeaderText = "Lng";
            grvStation.Columns[10].HeaderText = "Áp lực";
            grvStation.Columns[11].HeaderText = "Lưu lượng";
            grvStation.Columns[12].HeaderText = "Battery";

            grvStation.Columns["GroupID"].Visible = false;
            grvStation.Columns["kvID"].Visible = false;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            grvStation.Columns.Add(btn);
            btn.Text = "Chỉnh sửa";
            btn.DefaultCellStyle.ForeColor = System.Drawing.Color.Green;
            btn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            grvStation.Columns.Add(btnDelete);
            btnDelete.Text = "Xóa";
            btnDelete.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
            btnDelete.UseColumnTextForButtonValue = true;
            //bsStation.CurrentChanged += new EventHandler(stationCurrentChanged);
            //bsStation.DataSource = new PageOffsetList(pageSize, _totalRecords);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void grvStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                FrmDetailStation frm = new FrmDetailStation(sourceData[e.RowIndex], this);
                frm.Show();
            }
            else if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeleteStationDevice(sourceData[e.RowIndex].StationID);
                    DeleteStationChannelDevice(sourceData[e.RowIndex].StationID);
                    DeleteStation(sourceData[e.RowIndex].StationID);
                    MessageBox.Show("Record Deleted Successfully!");
                }
            }
        }

        private void DeleteStation(int stationId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("delete Station where ID=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", stationId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void DeleteStationChannelDevice(int stationId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("delete from StationDeviceChannel where StationID = @StationID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@StationID", stationId);
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void DeleteStationDevice(int stationId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("delete from StationDevice where StationID = @StationID", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@StationID", stationId);
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDetailStation frm = new FrmDetailStation(new StationViewModel(), this);
            frm.Show();
        }
    }
}
