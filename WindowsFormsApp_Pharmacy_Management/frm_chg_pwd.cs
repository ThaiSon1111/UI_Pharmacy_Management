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
    public partial class frm_chg_pwd : Form
    {
        public frm_chg_pwd()
        {
            InitializeComponent();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            // Lấy Tên đăng nhập từ SessionManager
            string username = SessionManager.LoggedInUsername;

            // 1. Kiểm tra username có hợp lệ không
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn hoặc không hợp lệ. Vui lòng đăng nhập lại.", "Lỗi Phiên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // 2. Lấy dữ liệu người dùng nhập
            string enteredCurPassword = txtCurrentPass.Text;
            string enteredNewPassword = txtNewPass.Text;
            string enteredConfirmPassword = txtConfirmPass.Text;

            // 3. Kiểm tra input cơ bản
            if (string.IsNullOrWhiteSpace(enteredCurPassword) || string.IsNullOrWhiteSpace(enteredNewPassword) || string.IsNullOrWhiteSpace(enteredConfirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mật khẩu hiện tại, mật khẩu mới và xác nhận mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Kiểm tra ràng buộc phía Client
            if (enteredNewPassword != enteredConfirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và Xác nhận mật khẩu mới không khớp!", "Lỗi Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPass.Focus();
                return;
            }

            if (enteredNewPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi Mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNewPass.Focus();
                return;
            }

            // 5. Cấu hình API Request
            const string apiUrl = "http://127.0.0.1:5000/api/change_password"; // Địa chỉ API Flask của bạn

            // Chuẩn bị dữ liệu JSON payload
            var passwordData = new
            {
                username = username, // Sử dụng tên đăng nhập từ SessionManager
                current_password = enteredCurPassword,
                new_password = enteredNewPassword
            };

            // Chuyển đổi đối tượng C# sang chuỗi JSON
            string jsonPayload = JsonConvert.SerializeObject(passwordData);

            // Tạo nội dung yêu cầu HTTP (StringContent)
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // ***** THAY ĐỔI QUAN TRỌNG: SỬ DỤNG POSTAsync *****
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                    // *************************************************

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // 6. Xử lý kết quả dựa trên mã trạng thái HTTP
                    if (response.IsSuccessStatusCode) // Mã 200 OK
                    {
                        // API Python trả về JSON: {"success": true, "message": "..."}
                        JObject jsonResponse = JObject.Parse(responseBody);

                        if (jsonResponse["success"]?.Value<bool>() == true)
                        {
                            MessageBox.Show("Thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng Form sau khi thành công
                        }
                        else
                        {
                            // Lỗi logic từ Server (VD: Mật khẩu hiện tại không đúng)
                            string message = jsonResponse["message"]?.ToString() ?? "Thay đổi mật khẩu thất bại. Vui lòng kiểm tra lại mật khẩu hiện tại.";
                            MessageBox.Show(message, "Lỗi đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else // Mã lỗi (401 Unauthorized, 400 Bad Request, 500 Server Error)
                    {
                        string messageDetail = responseBody;

                        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) // Mã 401
                        {
                            // API Python trả về 401 khi mật khẩu hiện tại không đúng
                            MessageBox.Show("Mật khẩu hiện tại không đúng. Vui lòng thử lại.", "Lỗi Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Lỗi máy chủ (5xx) hoặc lỗi cú pháp (400)
                            MessageBox.Show($"Lỗi máy chủ: Không thể đổi mật khẩu. Mã lỗi: {(int)response.StatusCode}. Chi tiết: {messageDetail}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lỗi kết nối mạng hoặc Flask service chưa chạy
                    MessageBox.Show($"Lỗi kết nối: Không thể kết nối đến máy chủ Flask. Chi tiết: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng Form Đổi Mật khẩu
        }
    }
}
