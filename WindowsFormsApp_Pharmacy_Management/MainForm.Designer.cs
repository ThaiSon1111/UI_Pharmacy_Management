
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.tsmi_System = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_ActInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_System_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_CustomerManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_SalesManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoTàiChínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
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
            this.trợGiúpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(2442, 54);
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
            this.tsmi_System.Name = "tsmi_System";
            this.tsmi_System.Size = new System.Drawing.Size(106, 29);
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
            this.tsmi_System_Logout.Name = "tsmi_System_Logout";
            this.tsmi_System_Logout.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_Logout.Text = "Đăng xuất";
            this.tsmi_System_Logout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // tsmi_System_ChangePassword
            // 
            this.tsmi_System_ChangePassword.Name = "tsmi_System_ChangePassword";
            this.tsmi_System_ChangePassword.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_ChangePassword.Text = "Đổi mật khẩu";
            this.tsmi_System_ChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // tsmi_System_ActInfo
            // 
            this.tsmi_System_ActInfo.Name = "tsmi_System_ActInfo";
            this.tsmi_System_ActInfo.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_ActInfo.Text = "Thông tin tài khoản";
            this.tsmi_System_ActInfo.Click += new System.EventHandler(this.tsmiActInfo_Click);
            // 
            // tsmi_System_Exit
            // 
            this.tsmi_System_Exit.Name = "tsmi_System_Exit";
            this.tsmi_System_Exit.Size = new System.Drawing.Size(268, 34);
            this.tsmi_System_Exit.Text = "Thoát";
            this.tsmi_System_Exit.Click += new System.EventHandler(this.tsmi_System_Exit_Click);
            // 
            // tsmi_CustomerManagement
            // 
            this.tsmi_CustomerManagement.Name = "tsmi_CustomerManagement";
            this.tsmi_CustomerManagement.Size = new System.Drawing.Size(207, 29);
            this.tsmi_CustomerManagement.Text = "Thông Tin Khách Hàng";
            this.tsmi_CustomerManagement.Click += new System.EventHandler(this.tsmi_CustomerManagement_Click);
            // 
            // tsmi_SalesManagement
            // 
            this.tsmi_SalesManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sanToolStripMenuItem,
            this.đơnHàngToolStripMenuItem,
            this.nhậpKhoToolStripMenuItem});
            this.tsmi_SalesManagement.Name = "tsmi_SalesManagement";
            this.tsmi_SalesManagement.Size = new System.Drawing.Size(174, 48);
            this.tsmi_SalesManagement.Text = "Quản Lý Bán Hàng";
            this.tsmi_SalesManagement.Click += new System.EventHandler(this.tsmi_SalesManagement_Click);
            // 
            // quảnLýKhoToolStripMenuItem
            // 
            this.quảnLýKhoToolStripMenuItem.Name = "quảnLýKhoToolStripMenuItem";
            this.quảnLýKhoToolStripMenuItem.Size = new System.Drawing.Size(128, 29);
            this.quảnLýKhoToolStripMenuItem.Text = "Quản Lý Kho";
            // 
            // báoCáoTàiChínhToolStripMenuItem
            // 
            this.báoCáoTàiChínhToolStripMenuItem.Name = "báoCáoTàiChínhToolStripMenuItem";
            this.báoCáoTàiChínhToolStripMenuItem.Size = new System.Drawing.Size(169, 29);
            this.báoCáoTàiChínhToolStripMenuItem.Text = "Báo Cáo Tài Chính";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // sanToolStripMenuItem
            // 
            this.sanToolStripMenuItem.Name = "sanToolStripMenuItem";
            this.sanToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sanToolStripMenuItem.Text = "Sản phẩm";
            // 
            // đơnHàngToolStripMenuItem
            // 
            this.đơnHàngToolStripMenuItem.Name = "đơnHàngToolStripMenuItem";
            this.đơnHàngToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.đơnHàngToolStripMenuItem.Text = "Đơn hàng";
            // 
            // nhậpKhoToolStripMenuItem
            // 
            this.nhậpKhoToolStripMenuItem.Name = "nhậpKhoToolStripMenuItem";
            this.nhậpKhoToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nhậpKhoToolStripMenuItem.Text = "Nhập kho";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 878);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Management System";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
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
    }
}

