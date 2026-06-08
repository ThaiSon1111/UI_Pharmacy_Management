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
//using DevExpress.XtraGrid.Columns; // Các thư viện DevExpress đã bị loại bỏ
//using DevExpress.XtraGrid.Views.Grid; // Các thư viện DevExpress đã bị loại bỏ
using System.Globalization; // Dùng khi có sử dụng CultureInfo

using WindowsFormsApp_Pharmacy_Management.SMAPP_ConfigApiFlask;
using WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon; // Thêm dòng này để include thư mục common
namespace WindowsFormsApp_Pharmacy_Management
{
    // Khai báo Enum để định nghĩa các trạng thái
    public enum FormMode_CusInfo
    {
        None = 0,      // Trạng thái ban đầu hoặc trạng thái xem
        Insert = 1,    // Khi nhấn nút Thêm mới (01)
        Update = 2,    // Khi nhấn nút Sửa (02)
        Delete = 3     // Khi nhấn nút Xóa (03)
    }

    public partial class frm_customer_info : Form
    {
        // 2. Khai báo biến lưu trữ trạng thái hiện tại (Form State)
        private FormMode_CusInfo currentMode = FormMode_CusInfo.None;
        // Mã báo cáo/màn hình được sử dụng để lấy cấu hình
        private const string REPORT_CODE = "0100";
        // Cần thêm hàm ánh xạ (Helper)
        private string GetProcTypeFromMode(FormMode_CusInfo mode)
        {
            // Ánh xạ FormMode_CusInfo sang PROC_TP string (01, 02, 03)
            return ((int)mode).ToString("D2"); // D2 format 1 -> "01", 2 -> "02"
        }
        // Khai báo Static Schema (ĐỒNG BỘ VỚI USER_COLUMNS_SCHEMA TRONG PYTHON)
        private static readonly List<ColumnConfig> GridSchema = new List<ColumnConfig>
        {
            new ColumnConfig("CUST_NO", "Tài khoản khách hàng"),
            new ColumnConfig("CUST_NM", "Họ tên"),
            new ColumnConfig("MOBI_PHONE", "Số ĐT"),
            new ColumnConfig("EMAIL", "Email"),
            new ColumnConfig("SEX", "Giới tính"),
            new ColumnConfig("HOME_ADDR", "Địa chỉ"),
            new ColumnConfig("TAX_NO", "Mã số thuế"),
            new ColumnConfig("REGI_DT", "Ngày đăng ký"),
            new ColumnConfig("ACC_POINTS", "Điểm tích lũy"),
            new ColumnConfig("ACTIVE_YN", "Trạng thái hoạt động"),
            new ColumnConfig("UPD_DT", "Ngày cập nhật cuối cùng"),
            // Bỏ PWD nếu không muốn hiển thị trên lưới
            // new ColumnConfig("PWD", "Mật Khẩu (Hash)"), 
        };
        public frm_customer_info()
        {
            InitializeComponent();
            SetupGridColumns(); // Bắt buộc gọi trước khi gán DataSource
            DisableDetailInfo();
        }
        // Disable các trường detail
        private void DisableDetailInfo()
        {
            txt_CustnoDetail.Enabled    = false;
            txt_CustnmDetail.Enabled    = false;
            txt_PhoneDetail.Enabled      = false;
            txt_EmailDetail.Enabled     = false;
            cmb_SexDetail.Enabled       = false;
            txt_HomeAddrDetail.Enabled  = false;
            txt_TaxNoDetail.Enabled       = false;
            dtp_RegiDtDetail.Enabled    = false; 
            txt_AccPointsDetail.Enabled = false;
            cmb_ActiveYnDetail.Enabled  = false;
        }
        // Enable các trường detail
        private void EnableDetailInfo()
        {
            txt_CustnoDetail.Enabled    = false;
            txt_CustnmDetail.Enabled    = true;
            txt_PhoneDetail.Enabled      = true;
            txt_EmailDetail.Enabled     = true;
            cmb_SexDetail.Enabled       = true;
            txt_HomeAddrDetail.Enabled  = true;
            txt_TaxNoDetail.Enabled       = true;
            dtp_RegiDtDetail.Enabled    = false;
            txt_AccPointsDetail.Enabled = true;
            cmb_ActiveYnDetail.Enabled  = true;
        }
        private void ClearDetailInfo()
        {
            txt_CustnoDetail.Text = "";
            txt_HomeAddrDetail.Text = "";
            // Xử lý riêng cho DateTimePicker (hoặc để trống nếu là TextBox)
            if (dtp_RegiDtDetail is DateTimePicker dtp)
            {
                // Nếu là DateTimePicker, reset về ngày hôm nay hoặc ngày tối thiểu
                dtp.Value = DateTime.Now;
            }
            else
            {
                dtp_RegiDtDetail.Text = "";
            }
            cmb_SexDetail.Text      = "";
            txt_CustnmDetail.Text   = "";
            txt_PhoneDetail.Text     = "";
            txt_EmailDetail.Text    = "";
            txt_TaxNoDetail.Text     = "";
            txt_AccPointsDetail.Text = "0";
            cmb_ActiveYnDetail.Text = "Y";
        }
        // Tương đương button tải lại
        private async Task ReloadDataAsync()
        {
            // Lấy logic từ hàm btnSearch_Click và chỉnh sửa lại
            string apiUrl = SMAPP_ConfigApiFlask.ApiConfig.CustomerSearchUrl;

            // Lấy giá trị tìm kiếm (Sử dụng các ô tìm kiếm hiện tại)
            string cust_no = Uri.EscapeDataString(txtSearchUserId.Text.Trim());
            string phone = Uri.EscapeDataString(txtSearchPhone.Text.Trim());
            string email = Uri.EscapeDataString(txtSearchEmail.Text.Trim());

            string query = $"?user_id={cust_no}&phone={phone}&email={email}";
            string fullUrl = apiUrl + query;
            Console.WriteLine("Reloading...");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response1 = await client.GetAsync(fullUrl);
                    string responseBody1 = await response1.Content.ReadAsStringAsync();

                    if (response1.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Reload Suscess...");
                        // Phân tích và gán dữ liệu vào DataGridView
                        JObject jsonResponse = JObject.Parse(responseBody1);
                        JArray usersArray = (JArray)jsonResponse["custinfo"];

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
            if (row.Cells[columnName] != null && row.Cells[columnName].Value != null && row.Cells[columnName].Value != DBNull.Value)
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
            btnSearch_Click(sender, e);
        }
        //Hàm để tự động tạo cột, đặt tên và đặt thứ tự theo GridSchema:
        private void SetupGridColumns()
        {
            dgvUsers.Columns.Clear();

            foreach (var col in GridSchema)
            {
                DataGridViewTextBoxColumn gridColumn = new DataGridViewTextBoxColumn();
                // Ánh xạ tên cột DB từ JSON vào DataPropertyName
                gridColumn.DataPropertyName = col.DataField;
                // Đặt tên hiển thị từ Schema
                gridColumn.HeaderText = col.HeaderText;
                gridColumn.Name = col.DataField;

                // --- KHẮC PHỤC LỖI HIỂN THỊ ĐỊNH DẠNG NGÀY TRÊN GRID ---
                if (col.DataField == "REGI_DT" || col.DataField == "WORK_DT" || col.DataField == "UPD_DT")
                {
                    // Định dạng hiển thị dd/MM/yyyy trên DataGridView
                    gridColumn.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                // ----------------------------------------------------

                dgvUsers.Columns.Add(gridColumn);
            }

            // Đảm bảo các thiết lập ReadOnly và AutoSizeColumnsMode vẫn còn
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            // Đặt độ rộng cho cột chứa số thứ tự vừa đủ nhìn
            dgvUsers.RowHeadersWidth = 30;

            // =========================================================================
            // ĐĂNG KÝ SỰ KIỆN TỪ CLASS COMMON DÙNG CHUNG
            // =========================================================================
            dgvUsers.RowPostPaint += Fn_DataGridViewHelper.DrawRowNumbers; // Gọi hàm vẽ số thứ tự
            dgvUsers.CellPainting += Fn_DataGridViewHelper.DrawHeaderSTT;  // Gọi hàm vẽ chữ STT trên header
        }
        // Hàm để tạo request API đến service
        private async Task CallPythonServiceIUD(FormMode_CusInfo mode, string cust_no, string cust_nm, string mobi_phone, string email, string sex, string home_addr, string tax_no, string acc_points)
        {
            string procTp = GetProcTypeFromMode(mode);

            // 1. Tạo đối tượng dữ liệu chung (bao gồm cả PROC_TP)
            var userData = new
            {
                // PROC_TP được đặt lên đầu để Python phân luồng
                PROC_TP = procTp,

                // Gửi tên cột CHỮ HOA để khớp với Python và Oracle DB
                CUST_NO = cust_no,
                CUST_NM = cust_nm,
                MOBI_PHONE = mobi_phone,
                EMAIL = email,
                SEX = sex,
                HOME_ADDR = home_addr,
                TAX_NO = tax_no, // Khóa chính
                ACC_POINTS = acc_points
,
            };

            string jsonPayload = JsonConvert.SerializeObject(userData);

            using (StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"))
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Endpoint API IUD chung
                    string url = SMAPP_ConfigApiFlask.ApiConfig.CustomerIudUrl;

                    // Luôn dùng POST (vì là IUD)
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                        string successMessage = jsonResponse?.message ?? "Thao tác IUD thành công.";

                        MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        await ReloadDataAsync();
                        currentMode = FormMode_CusInfo.None;
                        DisableDetailInfo();
                        ClearDetailInfo();
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
            string apiUrl = SMAPP_ConfigApiFlask.ApiConfig.CustomerSearchUrl;
            Console.WriteLine("Test");
            // Lấy giá trị tìm kiếm
            string cust_no = Uri.EscapeDataString(txtSearchUserId.Text.Trim());
            string phone = Uri.EscapeDataString(txtSearchPhone.Text.Trim());
            string email = Uri.EscapeDataString(txtSearchEmail.Text.Trim());

            // Tạo chuỗi truy vấn (query string)
            string query = $"?cust_no={cust_no}&phone={phone}&email={email}";
            string fullUrl = apiUrl + query;
            Console.WriteLine("Test1");
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("fullUrl: = " + fullUrl);
                try
                {
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Test2");
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Test3");
                        // API Python trả về danh sách người dùng JSON: {"users": [...]}
                        JObject jsonResponse = JObject.Parse(responseBody);
                        JArray usersArray = (JArray)jsonResponse["custinfo"];

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
            txt_CustnoDetail.Focus();
            currentMode = FormMode_CusInfo.Insert;
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string cust_no = txt_CustnoDetail.Text.Trim();

            if (string.IsNullOrEmpty(cust_no))
            {
                MessageBox.Show("Vui lòng chọn một người dùng trên lưới để xóa.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa người dùng với tài khoản '{cust_no}' không?",
                "Xác nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // GỌI HÀM IUD CHUNG VỚI FormMode_CusInfo.Delete
                MessageBox.Show("Bắt đầu xử lý xóa tài khoản");
                // Các tham số khác là NULL hoặc rỗng khi xóa
                await CallPythonServiceIUD(FormMode_CusInfo.Delete, cust_no, null, null, null, null, null, null, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableDetailInfo();
            currentMode = FormMode_CusInfo.Update;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //string cust_no = txt_CustnoDetail.Text.Trim();
            string cust_no = txt_CustnoDetail.Text.Trim();
            string cust_nm = txt_CustnmDetail.Text.Trim();
            string email = txt_EmailDetail.Text.Trim();
            string mobi_phone = txt_PhoneDetail.Text.Trim();
            string sex = cmb_SexDetail.Text.Trim();
            string home_addr = txt_HomeAddrDetail.Text.Trim();
            string tax_no = txt_TaxNoDetail.Text.Trim();
            string acc_points = txt_AccPointsDetail.Text.Trim();

            // Xử lý Ngày cấp - Lấy giá trị theo loại Control
            string regi_dt_raw;
            if (dtp_RegiDtDetail is DateTimePicker dtp)
            {
                // Nếu là DateTimePicker, lấy giá trị đã được chọn (dạng dd/MM/yyyy nếu format đúng)
                regi_dt_raw = dtp.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                // Nếu là TextBox/MaskedTextBox
                regi_dt_raw = dtp_RegiDtDetail.Text.Trim();
            }

            //string pwd = txtIdPwdDetail.Text;

            // --- XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG SANG YYYYMMDD (Oracle) ---
            string regi_dt_formatted;
            DateTime dateValue;
            bool success = false;

            // Định dạng ưu tiên (dành cho người dùng nhập/chọn)
            string[] acceptedFormats = new[] { "dd/MM/yyyy" };

            // 1. Thử phân tích chuỗi ngày cấp thô (chỉ cần định dạng dd/MM/yyyy là đủ)
            success = DateTime.TryParseExact(
                regi_dt_raw,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateValue);

            // Nếu là DateTimePicker, TryParseExact không cần thiết vì Value luôn là DateTime hợp lệ
            if (!success && dtp_RegiDtDetail is DateTimePicker dtp1)
            {
                dateValue = dtp1.Value;
                success = true;
            }


            if (success)
            {
                // Nếu phân tích thành công, chuyển sang định dạng YYYYMMDD (Oracle)
                regi_dt_formatted = dateValue.ToString("yyyyMMdd");
            }
            else if (string.IsNullOrEmpty(regi_dt_raw))
            {
                // Cho phép ngày cấp để trống (NULL cho DB)
                regi_dt_formatted = string.Empty;
            }
            else
            {
                // Xử lý lỗi nếu không khớp định dạng
                MessageBox.Show($"Lỗi: Ngày cấp phải theo định dạng 'dd/MM/yyyy'.", "Lỗi định dạng ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // --- KẾT THÚC XỬ LÝ CHUYỂN ĐỔI NGÀY THÁNG ---

            // Xử lý chính
            if (currentMode == FormMode_CusInfo.Insert || currentMode == FormMode_CusInfo.Update)
            {
                string action = (currentMode == FormMode_CusInfo.Insert) ? "thêm mới" : "chỉnh sửa";
                MessageBox.Show($"Bắt đầu xử lý {action} tài khoản");

                // GỌI HÀM IUD CHUNG
                await CallPythonServiceIUD(currentMode, cust_no, cust_nm, mobi_phone, email, sex, home_addr, tax_no, acc_points);
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
                txt_CustnoDetail.Text = GetCellValue(selectedRow, "CUST_NO");
                txt_CustnmDetail.Text = GetCellValue(selectedRow, "CUST_NM");
                txt_PhoneDetail.Text = GetCellValue(selectedRow, "MOBI_PHONE");
                txt_EmailDetail.Text = GetCellValue(selectedRow, "EMAIL");
                cmb_SexDetail.Text = GetCellValue(selectedRow, "SEX");
                txt_HomeAddrDetail.Text = GetCellValue(selectedRow, "HOME_ADDR");
                txt_TaxNoDetail.Text = GetCellValue(selectedRow, "TAX_NO");

                // Thông tin giấy tờ
                txt_AccPointsDetail.Text = GetCellValue(selectedRow, "ACC_POINTS");
                cmb_ActiveYnDetail.Text = GetCellValue(selectedRow, "ACTIVE_YN");

                // Xử lý Ngày cấp (ID_DT)
                string RegiDt = GetCellValue(selectedRow, "REGI_DT");
                Console.WriteLine("RegiDt: " + RegiDt);
                // Nếu là DateTimePicker, gán giá trị hợp lệ
                if (dtp_RegiDtDetail is DateTimePicker dtp)
                {
                    if (!string.IsNullOrEmpty(RegiDt) && DateTime.TryParseExact(
                        RegiDt,
                        "yyyyMMdd", // Định dạng từ DB
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dt))
                    {
                        dtp.Value = dt;
                    }
                    else
                    {
                        // Nếu DB là NULL hoặc không hợp lệ, set lại ngày mặc định/reset
                        // Có thể đặt dtp.Value = DateTime.Now; hoặc reset trạng thái hiển thị
                    }
                }
                // Nếu là TextBox/MaskedTextBox, vẫn dùng logic hiển thị định dạng
                else
                {
                    if (!string.IsNullOrEmpty(RegiDt) && DateTime.TryParseExact(
                        RegiDt,
                        "yyyyMMdd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dt))
                    {
                        // Chuyển từ YYYYMMDD sang định dạng dd/MM/yyyy để dễ đọc
                        dtp_RegiDtDetail.Text = dt.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dtp_RegiDtDetail.Text = RegiDt; // Gán chuỗi thô nếu không phải định dạng ngày
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
            // Chỉ cần thiết nếu txtIdDtDetail là DateTimePicker
        }

        private void txtSearchUserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}