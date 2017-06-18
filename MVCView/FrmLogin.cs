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
    public partial class FrmLogin : Form
    {
        private SqlConnection con; 


        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            try
            {
                connectDB();

                SqlCommand myCommand = new SqlCommand("SELECT Username,Password FROM Users WHERE UserName = @Username AND Password = @Password");
                myCommand.Connection = con;

                SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Password", SqlDbType.VarChar);

                uName.Value = txtUserName.Text;
                uPassword.Value = txtPassword.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);  

                //SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("You have logged in successfully " + txtUserName.Text);
                    //Hide the login form
                    Home frmHome = new Home();
                    frmHome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();

                }
                if (con.State == ConnectionState.Open)
                {
                    con.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
