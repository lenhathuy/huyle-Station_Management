﻿namespace MVCView.Metadta.Device
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lv2 = new System.Windows.Forms.ListView();
            this.lv1 = new System.Windows.Forms.ListView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.rdInactive = new System.Windows.Forms.RadioButton();
            this.rdActive = new System.Windows.Forms.RadioButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.lblSetupDate = new System.Windows.Forms.Label();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblReceipDate = new System.Windows.Forms.Label();
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
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(266, 112);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
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
            // lv2
            // 
            this.lv2.Location = new System.Drawing.Point(363, 19);
            this.lv2.Name = "lv2";
            this.lv2.Size = new System.Drawing.Size(191, 221);
            this.lv2.TabIndex = 1;
            this.lv2.UseCompatibleStateImageBehavior = false;
            // 
            // lv1
            // 
            this.lv1.Location = new System.Drawing.Point(59, 19);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(194, 221);
            this.lv1.TabIndex = 0;
            this.lv1.UseCompatibleStateImageBehavior = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblInfo.Location = new System.Drawing.Point(50, 13);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(199, 19);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Thông tin chi tiết trạm : ...";
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
            this.grpDetails.Controls.Add(this.lblStatus);
            this.grpDetails.Controls.Add(this.txtId);
            this.grpDetails.Controls.Add(this.lblId);
            this.grpDetails.Controls.Add(this.lblSetupDate);
            this.grpDetails.Controls.Add(this.txtRePassword);
            this.grpDetails.Controls.Add(this.lblSerial);
            this.grpDetails.Controls.Add(this.txtPassword);
            this.grpDetails.Controls.Add(this.lblCode);
            this.grpDetails.Controls.Add(this.txtUserName);
            this.grpDetails.Controls.Add(this.lblName);
            this.grpDetails.Controls.Add(this.lblReceipDate);
            this.grpDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpDetails.Location = new System.Drawing.Point(50, 53);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(606, 180);
            this.grpDetails.TabIndex = 40;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Thông tin chung";
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(386, 103);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(196, 20);
            this.dateTimePicker2.TabIndex = 48;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 97);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 47;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 13);
            this.lblStatus.TabIndex = 45;
            this.lblStatus.Text = "Trạng thái :";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(89, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(186, 20);
            this.txtId.TabIndex = 44;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 13);
            this.lblId.TabIndex = 43;
            this.lblId.Text = "ID :";
            // 
            // lblSetupDate
            // 
            this.lblSetupDate.Location = new System.Drawing.Point(301, 103);
            this.lblSetupDate.Name = "lblSetupDate";
            this.lblSetupDate.Size = new System.Drawing.Size(79, 23);
            this.lblSetupDate.TabIndex = 40;
            this.lblSetupDate.Text = "Ngày lắp đặt :";
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(386, 61);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '*';
            this.txtRePassword.Size = new System.Drawing.Size(196, 20);
            this.txtRePassword.TabIndex = 37;
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(304, 64);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(103, 23);
            this.lblSerial.TabIndex = 38;
            this.lblSerial.Text = "Số Seri :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(186, 20);
            this.txtPassword.TabIndex = 35;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(9, 61);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(80, 23);
            this.lblCode.TabIndex = 36;
            this.lblCode.Text = "Mã hiệu :";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(386, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(196, 20);
            this.txtUserName.TabIndex = 30;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(304, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 13);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "Tên thiết bị :";
            // 
            // lblReceipDate
            // 
            this.lblReceipDate.Location = new System.Drawing.Point(9, 100);
            this.lblReceipDate.Name = "lblReceipDate";
            this.lblReceipDate.Size = new System.Drawing.Size(74, 23);
            this.lblReceipDate.TabIndex = 19;
            this.lblReceipDate.Text = "Ngày nhập :";
            // 
            // FrmEditDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 538);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblInfo);
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

        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.GroupBox grpDetails;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.TextBox txtId;
        public System.Windows.Forms.Label lblId;
        public System.Windows.Forms.Label lblSetupDate;
        public System.Windows.Forms.TextBox txtRePassword;
        public System.Windows.Forms.Label lblSerial;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Label lblReceipDate;
        public System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.ListView lv2;
        public System.Windows.Forms.ListView lv1;
        public System.Windows.Forms.RadioButton rdInactive;
        public System.Windows.Forms.RadioButton rdActive;
    }
}