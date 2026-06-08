
namespace WindowsFormsApp_Pharmacy_Management
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmi_System = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_ActInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CustomerManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SalesManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.sanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTàiChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_System,
            this.tsmi_CustomerManagement,
            this.tsmi_SalesManagement,
            this.quảnLýKhoToolStripMenuItem,
            this.báoCáoTàiChínhToolStripMenuItem,
            this.báoCáoHệThốngToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(2314, 36);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // tsmi_System
            // 
            this.tsmi_System.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_System_Login,
            this.tsmi_System_Logout,
            this.tsmi_System_ChangePassword,
            this.tsmi_System_ActInfo,
            this.tsmi_System_Exit});
            this.tsmi_System.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_system;
            this.tsmi_System.Name = "tsmi_System";
            this.tsmi_System.Size = new System.Drawing.Size(130, 30);
            this.tsmi_System.Text = "Hệ Thống";
            this.tsmi_System.Click += new System.EventHandler(this.hệThốngToolStripMenuItem_Click);
            // 
            // tsmi_System_Login
            // 
            this.tsmi_System_Login.Name = "tsmi_System_Login";
            this.tsmi_System_Login.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_Login.Text = "Đăng nhập";
            // 
            // tsmi_System_Logout
            // 
            this.tsmi_System_Logout.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_System_Logout.Image")));
            this.tsmi_System_Logout.Name = "tsmi_System_Logout";
            this.tsmi_System_Logout.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_Logout.Text = "Đăng xuất";
            this.tsmi_System_Logout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // tsmi_System_ChangePassword
            // 
            this.tsmi_System_ChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_System_ChangePassword.Image")));
            this.tsmi_System_ChangePassword.Name = "tsmi_System_ChangePassword";
            this.tsmi_System_ChangePassword.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_ChangePassword.Text = "Đổi mật khẩu";
            this.tsmi_System_ChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // tsmi_System_ActInfo
            // 
            this.tsmi_System_ActInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_System_ActInfo.Image")));
            this.tsmi_System_ActInfo.Name = "tsmi_System_ActInfo";
            this.tsmi_System_ActInfo.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_ActInfo.Text = "Thông tin tài khoản";
            this.tsmi_System_ActInfo.Click += new System.EventHandler(this.tsmiActInfo_Click);
            // 
            // tsmi_System_Exit
            // 
            this.tsmi_System_Exit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_System_Exit.Image")));
            this.tsmi_System_Exit.Name = "tsmi_System_Exit";
            this.tsmi_System_Exit.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_Exit.Text = "Thoát";
            this.tsmi_System_Exit.Click += new System.EventHandler(this.tsmi_System_Exit_Click);
            // 
            // tsmi_CustomerManagement
            // 
            this.tsmi_CustomerManagement.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_customer;
            this.tsmi_CustomerManagement.Name = "tsmi_CustomerManagement";
            this.tsmi_CustomerManagement.Size = new System.Drawing.Size(231, 30);
            this.tsmi_CustomerManagement.Text = "Thông Tin Khách Hàng";
            this.tsmi_CustomerManagement.Click += new System.EventHandler(this.tsmi_CustomerManagement_Click);
            // 
            // tsmi_SalesManagement
            // 
            this.tsmi_SalesManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sanToolStripMenuItem,
            this.đơnHàngToolStripMenuItem,
            this.nhậpKhoToolStripMenuItem});
            this.tsmi_SalesManagement.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_sales_mng;
            this.tsmi_SalesManagement.Name = "tsmi_SalesManagement";
            this.tsmi_SalesManagement.Size = new System.Drawing.Size(198, 30);
            this.tsmi_SalesManagement.Text = "Quản Lý Bán Hàng";
            this.tsmi_SalesManagement.Click += new System.EventHandler(this.tsmi_SalesManagement_Click);
            // 
            // sanToolStripMenuItem
            // 
            this.sanToolStripMenuItem.Name = "sanToolStripMenuItem";
            this.sanToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.sanToolStripMenuItem.Text = "Sản phẩm";
            // 
            // đơnHàngToolStripMenuItem
            // 
            this.đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            this.đơnHàngToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.đơnHàngToolStripMenuItem.Text = "Đơn hàng";
            // 
            // nhậpKhoToolStripMenuItem
            // 
            this.nhậpKhoToolStripMenuItem.Name = "nhậpKhoToolStripMenuItem";
            this.nhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(194, 34);
            this.nhậpKhoToolStripMenuItem.Text = "Nhập kho";
            // 
            // quảnLýKhoToolStripMenuItem
            // 
            this.quảnLýKhoToolStripMenuItem.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_stock;
            this.quảnLýKhoToolStripMenuItem.Name = "quảnLýKhoToolStripMenuItem";
            this.quảnLýKhoToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.quảnLýKhoToolStripMenuItem.Text = "Quản Lý Kho";
            // 
            // báoCáoTàiChínhToolStripMenuItem
            // 
            this.báoCáoTàiChínhToolStripMenuItem.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_financial_report;
            this.báoCáoTàiChínhToolStripMenuItem.Name = "báoCáoTàiChínhToolStripMenuItem";
            this.báoCáoTàiChínhToolStripMenuItem.Size = new System.Drawing.Size(193, 30);
            this.báoCáoTàiChínhToolStripMenuItem.Text = "Báo Cáo Tài Chính";
            // 
            // báoCáoHệThốngToolStripMenuItem
            // 
            this.báoCáoHệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem});
            this.báoCáoHệThốngToolStripMenuItem.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_report_system;
            this.báoCáoHệThốngToolStripMenuItem.Name = "báoCáoHệThốngToolStripMenuItem";
            this.báoCáoHệThốngToolStripMenuItem.Size = new System.Drawing.Size(192, 30);
            this.báoCáoHệThốngToolStripMenuItem.Text = "Báo cáo hệ thống";
            // 
            // báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem
            // 
            this.báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem.Name = "báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem";
            this.báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem.Size = new System.Drawing.Size(419, 34);
            this.báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem.Text = "Báo cáo khách hàng mở tài khoản mới";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Image = global::WindowsFormsApp_Pharmacy_Management.Properties.Resources.menu_help_desk;
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(118, 30);
            this.trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2314, 1554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2314, 1590);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CustomerManagement;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SalesManagement;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoTàiChínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System_Login;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System_Logout;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System_ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System_ActInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_System_Exit;
        private System.Windows.Forms.ToolStripMenuItem sanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoKháchHàngMởTàiKhoảnMớiToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

