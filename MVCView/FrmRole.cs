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
    public partial class FrmRole : Form
    {
        public FrmRole()
        {
            InitializeComponent();
        }

        string cs = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;
        SqlConnection con;

        private void FrmRole_Load(object sender, EventArgs e)
        {
            loadUser();
            dgvList.Columns[0].HeaderText = "ID";
            dgvList.Columns[1].HeaderText = "Mã quyền";
            dgvList.Columns[3].HeaderText = "Tên quyền";
        }

        private void loadUser()
        {
            StringBuilder mySql = new StringBuilder(" SELECT u.RoleID, u.code, u.name  ");
            mySql.Append(" FROM Role u ");
            con = new SqlConnection(cs);
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
            finally
            {
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

            //dgvList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void EditUser()
        {
            SqlCommand myCommand = new SqlCommand(" UPDATE Users Set name = @name, code = @code Where roleId = @RoleId");
            myCommand.Connection = con;
            con.Open();

   
            SqlParameter roleId = new SqlParameter("@RoleId", SqlDbType.Int);
            roleId.Value = Int32.Parse(txtId.Text);

            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
            SqlParameter code = new SqlParameter("@code", SqlDbType.VarChar);

            name.Value = txtName.Text;
            code.Value = txtCode.Text;


            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(code);
            myCommand.Parameters.Add(roleId);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sửa quyền thành công", "Thông báo");
        }

        private void AddUser()
        {
            SqlCommand myCommand = new SqlCommand(" INSERT INTO Role (Name, Code)  VALUES (@name, @code) ");
            myCommand.Connection = con;
            con.Open();

            SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar);
            SqlParameter code = new SqlParameter("@code", SqlDbType.VarChar);

            name.Value = txtName.Text;
            code.Value = txtCode.Text;


            myCommand.Parameters.Add(name);
            myCommand.Parameters.Add(code);
            myCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm quyền thành công", "Thông báo");
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvList.Rows[e.RowIndex];
                txtId.Text = row.Cells[0].Value.ToString();
                txtCode.Text = row.Cells[1].Value.ToString();
                txtName.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                EditUser();
            }
            else
            {
                //clearText();
                //enable();
                AddUser();
                disable();
            }

            loadUser();
        }

        private void disable()
        {
            txtId.Clear();
            txtName.Clear();
            txtCode.Clear();
            txtName.Enabled = false;
            txtCode.Enabled = false;
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtCode.Clear();
            txtName.Enabled = true;
            txtCode.Enabled = true;
        }

    }
}
