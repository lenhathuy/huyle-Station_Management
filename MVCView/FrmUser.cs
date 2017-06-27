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
        SqlConnection con;
        int ID = 0; 
        private void FrmUser_Load(object sender, EventArgs e)
        {            
                con = new SqlConnection(cs);
                disable();
                loadRole();
                loadUser();

                dgvList.Columns[0].HeaderText = "ID";
                dgvList.Columns[1].HeaderText = "Tên người dùng";
                dgvList.Columns[3].HeaderText = "Họ";
                dgvList.Columns[4].HeaderText = "Tên";
                dgvList.Columns[5].HeaderText = "Email";
                dgvList.Columns[6].HeaderText = "Quyền";
                dgvList.Columns[7].HeaderText = "Ngày tạo";
        }

        private void loadUser()
        {
            StringBuilder mySql = new StringBuilder(" SELECT u.UserID, u.UserName, u.Password, u.FirstName, u.LastName, u.email, r.name, u.createdDate  ");
            mySql.Append(" FROM USERS u ");
            mySql.Append(" LEFT JOIN ROLE r ON r.ROLEID = u.ROLEID ");
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
            finally {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            // Build the SQL string
            dgvList.DataSource = dt;
            BindingSource bs = new BindingSource();
            DataSet dset = new DataSet();
            da.Fill(dset);
            bs = new BindingSource();
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;

            dgvList.Columns["Password"].Visible = false;
            dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

         

        private void loadRole()
        {
            try
            {                
                string sql = "select RoleID, Name from Role ";
                SqlCommand query = new SqlCommand(sql);
                query.Connection = con;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query);       
                DataSet ds = new DataSet();
                da.Fill(ds, "Role");
                cbRole.DisplayMember = "Name";
                cbRole.ValueMember = "RoleID";
                cbRole.DataSource = ds.Tables["Role"];
                con.Close();
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

        private void disable() {
            clearText();
            txtUserName.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtPassword.Enabled = false;
            txtEmail.Enabled = false;
            txtRePassword.Enabled = false;
        }

        private void enable()
        {
            txtUserName.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPassword.Enabled = true;
            txtEmail.Enabled = true;
            txtRePassword.Enabled = true;
        }

        private void clearText()
        {
            txtUserName.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtId.Clear();
            txtRePassword.Clear();
            ID = 0;
        }
      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateData())
                {
                    if (txtId.Text != "")
                    {
                        EditUser();
                    }
                    else {
                        //clearText();
                        //enable();
                        AddUser();
                        disable();
                    }
                    
                    loadUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EditUser()
        {
            SqlCommand myCommand = new SqlCommand(" UPDATE Users Set UserName = @UserName, FirstName = @FirstName, LastName = @LastName, Email = @Email, RoleId = @RoleId Where UserId = @UserId");
            myCommand.Connection = con;
            con.Open();

            SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
            SqlParameter fName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            SqlParameter lName = new SqlParameter("@LastName", SqlDbType.VarChar);
            SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar);
            SqlParameter userId = new SqlParameter("@UserId", SqlDbType.Int);
            SqlParameter roleId = new SqlParameter("@RoleId", SqlDbType.Int);

            uName.Value = txtUserName.Text;
            fName.Value = txtFirstName.Text;
            lName.Value = txtLastName.Text;
            email.Value = txtEmail.Text;
            roleId.Value = cbRole.SelectedValue;
            userId.Value = Int32.Parse(txtId.Text);

            myCommand.Parameters.Add(uName);
            myCommand.Parameters.Add(fName);
            myCommand.Parameters.Add(lName);
            myCommand.Parameters.Add(email);
            myCommand.Parameters.Add(userId);
            myCommand.Parameters.Add(roleId);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sửa User thành công", "Thông báo");
        }

        private void AddUser()
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO Users (UserName, Password, FirstName, LastName, Email, CreatedDate, ROLEID)  VALUES (@UserName, @Password, @FirstName, @LastName, @Email, @CreatedDate, @ROLEID) ");
            myCommand.Connection = con;
            con.Open();

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
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm User thành công", "Thông báo");
        }

        private bool validateData()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter first name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return false;
            }
            if (txtId.Text == "") {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return false;
                }
                if (txtRePassword.Text == "")
                {
                    MessageBox.Show("Please enter Re-password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRePassword.Focus();
                    return false;
                }
                if (txtRePassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Password & Repassword not equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRePassword.Focus();
                    return false;
                }
            }
           
            return true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            try
            {
                clearText();
                enable();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearText();
            disable();
        }

        private void editIcon_Click(object sender, EventArgs e)
        {
            try
            {
                enable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delIcon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete record?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ID > 0)
                {
                    SqlCommand cmd = new SqlCommand("delete Users where ID=@id", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!");  
                }
                else {
                    MessageBox.Show("Please Select Record to Delete");
                }
            }
          
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.dgvList.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtUserName.Text = row.Cells[1].Value.ToString();
                txtPassword.Text = row.Cells[2].Value.ToString();
                txtFirstName.Text = row.Cells[3].Value.ToString();
                txtLastName.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
