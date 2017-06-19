namespace MVCView
{
    partial class FrmUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.textUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.lblRePassword = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(627, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(97, 23);
            this.btnRemove.TabIndex = 37;
            this.btnRemove.Text = "&Remove User";
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.txtLastName);
            this.grpDetails.Controls.Add(this.lblLastName);
            this.grpDetails.Controls.Add(this.txtRePassword);
            this.grpDetails.Controls.Add(this.lblRePassword);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.lblPassword);
            this.grpDetails.Controls.Add(this.cbRole);
            this.grpDetails.Controls.Add(this.lblRole);
            this.grpDetails.Controls.Add(this.txtEmail);
            this.grpDetails.Controls.Add(this.label2);
            this.grpDetails.Controls.Add(this.txtUserName);
            this.grpDetails.Controls.Add(this.textUserName);
            this.grpDetails.Controls.Add(this.txtFirstName);
            this.grpDetails.Controls.Add(this.lblFirstName);
            this.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpDetails.Location = new System.Drawing.Point(12, 6);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(592, 180);
            this.grpDetails.TabIndex = 39;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Register new user :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(78, 136);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(186, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(9, 136);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(63, 23);
            this.lblFirstName.TabIndex = 19;
            this.lblFirstName.Text = "First Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(627, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 36;
            this.btnAdd.Text = "&Add New User";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(627, 135);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(97, 23);
            this.btnRegister.TabIndex = 38;
            this.btnRegister.Text = "&Register User";
            // 
            // textUserName
            // 
            this.textUserName.AutoSize = true;
            this.textUserName.Location = new System.Drawing.Point(9, 26);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(63, 13);
            this.textUserName.TabIndex = 29;
            this.textUserName.Text = "UserName :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(78, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(186, 20);
            this.txtUserName.TabIndex = 30;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(375, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 20);
            this.txtEmail.TabIndex = 32;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Email :";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(9, 102);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 13);
            this.lblRole.TabIndex = 33;
            this.lblRole.Text = "Role :";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(78, 99);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(186, 21);
            this.cbRole.TabIndex = 34;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(186, 20);
            this.txtPassword.TabIndex = 35;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(9, 61);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 23);
            this.lblPassword.TabIndex = 36;
            this.lblPassword.Text = "Password :";
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(375, 61);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(196, 20);
            this.txtRePassword.TabIndex = 37;
            // 
            // lblRePassword
            // 
            this.lblRePassword.Location = new System.Drawing.Point(293, 64);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(103, 23);
            this.lblRePassword.TabIndex = 38;
            this.lblRePassword.Text = "Re- Password :";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(375, 136);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(196, 20);
            this.txtLastName.TabIndex = 39;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(290, 139);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(63, 23);
            this.lblLastName.TabIndex = 40;
            this.lblLastName.Text = "Last Name:";
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(24, 217);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(928, 266);
            this.dgvList.TabIndex = 40;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 513);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRegister);
            this.Name = "FrmUser";
            this.Text = "FrmUser";
            this.Load += new System.EventHandler(this.FrmUser_Load);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.GroupBox grpDetails;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label lblFirstName;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnRegister;
        internal System.Windows.Forms.TextBox txtRePassword;
        internal System.Windows.Forms.Label lblRePassword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label textUserName;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.DataGridView dgvList;
    }
}