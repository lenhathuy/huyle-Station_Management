using MVCView.Common;
using MVCView.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// The connection string
        /// </summary>
        private string connectionString = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        /// <summary>
        /// Source data
        /// </summary>
        private List<StationViewModel> sourceData = new List<StationViewModel>();

        /// <summary>
        /// Total records
        /// </summary>
        private int _totalRecords;

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
            if (!grvStation.CurrentRow.Selected)
            {
                grvStation.CancelEdit();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFind.Text))
            {
                return;
            }

            GetStation(txtFind.Text);
        }

        private void GetStation(string searchText)
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
                        StationCode = item["StationCode"].ToString(),
                        StationName = item["StationName"].ToString(),
                        StationLocation = item["StationLocation"].ToString(),
                        StationLatitude = float.Parse(item["StationLatitude"].ToString()),
                        StationLongtitude = float.Parse(item["StationLongtitude"].ToString())
                    };

                    sourceData.Add(station);
                }
            }

            _totalRecords = sourceData.Count;
            navigator.BindingSource = bsStation;
            bsStation.CurrentChanged += new EventHandler(stationCurrentChanged);
            bsStation.DataSource = new PageOffsetList(pageSize, _totalRecords);
        }
    }
}
