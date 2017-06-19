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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        //Connection String
        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        private SqlConnection con;

        private void FrmUser_Load(object sender, EventArgs e)
        {
            connectDB();
            loadRole();

        }

        private void loadRole()
        {
            try
            {                
                string sql = "select RoleID, Name from Role ";
                SqlCommand query = new SqlCommand(sql);
                query.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(query);       
                DataSet ds = new DataSet();
                da.Fill(ds, "Role");
                cbRole.DisplayMember = "Name";
                cbRole.ValueMember = "RoleID";
                cbRole.DataSource = ds.Tables["Role"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show("Error occured!");
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
      

        private void btnAdd_Click(object sender, EventArgs e)
        {

            SqlCommand myCommand = new SqlCommand(" INSERT Users (UserName, Password, FirstName, LastName, Email, CreatedDate, ROLEID)  VALUES (@UserName, @Password, @FirstName, @LastName, @Email, @CreatedDate, @ROLEID) ");
            myCommand.Connection = con;

            SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
            SqlParameter uPassword = new SqlParameter("@Password", SqlDbType.VarChar);
            SqlParameter fName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            SqlParameter lName = new SqlParameter("@LastName", SqlDbType.VarChar);
            SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar);
            SqlParameter createdDate = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
            SqlParameter roleId = new SqlParameter("@ROLEID", SqlDbType.Int);          

            uName.Value = txtUserName.Text;
            uPassword.Value = txtPassword.Text;
            fName.Value = txtFirstName.Text;
            lName.Value = txtLastName.Text;
            email.Value = txtEmail.Text;
            createdDate.Value = DateTime.Now;
            roleId.Value = cbRole.SelectedValue;

            myCommand.Parameters.Add(uName);
            myCommand.Parameters.Add(uPassword);
            myCommand.Parameters.Add(fName);
            myCommand.Parameters.Add(lName);
            myCommand.Parameters.Add(email);
            myCommand.Parameters.Add(createdDate);         
            myCommand.Parameters.Add(roleId);                    

            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
