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
using System.Globalization;

using WindowsFormsApp_Pharmacy_Management.SMAPP_ConfigApiFlask;
using WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon;

namespace WindowsFormsApp_Pharmacy_Management
{
    // Khai báo Enum để định nghĩa các trạng thái
    public enum FormMode
    {
        None = 0,      // Trạng thái ban đầu hoặc trạng thái xem
        Insert = 1,    // Khi nhấn nút Thêm mới (01)
        Update = 2,    // Khi nhấn nút Sửa (02)
        Delete = 3     // Khi nhấn nút Xóa (03)
    }

    public partial class frm_user_info : Form
    {
        // Khai báo biến lưu trữ trạng thái hiện tại (Form State)
        private FormMode currentMode = FormMode.None;

        // Mã báo cáo/màn hình được sử dụng để lấy cấu hình từ Backend
        private const string REPORT_CODE = "0100";

        // Cần thêm hàm ánh xạ (Helper)
        private string GetProcTypeFromMode(FormMode mode)
        {
            // Ánh xạ FormMode sang PROC_TP string (01, 02, 03)
            return ((int)mode).ToString("D2");
        }

        public frm_user_info()
        {
            InitializeComponent();
            DisableDetailInfo();
        }
        // Sửa Form_Load thành async, gọi Helper:
        private async void UserInfoForm_Load(object sender, EventArgs e)
        {
            // Bước 1: Load header động trước khi làm gì khác
            await Fn_DataGridViewHelper.LoadDynamicHeadersAsync(dgvUsers, REPORT_CODE);

            // Bước 2: Tự động tìm kiếm nếu đã đăng nhập
            string loggedInUser = SessionManager.LoggedInUsername;
            if (!string.IsNullOrEmpty(loggedInUser))
            {
                txtSearchUserId.Text = loggedInUser;
                btnSearch_Click(sender, e);
            }
        }
        // Disable các trường detail
        private void DisableDetailInfo()
        {
            txtUserIdDetail.Enabled = false;
            txtIdOrgDetail.Enabled = false;
            dtp_IdDtDetail.Enabled = false;
            txtIdNoDetail.Enabled = false;
            txtUsernameDetail.Enabled = false;
            txtPhoneDetail.Enabled = false;
            txtEmailDetail.Enabled = false;
            txtIdPwdDetail.Enabled = false;
        }

        // Enable các trường detail
        private void EnableDetailInfo()
        {
            txtUserIdDetail.Enabled = true;
            txtIdOrgDetail.Enabled = true;
            dtp_IdDtDetail.Enabled = true;
            txtIdNoDetail.Enabled = true;
            txtUsernameDetail.Enabled = true;
            txtPhoneDetail.Enabled = true;
            txtEmailDetail.Enabled = true;
            txtIdPwdDetail.Enabled = true;
        }

        private void ClearDetailInfo()
        {
            txtUserIdDetail.Text = "";
            txtIdOrgDetail.Text = "";
            // Xử lý riêng cho DateTimePicker (hoặc để trống nếu là TextBox)
            if (dtp_IdDtDetail is DateTimePicker dtp)
            {
                dtp.Value = DateTime.Now;
            }
            else
            {
                dtp_IdDtDetail.Text = "";
            }
            txtIdNoDetail.Text = "";
            txtUsernameDetail.Text = "";
            txtPhoneDetail.Text = "";
            txtEmailDetail.Text = "";
            txtIdPwdDetail.Text = "";
        }

