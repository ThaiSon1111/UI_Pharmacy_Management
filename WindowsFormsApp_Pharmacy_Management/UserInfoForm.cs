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
using System.Globalization; // Dùng khi có sử dụng CultureInfo
namespace WindowsFormsApp_Pharmacy_Management
{
    // Khai báo Enum để định nghĩa các trạng thái
    public enum FormMode
    {
        None = 0,     // Trạng thái ban đầu hoặc trạng thái xem
        Insert = 1,   // Khi nhấn nút Thêm mới (01)
        Update = 2,   // Khi nhấn nút Sửa (02)
        Delete = 3    // Khi nhấn nút Xóa (03)
    }
    public partial class UserInfoForm : Form
    {
        // 2. Khai báo biến lưu trữ trạng thái hiện tại (Form State)
        private FormMode currentMode = FormMode.None;
        // Mã báo cáo/màn hình được sử dụng để lấy cấu hình
        private const string REPORT_CODE = "0100";
        private const string PROC_TP = "";
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
        private void ClearDetailInfo()
        {
            txtUserIdDetail.Text = "";
            txtIdOrgDetail.Text = "";
            txtIdDtDetail.Text = "";
            txtIdNoDetail.Text = "";
            txtUsernameDetail.Text = "";
            txtPhoneDetail.Text = "";
            txtEmailDetail.Text = "";
            txtIdPwdDetail.Text = "";
        }
        // Tương đương button tải lại
        private async Task ReloadDataAsync()
        {
            // Lấy logic từ hàm btnSearch_Click và chỉnh sửa lại
            const string apiUrl = "http://127.0.0.1:5000/api/users/search";

            // Lấy giá trị tìm kiếm (Sử dụng các ô tìm kiếm hiện tại)
            string userId = Uri.EscapeDataString(txtSearchUserId.Text.Trim());
            string phone = Uri.EscapeDataString(txtSearchPhone.Text.Trim());
            string email = Uri.EscapeDataString(txtSearchEmail.Text.Trim());

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
                        // Phân tích và gán dữ liệu vào DataGridView
                        JObject jsonResponse = JObject.Parse(responseBody);
                        JArray usersArray = (JArray)jsonResponse["users"];

                        // Dòng này cần một hàm Convert JArray sang DataTable (hoặc phải dùng JArray.ToObject<DataTable>())
                        // Lưu ý: Nếu dòng này lỗi, bạn phải đảm bảo đã cài Newtonsoft.Json và có hàm Convert JArray sang DataTable
                        dgvUsers.DataSource = usersArray.ToObject<DataTable>();
                    }
                    // Không cần MessageBox.Show khi reload
                }
                catch (Exception ex)
                {
                    // Có thể ghi log nếu lỗi
                    Console.WriteLine($"Lỗi khi tải lại dữ liệu: {ex.Message}");
                }
            }
        }
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            // Kiểm tra xem ô có tồn tại và có giá trị không
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != null)
            {
                return row.Cells[columnName].Value.ToString();
            }
            return string.Empty;
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
            //Disnable các trường detail info
            DisableDetailInfo();
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
        // Thêm mới (btnAddNew)
        private async void button1_Click(object sender, EventArgs e)
        {
            EnableDetailInfo();
            ClearDetailInfo();
            txtUserIdDetail.Focus();
            currentMode = FormMode.Insert;
        }
        // Hàm gọi dịch vụ Python, đã chuyển thành POST request

       
        private async Task CallPythonServiceInsert(string userName, string email, string id_no, string id_dt, string id_org, string userid, string pwd, string mobi_phone)
        {
            /*if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Tên người dùng (Username) không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
            // 1. Tạo đối tượng dữ liệu để serialize thành JSON
            var userData = new
            {
                username = userName,
                email = email,
                id_no = id_no,
                id_dt = id_dt, // Đã được định dạng YYYYMMDD
                id_org = id_org,
                userid = userid,
                pwd = pwd,
                mobi_phone = mobi_phone
            };

            // 2. Chuyển đối tượng sang chuỗi JSON
            string jsonPayload = JsonConvert.SerializeObject(userData);

            // 3. Đóng gói JSON vào StringContent và thiết lập Content-Type
            using (StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Endpoint POST và port 5001 của Flask
                    string url = "http://localhost:5000/api/users/add";

                    // 4. Thực hiện POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Đọc phản hồi từ server
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // PHÂN TÍCH JSON CHÍNH XÁC
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                        // Lấy ra message. Newtonsoft.Json sẽ tự động giải mã \u... thành tiếng Việt
                        string successMessage = jsonResponse?.message ?? "Thao tác thành công.";

                        // Hiển thị message tiếng Việt đã được xử lý
                        MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // --- TỰ ĐỘNG ĐÓNG FORM SAU KHI THÀNH CÔNG ---
                        // 1. Bỏ lệnh this.Close();
                        // 2. Gọi lại hàm tra cứu để làm mới lưới (dgvUsers)
                        await ReloadDataAsync(); // <== GỌI HÀM TẢI LẠI DỮ LIỆU

                        // 3. Đưa form về trạng thái xem ban đầu (None) và khóa các control chi tiết
                        currentMode = FormMode.None;
                        DisableDetailInfo();

                        // Không cần this.Close(); nữa!
                    }
                    else
                    {
                        // Xử lý lỗi: Hiển thị lỗi HTTP và nội dung phản hồi
                        string errorTitle = $"Lỗi HTTP: {response.StatusCode}";

                        // Cố gắng phân tích JSON lỗi để hiển thị message tiếng Việt
                        try
                        {
                            dynamic errorResponse = JsonConvert.DeserializeObject(responseContent);
                            string errorMessage = errorResponse?.error ?? responseContent; // Lấy trường 'error' hoặc chuỗi thô
                            MessageBox.Show(errorMessage, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            // Nếu không phải JSON, hiển thị lỗi HTTP và nội dung thô
                            MessageBox.Show($"Chi tiết lỗi: {responseContent}", errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lỗi kết nối mạng, server không chạy, v.v.
                    MessageBox.Show($"Lỗi kết nối hoặc xử lý: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string PROC_TP = "02";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDetailInfo();
            currentMode = FormMode.Update;
        }
        private async Task CallPythonServiceEdit(string userName, string email, string id_no, string id_dt, string id_org, string userid, string pwd, string mobi_phone)
        {
            /*if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Tên người dùng (Username) không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            */
            // 1. Tạo đối tượng dữ liệu để serialize thành JSON
            var userData = new
            {
                username = userName,
                email = email,
                id_no = id_no,
                id_dt = id_dt, // Đã được định dạng YYYYMMDD
                id_org = id_org,
                userid = userid,
                pwd = pwd,
                mobi_phone = mobi_phone
            };

            // 2. Chuyển đối tượng sang chuỗi JSON
            string jsonPayload = JsonConvert.SerializeObject(userData);

            // 3. Đóng gói JSON vào StringContent và thiết lập Content-Type
            using (StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Endpoint POST và port 5001 của Flask
                    string url = "http://localhost:5000/api/users/update";

                    // 4. Thực hiện POST request
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Đọc phản hồi từ server
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // PHÂN TÍCH JSON CHÍNH XÁC
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                        // Lấy ra message. Newtonsoft.Json sẽ tự động giải mã \u... thành tiếng Việt
                        string successMessage = jsonResponse?.message ?? "Thao tác thành công.";

                        // Hiển thị message tiếng Việt đã được xử lý
                        MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // --- TỰ ĐỘNG ĐÓNG FORM SAU KHI THÀNH CÔNG ---
                        // 1. Bỏ lệnh this.Close();
                        // 2. Gọi lại hàm tra cứu để làm mới lưới (dgvUsers)
                        await ReloadDataAsync(); // <== GỌI HÀM TẢI LẠI DỮ LIỆU

                        // 3. Đưa form về trạng thái xem ban đầu (None) và khóa các control chi tiết
                        currentMode = FormMode.None;
                        DisableDetailInfo();

                        // Không cần this.Close(); nữa!
                    }
                    else
                    {
                        // Xử lý lỗi: Hiển thị lỗi HTTP và nội dung phản hồi
                        string errorTitle = $"Lỗi HTTP: {response.StatusCode}";

                        // Cố gắng phân tích JSON lỗi để hiển thị message tiếng Việt
                        try
                        {
                            dynamic errorResponse = JsonConvert.DeserializeObject(responseContent);
                            string errorMessage = errorResponse?.error ?? responseContent; // Lấy trường 'error' hoặc chuỗi thô
                            MessageBox.Show(errorMessage, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            // Nếu không phải JSON, hiển thị lỗi HTTP và nội dung thô
                            MessageBox.Show($"Chi tiết lỗi: {responseContent}", errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lỗi kết nối mạng, server không chạy, v.v.
                    MessageBox.Show($"Lỗi kết nối hoặc xử lý: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(PROC_TP.ToString(), "Thông tin loại xử lý");
            // Xử lý chính
            // Lấy dữ liệu từ các control
            string userName = txtUsernameDetail.Text;
            string email = txtEmailDetail.Text;
            string id_no = txtIdNoDetail.Text;
            // Lấy chuỗi ngày cấp thô từ control
            string id_dt_raw = txtIdDtDetail.Text;
            string id_org = txtIdOrgDetail.Text;
            string userid = txtUserIdDetail.Text;
            string pwd = txtIdPwdDetail.Text;
            string mobi_phone = txtPhoneDetail.Text;
            // --- XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG SANG YYYYMMDD (Oracle) ---
            string id_dt_formatted;
            // KHẮC PHỤC LỖI CS0165: Gán giá trị mặc định cho dateValue
            DateTime dateValue = DateTime.MinValue;

            // Các định dạng có thể chấp nhận
            string[] acceptedFormats = new[] {
            "dd/MM/yyyy", // Định dạng ngắn bạn muốn hiển thị
            "dddd, MMMM dd, yyyy" // Định dạng dài (default)
             };

            bool success = false;

            // 1. Thử phân tích chuỗi ngày cấp thô
            foreach (var format in acceptedFormats)
            {
                if (DateTime.TryParseExact(
                    id_dt_raw,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateValue))
                {
                    success = true;
                    break;
                }
            }

            if (success)
            {
                // Nếu phân tích thành công, chuyển sang định dạng YYYYMMDD (Oracle)
                id_dt_formatted = dateValue.ToString("yyyyMMdd");
            }
            else if (string.IsNullOrEmpty(id_dt_raw))
            {
                // Cho phép ngày cấp để trống 
                id_dt_formatted = string.Empty;
            }
            else
            {
                // Xử lý lỗi nếu không khớp bất kỳ định dạng nào
                MessageBox.Show($"Lỗi: Ngày cấp phải theo định dạng 'dd/MM/yyyy'.", "Lỗi định dạng ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- KẾT THÚC XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG ---

            // Gọi hàm service với dữ liệu đã lấy
            //AddNew

            if (currentMode == FormMode.Insert)
            {
                MessageBox.Show("Bắt đầu xử lý thêm mới tài khoản");
                await CallPythonServiceInsert(userName, email, id_no, id_dt_formatted, id_org, userid, pwd, mobi_phone);
            }
            //Edit
            if (currentMode == FormMode.Update)
            {
                MessageBox.Show("Bắt đầu xử lý chính sửa tài khoản");
                await CallPythonServiceEdit(userName, email, id_no, id_dt_formatted, id_org, userid, pwd, mobi_phone);
            }

        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // DÒNG KIỂM TRA QUAN TRỌNG: Loại trừ hàng tiêu đề (header row)
            if (e.RowIndex < 0) // Khi click vào tiêu đề, RowIndex là -1
            {
                return;
            }
            // 2. Lấy dòng dữ liệu được chọn
            DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

            try
            {
                // 3. Lấy giá trị từ các ô và gán vào các TextBox chi tiết
                //    (Tên cột phải khớp chính xác với DataField đã khai báo trong GridSchema)

                // Khóa chính và các trường khác
                txtUserIdDetail.Text = GetCellValue(selectedRow, "USER_ID");
                txtUsernameDetail.Text = GetCellValue(selectedRow, "USERNAME");
                txtPhoneDetail.Text = GetCellValue(selectedRow, "MOBI_PHONE");
                txtEmailDetail.Text = GetCellValue(selectedRow, "EMAIL");

                // Thông tin giấy tờ
                txtIdNoDetail.Text = GetCellValue(selectedRow, "ID_NO");
                txtIdOrgDetail.Text = GetCellValue(selectedRow, "ID_ORG");

                // Cột PWD (Mật khẩu - nếu có)
                // Lưu ý: Không nên hiển thị mật khẩu đã hash ra TextBox. Có thể để trống hoặc hiển thị placeholder.
                // Ví dụ:
                txtIdPwdDetail.Text = string.Empty; // Luôn để trống khi xem
                                                    // HOẶC: txtIdPwdDetail.Text = "******";

                // Xử lý Ngày cấp (ID_DT)
                string idDtRaw = GetCellValue(selectedRow, "ID_DT");
                if (!string.IsNullOrEmpty(idDtRaw) && DateTime.TryParseExact(idDtRaw, "yyyyMMdd",
                                                      CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
                {
                    // Chuyển từ YYYYMMDD sang định dạng dd/MM/yyyy để dễ đọc
                    txtIdDtDetail.Text = dt.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtIdDtDetail.Text = idDtRaw; // Gán chuỗi thô nếu không phải định dạng ngày
                }

                // 4. Đặt form về trạng thái xem (khóa chỉnh sửa)
                DisableDetailInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị dữ liệu: {ex.Message}\nVui lòng kiểm tra lại tên cột (DataField) và tên TextBox.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
