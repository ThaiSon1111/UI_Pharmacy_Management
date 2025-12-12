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
        // Cần thêm hàm ánh xạ (Helper)
        private string GetProcTypeFromMode(FormMode mode)
        {
            // Ánh xạ FormMode sang PROC_TP string (01, 02, 03)
            return ((int)mode).ToString("D2"); // D2 format 1 -> "01", 2 -> "02"
        }
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
        // Hàm để tạo request API đến service
        private async Task CallPythonServiceIUD(FormMode mode, string userName, string email, string id_no, string id_dt, string id_org, string userid, string pwd, string mobi_phone)
        {
            string procTp = GetProcTypeFromMode(mode);

            // 1. Tạo đối tượng dữ liệu chung (bao gồm cả PROC_TP)
            var userData = new
            {
                // PROC_TP được đặt lên đầu để Python phân luồng
                PROC_TP = procTp,

                // Gửi tên cột CHỮ HOA để khớp với Python và Oracle DB
                USERNAME = userName,
                EMAIL = email,
                ID_NO = id_no,
                ID_DT = id_dt,
                ID_ORG = id_org,
                USER_ID = userid, // Khóa chính
                PWD = pwd,
                MOBI_PHONE = mobi_phone
            };

            string jsonPayload = JsonConvert.SerializeObject(userData);

            using (StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Endpoint API IUD chung
                    string url = "http://localhost:5000/api/users/iud";

                    // Luôn dùng POST (vì là IUD)
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                        string successMessage = jsonResponse?.message ?? "Thao tác IUD thành công.";

                        MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await ReloadDataAsync();
                        currentMode = FormMode.None;
                        DisableDetailInfo();
                        ClearDetailInfo(); // Cần đảm bảo hàm này tồn tại
                    }
                    else
                    {
                        string errorTitle = $"Lỗi HTTP: {response.StatusCode} (PROC_TP: {procTp})";
                        // Xử lý lỗi (giống như logic đã có)
                        try
                        {
                            dynamic errorResponse = JsonConvert.DeserializeObject(responseContent);
                            string errorMessage = errorResponse?.error ?? responseContent;
                            MessageBox.Show(errorMessage, errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show($"Chi tiết lỗi: {responseContent}", errorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối hoặc xử lý: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string userid = txtUserIdDetail.Text.Trim();

            if (string.IsNullOrEmpty(userid))
            {
                MessageBox.Show("Vui lòng chọn một người dùng trên lưới để xóa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa người dùng với tài khoản '{userid}' không?",
                "Xác nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // GỌI HÀM IUD CHUNG VỚI FormMode.Delete
                MessageBox.Show("Bắt đầu xử lý xóa tài khoản");
                await CallPythonServiceIUD(FormMode.Delete, null, null, null, null, null, userid, null, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDetailInfo();
            currentMode = FormMode.Update;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // ... (Logic lấy và định dạng dữ liệu, xử lý id_dt_formatted giữ nguyên) ...
            string userid = txtUserIdDetail.Text.Trim();
            string userName = txtUsernameDetail.Text.Trim(); // Lấy từ TextBox
            string email = txtEmailDetail.Text.Trim();       // Lấy từ TextBox
            string mobi_phone = txtPhoneDetail.Text.Trim();  // Lấy từ TextBox
            string id_no = txtIdNoDetail.Text.Trim();        // Lấy từ TextBox
            string id_org = txtIdOrgDetail.Text.Trim();      // Lấy từ TextBox
            string id_dt_raw = txtIdDtDetail.Text.Trim();    // Ngày cấp thô
            string pwd = txtIdPwdDetail.Text;                // Mật khẩu

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

            // Xử lý chính
            if (currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                string action = (currentMode == FormMode.Insert) ? "thêm mới" : "chỉnh sửa";
                MessageBox.Show($"Bắt đầu xử lý {action} tài khoản");

                // GỌI HÀM IUD CHUNG
                await CallPythonServiceIUD(currentMode, userName, email, id_no, id_dt_formatted, id_org, userid, pwd, mobi_phone);
            }
            else
            {
                MessageBox.Show("Vui lòng nhấn 'Thêm mới' hoặc 'Sửa' trước khi Lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
