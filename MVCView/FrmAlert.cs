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
    public partial class FrmAlert : Form
    {
        public FrmAlert()
        {
            InitializeComponent();
        }

        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        private SqlConnection con;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(" INSERT Notify (FLow, Pressure, Battery, CreatedDate)  VALUES (@FLow, @Pressure, @Battery, @CreatedDate) ");
                myCommand.Connection = con;

                SqlParameter flow = new SqlParameter("@FLow", SqlDbType.Float);
                SqlParameter pressure = new SqlParameter("@Pressure", SqlDbType.Float);
                SqlParameter bat = new SqlParameter("@Battery", SqlDbType.Float);
                SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                flow.Value = txtFlow.Text;
                pressure.Value = txtPressure.Text;
                bat.Value = txtBattery.Text;
                createdDate.Value = DateTime.Now;


                myCommand.Parameters.Add(flow);
                myCommand.Parameters.Add(pressure);
                myCommand.Parameters.Add(bat);
                myCommand.Parameters.Add(createdDate);

                myCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }      

        private void FrmAlert_Load(object sender, EventArgs e)
        {
            connectDB();
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
    }
}
