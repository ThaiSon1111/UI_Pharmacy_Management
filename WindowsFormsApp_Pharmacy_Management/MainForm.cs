using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Pharmacy_Management
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Khởi tạo trạng thái menu: Mặc định là đã đăng nhập
            UpdateMenuState(true);
        }
        // Phương thức để quản lý trạng thái hiển thị của các mục menu
        public void UpdateMenuState(bool isLoggedIn)
        {
            // Nếu Đã đăng nhập (isLoggedIn = true)
            if (isLoggedIn)
            {
                // Ẩn mục "Đăng nhập"
                tsmi_System_Login.Visible = false;

                // Hiện các mục "Đăng xuất", "Đổi mật khẩu", v.v.
                tsmi_System_Logout.Visible = true;
                tsmi_System_ChangePassword.Visible = true;
                // ... (thêm các mục khác nếu cần)
            }
            else // Nếu Chưa đăng nhập (dùng cho chức năng Đăng xuất)
            {
                // Hiện mục "Đăng nhập"
                tsmi_System_Login.Visible = true;

                // Ẩn các mục "Đăng xuất", "Đổi mật khẩu", v.v.
                tsmi_System_Logout.Visible = false;
                tsmi_System_ChangePassword.Visible = false;
            }
        }
        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        // Xử lý Đăng xuất
        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            // ***** BƯỚC QUAN TRỌNG: Xóa trạng thái người dùng khi đăng xuất *****
            SessionManager.ClearUser();
            // *****************************************************************
            // 1. Ẩn MainForm hiện tại
            this.Hide();

            // 2. Mở lại LoginForm
            frm_login login = new frm_login();

            // Đóng MainForm khi LoginForm được mở và MainForm không còn cần thiết
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị Form Đổi Mật khẩu
    frm_chg_pwd changePassForm = new frm_chg_pwd();
    changePassForm.ShowDialog(); // Dùng ShowDialog() để chặn MainForm cho đến khi Form này đóng
        }

        private void tsmiActInfo_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị Form Thông tin tài khoản
            frm_user_info userInfoForm = new frm_user_info();
            userInfoForm.Show();
        }

        private void tsmi_CustomerManagement_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị Form Thông tin tài khoản
            frm_customer_info CustomerInfoForm = new frm_customer_info();
            CustomerInfoForm.Show();
        }

        private void tsmi_System_Exit_Click(object sender, EventArgs e)
        {
            // ***** BƯỚC QUAN TRỌNG: Xóa trạng thái người dùng khi đăng xuất *****
            SessionManager.ClearUser();
            this.Close();
        }

        private void tsmi_SalesManagement_Click(object sender, EventArgs e)
        {

        }
    }
}
