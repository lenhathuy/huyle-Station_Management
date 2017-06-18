namespace MVCView.Metadta.Device
{
    partial class FrmDeviceList
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENKV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblDeviceCode = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý thiết bị";
            // 
            // dgvList
            // 
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TENTB,
            this.TENKV,
            this.status,
            this.Lat,
            this.Lng,
            this.action});
            this.dgvList.Location = new System.Drawing.Point(12, 240);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(786, 263);
            this.dgvList.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.HeaderText = "Mã TB";
            this.ID.Name = "ID";
            // 
            // TENTB
            // 
            this.TENTB.HeaderText = "Tên TB";
            this.TENTB.Name = "TENTB";
            // 
            // TENKV
            // 
            this.TENKV.HeaderText = "Tên KV";
            this.TENKV.Name = "TENKV";
            // 
            // status
            // 
            this.status.HeaderText = "Trạng Thái";
            this.status.Name = "status";
            // 
            // Lat
            // 
            this.Lat.HeaderText = "Latitude";
            this.Lat.Name = "Lat";
            // 
            // Lng
            // 
            this.Lng.HeaderText = "Longitude";
            this.Lng.Name = "Lng";
            // 
            // action
            // 
            this.action.HeaderText = "Thao tác";
            this.action.Name = "action";
            // 
            // gbSearch
            // 
            this.gbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.comboBox1);
            this.gbSearch.Controls.Add(this.lblStatus);
            this.gbSearch.Controls.Add(this.textBox2);
            this.gbSearch.Controls.Add(this.lblDeviceCode);
            this.gbSearch.Controls.Add(this.textBox1);
            this.gbSearch.Controls.Add(this.lblDeviceName);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 58);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(786, 133);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(323, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 37);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(121, 70);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(37, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 16);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Trạng thái";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(449, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(178, 23);
            this.textBox2.TabIndex = 1;
            // 
            // lblDeviceCode
            // 
            this.lblDeviceCode.AutoSize = true;
            this.lblDeviceCode.Location = new System.Drawing.Point(381, 25);
            this.lblDeviceCode.Name = "lblDeviceCode";
            this.lblDeviceCode.Size = new System.Drawing.Size(44, 16);
            this.lblDeviceCode.TabIndex = 0;
            this.lblDeviceCode.Text = "Mã KV";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 23);
            this.textBox1.TabIndex = 1;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Location = new System.Drawing.Point(37, 23);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(73, 16);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "Tên thiết bị";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(701, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 37);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmDeviceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 525);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.lblTitle);
            this.Name = "FrmDeviceList";
            this.Text = "FrmDeviceList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDeviceList_FormClosed);
            this.Load += new System.EventHandler(this.FrmDeviceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDeviceCode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TENKV;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lng;
        private System.Windows.Forms.DataGridViewTextBoxColumn action;
    }
}