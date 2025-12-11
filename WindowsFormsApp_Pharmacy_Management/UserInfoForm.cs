using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraGrid.Columns; // Cần thiết cho việc truy cập GridColumn
using DevExpress.XtraGrid.Views.Grid; // Cần thiết cho GridView

namespace WindowsFormsApp_Pharmacy_Management
{
    public partial class UserInfoForm : Form
    {
        // Mã báo cáo/màn hình được sử dụng để lấy cấu hình
        private const string REPORT_CODE = "0100";
        // Khai báo Static Schema (ĐỒNG BỘ VỚI USER_COLUMNS_SCHEMA TRONG PYTHON)
        private static readonly List<ColumnConfig> GridSchema = new List<ColumnConfig>
        {
            new ColumnConfig("USER_ID", "Tài Khoản"),
            new ColumnConfig("USERNAME", "Họ Tên"),
            new ColumnConfig("MOBI_PHONE", "Số ĐT"),
            new ColumnConfig("EMAIL", "Email"),
            new ColumnConfig("ID_NO", "CMND/CCCD"),
            new ColumnConfig("ID_DT", "Ngày Cấp CMND"),
            new ColumnConfig("ID_ORG", "Nơi Cấp CMND"),
            new ColumnConfig("WORK_DT", "Ngày Vào Làm"),
            new ColumnConfig("UPD_DT", "Cập Nhật Cuối"),
            // Bỏ PWD nếu không muốn hiển thị trên lưới
            // new ColumnConfig("PWD", "Mật Khẩu (Hash)"), 
        };
        public UserInfoForm()
        {
            InitializeComponent();
            SetupGridColumns(); // Bắt buộc gọi trước khi gán DataSource
            DisableDetailInfo();
        }
        // Disable các trường detail
        private void DisableDetailInfo()
        {
            txtUserIdDetail.Enabled     = false;
            txtIdOrgDetail.Enabled      = false;
            txtIdDtDetail.Enabled       = false;
            txtIdNoDetail.Enabled       = false;
            txtUsernameDetail.Enabled   = false;
            txtPhoneDetail.Enabled      = false;
            txtEmailDetail.Enabled      = false;
            txtIdPwdDetail.Enabled      = false;
        }
        // Enable các trường detail
        private void EnableDetailInfo()
        {
            txtUserIdDetail.Enabled     = true;
            txtIdOrgDetail.Enabled      = true;
            txtIdDtDetail.Enabled       = true;
            txtIdNoDetail.Enabled       = true;
            txtUsernameDetail.Enabled   = true;
            txtPhoneDetail.Enabled      = true;
            txtEmailDetail.Enabled      = true;
            txtIdPwdDetail.Enabled      = true;
        }
        public class ColumnConfig
        {
            // Tên cột trong JSON (Database)
            public string DataField { get; set; }
            // Tên hiển thị trên Grid
            public string HeaderText { get; set; }
            // Định nghĩa này giúp C# hiểu thứ tự và tên cột
            public ColumnConfig(string dataField, string headerText)
            {
                DataField = dataField;
                HeaderText = headerText;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            // Nếu có tên đăng nhập trong Session, tự động điền vào ô tìm kiếm và thực hiện tìm kiếm
            string loggedInUser = SessionManager.LoggedInUsername;
            if (!string.IsNullOrEmpty(loggedInUser))
            {
                txtSearchUserId.Text = loggedInUser;
                // Tự động gọi hàm tìm kiếm khi Form tải
                btnSearch_Click(sender, e);
            }
        }
        //Hàm để tự động tạo cột, đặt tên và đặt thứ tự theo GridSchema:
        private void SetupGridColumns()
        {
            // Giả sử tên control là dgvUsers hoặc DataGridView1
            dgvUsers.Columns.Clear();

            foreach (var col in GridSchema)
            {
                DataGridViewTextBoxColumn gridColumn = new DataGridViewTextBoxColumn();
                // Ánh xạ tên cột DB từ JSON vào DataPropertyName
                gridColumn.DataPropertyName = col.DataField;
                // Đặt tên hiển thị từ Schema
                gridColumn.HeaderText = col.HeaderText;
                gridColumn.Name = col.DataField;
                dgvUsers.Columns.Add(gridColumn);
            }

            // Đảm bảo các thiết lập ReadOnly và AutoSizeColumnsMode vẫn còn
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            const string apiUrl = "http://127.0.0.1:5000/api/users/search";

            // Lấy giá trị tìm kiếm
            string userId = Uri.EscapeDataString(txtSearchUserId.Text.Trim());
            string phone = Uri.EscapeDataString(txtSearchPhone.Text.Trim());
            string email = Uri.EscapeDataString(txtSearchEmail.Text.Trim());

            // Tạo chuỗi truy vấn (query string)
            string query = $"?user_id={userId}&phone={phone}&email={email}";
            string fullUrl = apiUrl + query;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // API Python trả về danh sách người dùng JSON: {"users": [...]}
                        // Sử dụng JObject để phân tích và hiển thị lên DataGridView
                        JObject jsonResponse = JObject.Parse(responseBody);
                        JArray usersArray = (JArray)jsonResponse["users"];

                        // Chuyển đổi JArray thành DataTable hoặc BindingSource để gán cho DataGridView
                        // (Bạn có thể cần một hàm helper để chuyển đổi JArray sang DataTable)
                        // Ví dụ đơn giản:

                        // Gán trực tiếp dữ liệu thô (yêu cầu cài đặt System.Text.Json hoặc sử dụng Newtonsoft.Json)
                        // Nếu bạn không dùng DataTable, bạn phải đảm bảo cột DataGridView khớp với tên thuộc tính JSON

                        dgvUsers.DataSource = usersArray.ToObject<DataTable>(); // Hoặc List<UserObject>
                        MessageBox.Show("Tìm kiếm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi truy vấn: Mã lỗi {(int)response.StatusCode}", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
