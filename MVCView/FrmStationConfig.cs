using MVCView.Common;
using MVCView.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MVCView
{
    public partial class FrmStationConfig : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmStationConfig()
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
        private List<StationValueViewModel> sourceData = new List<StationValueViewModel>();

        /// <summary>
        /// Total records
        /// </summary>
        private int _totalRecords;

        /// <summary>
        /// Frame station load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStationConfig_Load(object sender, EventArgs e)
        {
            GetStationValue(string.Empty);
        }

        private void stationCurrentChanged(object sender, EventArgs e)
        {
            // The desired page has changed, so fetch the page of records using the "Current" offset   
            int offset = (int)bsStation.Current;

            var records = new List<StationValueViewModel>();
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

            GetStationValue(txtFind.Text);
        }

        private void GetStationValue(string searchText)
        {
            sourceData.Clear();
            DataTable dataTable = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("spGetStationValue", con);
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
                    var station = new StationValueViewModel
                    {
                        Group = item["Group"].ToString(),
                        StationCode = item["StationCode"].ToString(),
                        StationName = item["StationName"].ToString(),
                        Channel = int.Parse(item["Channel"].ToString()),
                        Type = int.Parse(item["Type"].ToString()),
                        Value = int.Parse(item["Value"].ToString())
                    };

                    sourceData.Add(station);
                }
            }

            var dt = new DataTable();
            dt.Columns.Add("Group");
            dt.Columns.Add("StationCode");
            dt.Columns.Add("StationName");
            dt.Columns.Add("Channel1");
            dt.Columns.Add("Channel2");
            dt.Columns.Add("Channel3");
            dt.Columns.Add("Channel4");
            dt.Columns.Add("Channel5");
            dt.Columns.Add("Channel6");
            dt.Columns.Add("Channel7");
            dt.Columns.Add("Channel8");

            var data = sourceData.GroupBy(x => new { x.Group, x.StationCode, x.StationName }).Select(x => new
            {
                Group = x.Key.Group,
                StationCode = x.Key.StationCode,
                StationName = x.Key.StationName,
                Data = x.ToList()
            });

            foreach (var item in data)
            {
                var row = dt.NewRow();
                row["Group"] = item.Group;
                row["StationCode"] = item.StationCode;
                row["StationName"] = item.StationName;
                foreach (var d in item.Data)
                {
                    switch (d.Channel)
                    {
                        case 1:
                            var value1 = row["Channel1"].ToString();
                            if (string.IsNullOrEmpty(value1))
                            {
                                value1 += d.Value;
                            }
                            else
                            {
                                value1 += "/" + d.Value;
                            }
                            row["Channel1"] = value1;                            
                            break;
                        case 2:
                            var value2 = row["Channel2"].ToString();
                            if (string.IsNullOrEmpty(value2))
                            {
                                value2 += d.Value;
                            }
                            else
                            {
                                value2 += "/" + d.Value;
                            }
                            row["Channel2"] = value2;
                            break;
                        case 3:
                            var value3 = row["Channel3"].ToString();
                            if (string.IsNullOrEmpty(value3))
                            {
                                value3 += d.Value;
                            }
                            else
                            {
                                value3 += "/" + d.Value;
                            }
                            row["Channel3"] = value3;
                            break;
                        case 4:
                            var value4 = row["Channel4"].ToString();
                            if (string.IsNullOrEmpty(value4))
                            {
                                value4 += d.Value;
                            }
                            else
                            {
                                value4 += "/" + d.Value;
                            }
                            row["Channel4"] = value4;
                            break;
                        case 5:
                            var value5 = row["Channel5"].ToString();
                            if (string.IsNullOrEmpty(value5))
                            {
                                value5 += d.Value;
                            }
                            else
                            {
                                value5 += "/" + d.Value;
                            }
                            row["Channel5"] = value5;
                            break;
                        case 6:
                            var value6 = row["Channel6"].ToString();
                            if (string.IsNullOrEmpty(value6))
                            {
                                value6 += d.Value;
                            }
                            else
                            {
                                value6 += "/" + d.Value;
                            }
                            row["Channel6"] = value6;
                            break;
                        case 7:
                            var value7 = row["Channel7"].ToString();
                            if (string.IsNullOrEmpty(value7))
                            {
                                value7 += d.Value;
                            }
                            else
                            {
                                value7 += "/" + d.Value;
                            }
                            row["Channel7"] = value7;
                            break;
                        case 8:
                            var value8 = row["Channel8"].ToString();
                            if (string.IsNullOrEmpty(value8))
                            {
                                value8 += d.Value;
                            }
                            else
                            {
                                value8 += "/" + d.Value;
                            }
                            row["Channel8"] = value8;
                            break;
                    }
                }

                dt.Rows.Add(row);
            }

            _totalRecords = sourceData.Count;
            navigator.BindingSource = bsStation;
            bsStation.DataSource = dt;
            grvStation.DataSource = bsStation;
            //bsStation.CurrentChanged += new EventHandler(stationCurrentChanged);
            //bsStation.DataSource = new PageOffsetList(pageSize, _totalRecords);
        }
    }
}
