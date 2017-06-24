namespace MVCView
{
    partial class Home
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
            this.menuHome = new System.Windows.Forms.MenuStrip();
            this.menuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMetadata_User = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMetadata_Device = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStationInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Tram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTram_MapView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTram_TableView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetting_Alert = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuHome
            // 
            this.menuHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDashboard,
            this.menuMetadata,
            this.menu_Tram,
            this.menuSetting});
            this.menuHome.Location = new System.Drawing.Point(0, 0);
            this.menuHome.Name = "menuHome";
            this.menuHome.Size = new System.Drawing.Size(720, 24);
            this.menuHome.TabIndex = 0;
            this.menuHome.Text = "menuHome";
            // 
            // menuDashboard
            // 
            this.menuDashboard.Name = "menuDashboard";
            this.menuDashboard.Size = new System.Drawing.Size(76, 20);
            this.menuDashboard.Text = "Dashboard";
            // 
            // menuMetadata
            // 
            this.menuMetadata.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMetadata_User,
            this.menuMetadata_Device,
            this.menuStationInfo});
            this.menuMetadata.Name = "menuMetadata";
            this.menuMetadata.Size = new System.Drawing.Size(122, 20);
            this.menuMetadata.Text = "Quản lý dữ liệu nền";
            // 
            // menuMetadata_User
            // 
            this.menuMetadata_User.Name = "menuMetadata_User";
            this.menuMetadata_User.Size = new System.Drawing.Size(180, 22);
            this.menuMetadata_User.Text = "Quản lý người dùng";
            this.menuMetadata_User.Click += new System.EventHandler(this.menuMetadata_User_Click);
            // 
            // menuMetadata_Device
            // 
            this.menuMetadata_Device.Name = "menuMetadata_Device";
            this.menuMetadata_Device.Size = new System.Drawing.Size(180, 22);
            this.menuMetadata_Device.Text = "Quản lý thiết bị";
            this.menuMetadata_Device.Click += new System.EventHandler(this.menuMetadata_Device_Click);
            // 
            // menuStationInfo
            // 
            this.menuStationInfo.Name = "menuStationInfo";
            this.menuStationInfo.Size = new System.Drawing.Size(180, 22);
            this.menuStationInfo.Text = "Cấu hình trạm";
            this.menuStationInfo.Click += new System.EventHandler(this.menuStationInfo_Click);
            // 
            // menu_Tram
            // 
            this.menu_Tram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTram_MapView,
            this.menuTram_TableView});
            this.menu_Tram.Name = "menu_Tram";
            this.menu_Tram.Size = new System.Drawing.Size(88, 20);
            this.menu_Tram.Text = "Quản lý trạm";
            // 
            // menuTram_MapView
            // 
            this.menuTram_MapView.Name = "menuTram_MapView";
            this.menuTram_MapView.Size = new System.Drawing.Size(203, 22);
            this.menuTram_MapView.Text = "Quản lý trạm trên đồ thị";
            this.menuTram_MapView.Click += new System.EventHandler(this.menuTram_MapView_Click);
            // 
            // menuTram_TableView
            // 
            this.menuTram_TableView.Name = "menuTram_TableView";
            this.menuTram_TableView.Size = new System.Drawing.Size(203, 22);
            this.menuTram_TableView.Text = "Quản lý trạm dạng bảng";
            this.menuTram_TableView.Click += new System.EventHandler(this.menuTram_TableView_Click);
            // 
            // menuSetting
            // 
            this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetting_Alert});
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Size = new System.Drawing.Size(154, 20);
            this.menuSetting.Text = "Quản lý sự kiện báo động";
            // 
            // menuSetting_Alert
            // 
            this.menuSetting_Alert.Name = "menuSetting_Alert";
            this.menuSetting_Alert.Size = new System.Drawing.Size(125, 22);
            this.menuSetting_Alert.Text = "Báo động";
            this.menuSetting_Alert.Click += new System.EventHandler(this.menuSetting_Alert_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 441);
            this.Controls.Add(this.menuHome);
            this.MainMenuStrip = this.menuHome;
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuHome.ResumeLayout(false);
            this.menuHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuHome;
        private System.Windows.Forms.ToolStripMenuItem menuDashboard;
        private System.Windows.Forms.ToolStripMenuItem menuMetadata;
        private System.Windows.Forms.ToolStripMenuItem menuMetadata_User;
        private System.Windows.Forms.ToolStripMenuItem menuMetadata_Device;
        private System.Windows.Forms.ToolStripMenuItem menuStationInfo;
        private System.Windows.Forms.ToolStripMenuItem menu_Tram;
        private System.Windows.Forms.ToolStripMenuItem menuTram_MapView;
        private System.Windows.Forms.ToolStripMenuItem menuTram_TableView;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ToolStripMenuItem menuSetting_Alert;
    }
}