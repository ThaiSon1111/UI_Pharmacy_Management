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
                tsmiLogin.Visible = false;

                // Hiện các mục "Đăng xuất", "Đổi mật khẩu", v.v.
                tsmiLogout.Visible = true;
                tsmiChangePassword.Visible = true;
                // ... (thêm các mục khác nếu cần)
            }
            else // Nếu Chưa đăng nhập (dùng cho chức năng Đăng xuất)
            {
                // Hiện mục "Đăng nhập"
                tsmiLogin.Visible = true;

                // Ẩn các mục "Đăng xuất", "Đổi mật khẩu", v.v.
                tsmiLogout.Visible = false;
                tsmiChangePassword.Visible = false;
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
            LoginForm login = new LoginForm();

            // Đóng MainForm khi LoginForm được mở và MainForm không còn cần thiết
            login.FormClosed += (s, args) => this.Close();
            login.Show();
        }

        private void tsmiChangePassword_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị Form Đổi Mật khẩu
    ChangePasswordForm changePassForm = new ChangePasswordForm();
    changePassForm.ShowDialog(); // Dùng ShowDialog() để chặn MainForm cho đến khi Form này đóng
        }

        private void tsmiActInfo_Click(object sender, EventArgs e)
        {
            // Tạo và hiển thị Form Thông tin tài khoản
            UserInfoForm userInfoForm = new UserInfoForm();
            userInfoForm.Show();
        }
    }
}