        // Tương đương button tải lại
        private async Task ReloadDataAsync()
        {
            string apiUrl = SMAPP_ConfigApiFlask.ApiConfig.UserInfoUrl;

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

                        dgvUsers.DataSource = usersArray.ToObject<DataTable>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi tải lại dữ liệu: {ex.Message}");
                }
            }
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            // Kiểm tra xem ô có tồn tại và có giá trị không
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != null && row.Cells[columnName].Value != DBNull.Value)
            {
                return row.Cells[columnName].Value.ToString();
            }
            return string.Empty;
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

        // Hàm để tự động tạo cột, đặt tên và cấu hình Grid
        private void SetupGridColumns()
        {
            dgvUsers.Columns.Clear();

            // 1. GỌI API/HÀM CHUNG ĐỂ NẠP HEADER TỰ ĐỘNG TỪ BACKEND PYTHON
            Fn_DataGridViewHelper.LoadDynamicHeaders(dgvUsers, REPORT_CODE);

            // 2. THIẾT LẬP THUỘC TÍNH CƠ BẢN CHO GRID
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 3. ĐĂNG KÝ SỰ KIỆN TỪ CLASS COMMON DÙNG CHUNG (Vẽ STT)
            dgvUsers.RowPostPaint += Fn_DataGridViewHelper.DrawRowNumbers;
            dgvUsers.CellPainting += Fn_DataGridViewHelper.DrawHeaderSTT;
        }

        // Hàm để tạo request API đến service
        private async Task CallPythonServiceIUD(FormMode mode, string userName, string email, string id_no, string id_dt, string id_org, string userid, string pwd, string mobi_phone)
        {
            string procTp = GetProcTypeFromMode(mode);

            // 1. Tạo đối tượng dữ liệu chung (bao gồm cả PROC_TP)
            var userData = new
            {
                PROC_TP = procTp,
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
                    string url = SMAPP_ConfigApiFlask.ApiConfig.UserIudUrl;
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
                        ClearDetailInfo();
                    }
                    else
                    {
                        string errorTitle = $"Lỗi HTTP: {response.StatusCode} (PROC_TP: {procTp})";
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
            DisableDetailInfo();
            string apiUrl = SMAPP_ConfigApiFlask.ApiConfig.UserInfoUrl;

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
                        JObject jsonResponse = JObject.Parse(responseBody);
                        JArray usersArray = (JArray)jsonResponse["users"];

                        dgvUsers.DataSource = usersArray.ToObject<DataTable>();
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
            string userid = txtUserIdDetail.Text.Trim();
            string userName = txtUsernameDetail.Text.Trim();
            string email = txtEmailDetail.Text.Trim();
            string mobi_phone = txtPhoneDetail.Text.Trim();
            string id_no = txtIdNoDetail.Text.Trim();
            string id_org = txtIdOrgDetail.Text.Trim();

            // Xử lý Ngày cấp 
            string id_dt_raw;
            if (dtp_IdDtDetail is DateTimePicker dtp)
            {
                id_dt_raw = dtp.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                id_dt_raw = dtp_IdDtDetail.Text.Trim();
            }

            string pwd = txtIdPwdDetail.Text;

            // --- XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG SANG YYYYMMDD (Oracle) ---
            string id_dt_formatted;
            DateTime dateValue;
            bool success = false;

            success = DateTime.TryParseExact(
                id_dt_raw,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateValue);

            if (!success && dtp_IdDtDetail is DateTimePicker dtp1)
            {
                dateValue = dtp1.Value;
                success = true;
            }

            if (success)
            {
                id_dt_formatted = dateValue.ToString("yyyyMMdd");
            }
            else if (string.IsNullOrEmpty(id_dt_raw))
            {
                id_dt_formatted = string.Empty;
            }
            else
            {
                MessageBox.Show($"Lỗi: Ngày cấp phải theo định dạng 'dd/MM/yyyy'.", "Lỗi định dạng ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- KẾT THÚC XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG ---

            if (currentMode == FormMode.Insert || currentMode == FormMode.Update)
            {
                string action = (currentMode == FormMode.Insert) ? "thêm mới" : "chỉnh sửa";
                MessageBox.Show($"Bắt đầu xử lý {action} tài khoản");

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
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgvUsers.Rows[e.RowIndex];

            try
            {
                // Khóa chính và các trường khác
                txtUserIdDetail.Text = GetCellValue(selectedRow, "USER_ID");
                txtIdPwdDetail.Text = GetCellValue(selectedRow, "PWD");
                txtUsernameDetail.Text = GetCellValue(selectedRow, "USERNAME");
                txtPhoneDetail.Text = GetCellValue(selectedRow, "MOBI_PHONE");
                txtEmailDetail.Text = GetCellValue(selectedRow, "EMAIL");

                // Thông tin giấy tờ
                txtIdNoDetail.Text = GetCellValue(selectedRow, "ID_NO");
                txtIdOrgDetail.Text = GetCellValue(selectedRow, "ID_ORG");

                // Xử lý Ngày cấp (ID_DT)
                string idDtRaw = GetCellValue(selectedRow, "ID_DT");

                if (dtp_IdDtDetail is DateTimePicker dtp)
                {
                    if (!string.IsNullOrEmpty(idDtRaw) && DateTime.TryParseExact(
                        idDtRaw,
                        "yyyyMMdd", // Định dạng từ DB
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dt))
                    {
                        dtp.Value = dt;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(idDtRaw) && DateTime.TryParseExact(
                        idDtRaw,
                        "yyyyMMdd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dt))
                    {
                        dtp_IdDtDetail.Text = dt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dtp_IdDtDetail.Text = idDtRaw;
                    }
                }

                // Đặt form về trạng thái xem (khóa chỉnh sửa)
                DisableDetailInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị dữ liệu: {ex.Message}\nVui lòng kiểm tra lại tên cột (DataField) và tên TextBox.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdDtDetail_ValueChanged(object sender, EventArgs e)
        {
        }

        private void gbDetails_Enter(object sender, EventArgs e)
        {
        }
    }
}