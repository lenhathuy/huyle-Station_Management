namespace MVCView.Metadta.Device
{
    partial class FrmEditDevice
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.lblRePassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.textUserName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.rdActive = new System.Windows.Forms.RadioButton();
            this.rdInactive = new System.Windows.Forms.RadioButton();
            this.lv1 = new System.Windows.Forms.ListView();
            this.lv2 = new System.Windows.Forms.ListView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lv2);
            this.groupBox2.Controls.Add(this.lv1);
            this.groupBox2.Location = new System.Drawing.Point(50, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 246);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trạm";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(127, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Thông tin chi tiết trạm : ...";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(187, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(315, 503);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.rdInactive);
            this.grpDetails.Controls.Add(this.rdActive);
            this.grpDetails.Controls.Add(this.dateTimePicker2);
            this.grpDetails.Controls.Add(this.dateTimePicker1);
            this.grpDetails.Controls.Add(this.lblRole);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.label2);
            this.grpDetails.Controls.Add(this.lblLastName);
            this.grpDetails.Controls.Add(this.txtRePassword);
            this.grpDetails.Controls.Add(this.lblRePassword);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.lblPassword);
            this.grpDetails.Controls.Add(this.txtUserName);
            this.grpDetails.Controls.Add(this.textUserName);
            this.grpDetails.Controls.Add(this.lblFirstName);
            this.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpDetails.Location = new System.Drawing.Point(50, 53);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(606, 180);
            this.grpDetails.TabIndex = 40;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Thông tin chung";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(89, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(186, 20);
            this.txtId.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "ID :";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(301, 103);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(79, 23);
            this.lblLastName.TabIndex = 40;
            this.lblLastName.Text = "Ngày lắp đặt :";
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(386, 61);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(196, 20);
            this.txtRePassword.TabIndex = 37;
            // 
            // lblRePassword
            // 
            this.lblRePassword.Location = new System.Drawing.Point(304, 64);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(103, 23);
            this.lblRePassword.TabIndex = 38;
            this.lblRePassword.Text = "Số Seri :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 61);
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
            this.lblPassword.Text = "Mã hiệu :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(386, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(196, 20);
            this.txtUserName.TabIndex = 30;
            // 
            // textUserName
            // 
            this.textUserName.AutoSize = true;
            this.textUserName.Location = new System.Drawing.Point(304, 22);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(66, 13);
            this.textUserName.TabIndex = 29;
            this.textUserName.Text = "Tên thiết bị :";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(9, 100);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(74, 23);
            this.lblFirstName.TabIndex = 19;
            this.lblFirstName.Text = "Ngày nhập :";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(9, 142);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(61, 13);
            this.lblRole.TabIndex = 45;
            this.lblRole.Text = "Trạng thái :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(386, 103);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker2.TabIndex = 48;
            // 
            // rdActive
            // 
            this.rdActive.AutoSize = true;
            this.rdActive.Checked = true;
            this.rdActive.Location = new System.Drawing.Point(89, 140);
            this.rdActive.Name = "rdActive";
            this.rdActive.Size = new System.Drawing.Size(76, 17);
            this.rdActive.TabIndex = 49;
            this.rdActive.TabStop = true;
            this.rdActive.Text = "Hoạt động";
            this.rdActive.UseVisualStyleBackColor = true;
            // 
            // rdInactive
            // 
            this.rdInactive.AutoSize = true;
            this.rdInactive.Location = new System.Drawing.Point(190, 142);
            this.rdInactive.Name = "rdInactive";
            this.rdInactive.Size = new System.Drawing.Size(108, 17);
            this.rdInactive.TabIndex = 50;
            this.rdInactive.TabStop = true;
            this.rdInactive.Text = "Không hoạt động";
            this.rdInactive.UseVisualStyleBackColor = true;
            // 
            // lv1
            // 
            this.lv1.Location = new System.Drawing.Point(59, 19);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(194, 221);
            this.lv1.TabIndex = 0;
            this.lv1.UseCompatibleStateImageBehavior = false;
            // 
            // lv2
            // 
            this.lv2.Location = new System.Drawing.Point(363, 19);
            this.lv2.Name = "lv2";
            this.lv2.Size = new System.Drawing.Size(191, 221);
            this.lv2.TabIndex = 1;
            this.lv2.UseCompatibleStateImageBehavior = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(265, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(266, 112);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // FrmEditDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 538);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmEditDevice";
            this.Text = "FrmEditDevice";
            this.groupBox2.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblLastName;
        internal System.Windows.Forms.TextBox txtRePassword;
        internal System.Windows.Forms.Label lblRePassword;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label textUserName;
        internal System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lv2;
        private System.Windows.Forms.ListView lv1;
        private System.Windows.Forms.RadioButton rdInactive;
        private System.Windows.Forms.RadioButton rdActive;
    }
}