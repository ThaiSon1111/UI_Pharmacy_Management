using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraGrid.Columns; // Cần thiết cho việc truy cập GridColumn
using DevExpress.XtraGrid.Views.Grid; // Cần thiết cho GridView

namespace WindowsFormsApp_Pharmacy_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) // PHẢI LÀ async
        {

            // 1. Lấy dữ liệu người dùng nhập
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;
            //Kiểm tra input
            if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Cấu hình API Request
            // Địa chỉ API Flask của bạn
            const string apiUrl = "http://127.0.0.1:5000/api/users";

            // Tạo chuỗi truy vấn (query string) với các tham số user_id và user_pwd
            string query = $"?user_id={Uri.EscapeDataString(enteredUsername)}&user_pwd={Uri.EscapeDataString(enteredPassword)}";
            string fullUrl = apiUrl + query;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 2. Gửi yêu cầu GET không đồng bộ
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // 3. Xử lý kết quả dựa trên mã trạng thái HTTP
                    if (response.IsSuccessStatusCode) // Mã 2xx (ví dụ 200 OK)
                    {
                        // API trả về JSON: {"status": "Login Successful", "user": {...}}
                        JObject jsonResponse = JObject.Parse(responseBody);

                        if (jsonResponse["status"]?.ToString() == "Login Successful")
                        {
                            // Đăng nhập THÀNH CÔNG
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Lấy thông tin người dùng (tùy chọn)
                            // JToken userData = jsonResponse["user"]; 
                            // ***** BƯỚC QUAN TRỌNG: Lưu Tên đăng nhập vào SessionManager *****
                            SessionManager.SetLoggedInUser(txtUsername.Text.Trim());
                            // ***************************************************************
                            // Ẩn LoginForm hiện tại và Mở MainForm
                            MainForm main = new MainForm();
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Trường hợp API trả về 200 nhưng logic thất bại (thường không xảy ra với API đã sửa)
                            MessageBox.Show("Lỗi phản hồi máy chủ: Dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else // Mã lỗi (401 Unauthorized, 500, 503...)
                    {
                        // 4. Xử lý lỗi đăng nhập (401) hoặc lỗi máy chủ (5xx)
                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) // Mã 401
                        {
                            MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Xử lý lỗi máy chủ (500/503 - Lỗi kết nối DB)
                            MessageBox.Show($"Lỗi máy chủ: Không thể xác thực. Mã lỗi: {(int)response.StatusCode}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // (Tùy chọn) Hiển thị chi tiết lỗi JSON:
                            // MessageBox.Show($"Chi tiết: {responseBody}", "Lỗi Chi tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lỗi kết nối mạng hoặc Flask service chưa chạy
                    MessageBox.Show($"Lỗi kết nối: Không thể kết nối đến máy chủ Flask. Chi tiết: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Xóa mật khẩu đã nhập để nhập lại trong trường hợp lỗi
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Hỏi người dùng xác nhận trước khi thoát
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng không?",
                "Xác nhận Thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Đóng toàn bộ ứng dụng
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
