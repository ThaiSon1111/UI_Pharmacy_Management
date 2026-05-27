using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; //Thư viện quản lý danh sách tập hợp của .NET


using System.Net.Http;
using Newtonsoft.Json;
using WindowsFormsApp_Pharmacy_Management.SMAPP_ConfigApiFlask;
namespace WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon
{
    public static class Fn_DataGridViewHelper
    {
        /// <summary>
        /// Sự kiện vẽ số thứ tự (STT) tự động cho các dòng trên DataGridView
        /// </summary>
        public static void DrawRowNumbers(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                // 1. Tính toán số thứ tự dựa trên chỉ số dòng hiện tại (Index + 1)
                string rowNumber = (e.RowIndex + 1).ToString();

                // 2. Định dạng font chữ và màu sắc cho số thứ tự
                Font rowFont = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
                Brush rowBrush = SystemBrushes.ControlText;

                // 3. Tính toán kích thước và vị trí tâm để vẽ chuỗi số thứ tự nằm chính giữa
                var textSize = e.Graphics.MeasureString(rowNumber, rowFont);
                float xPosition = e.RowBounds.Left + (dgv.RowHeadersWidth - textSize.Width) / 2;
                float yPosition = e.RowBounds.Top + (e.RowBounds.Height - textSize.Height) / 2;

                // 4. Tiến hành vẽ chuỗi số thứ tự lên vùng đồ họa của Row Header
                e.Graphics.DrawString(rowNumber, rowFont, rowBrush, xPosition, yPosition);
            }
        }

        /// <summary>
        /// Sự kiện vẽ chữ "STT" lên ô góc trên cùng bên trái (Top-Left Header) của DataGridView
        /// </summary>
        public static void DrawHeaderSTT(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Kiểm tra xem ô hiện tại đang vẽ có phải là ô góc trên cùng bên trái không
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                // Yêu cầu hệ thống tự vẽ nền, đường viền mặc định của ô trước
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Khởi tạo chuỗi chữ cần hiển thị và định dạng font
                string headerText = "STT";
                Font headerFont = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
                Brush headerBrush = SystemBrushes.ControlText;

                // Tính toán kích thước thực tế của chữ "STT" bằng pixel
                var textSize = e.Graphics.MeasureString(headerText, headerFont);

                // Thuật toán tính toán tọa độ X, Y để căn chữ nằm chính giữa ô
                float xPosition = e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2;
                float yPosition = e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2;

                // Tiến hành vẽ chữ "STT" đè lên lớp nền đã được tạo
                e.Graphics.DrawString(headerText, headerFont, headerBrush, xPosition, yPosition);

                // Báo hiệu cho WinForm biết ô này đã được xử lý vẽ hoàn tất
                e.Handled = true;
            }
        }

        /// <summary>
        /// Hàm Common tự động cấu hình tiêu đề cột (Header) từ Database qua Python API
        /// </summary>
        /// <param name="grid">Đối tượng DataGridView cần tác động</param>
        /// <param name="reportCode">Mã báo cáo/màn hình để tra cứu cấu hình (Ví dụ: "0100")</param>
        // Thay thế hàm LoadDynamicHeaders cũ bằng hàm async này
        public static async Task LoadDynamicHeadersAsync(DataGridView grid, string reportCode)
        {
            try
            {
                string url = $"{ApiConfig.ColumnConfigUrl}?report_code={Uri.EscapeDataString(reportCode)}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url); // async, không deadlock
                    string jsonString = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Lỗi lấy cấu hình cột: " + response.StatusCode, "Lỗi API");
                        return;
                    }

                    var apiResult = JsonConvert.DeserializeObject<ApiHeaderResponse>(jsonString);

                    if (apiResult == null || !apiResult.success || apiResult.columns == null)
                    {
                        MessageBox.Show("Dữ liệu cấu hình không hợp lệ.", "Lỗi");
                        return;
                    }

                    grid.Columns.Clear();

                    foreach (var col in apiResult.columns)
                    {
                        var dgvCol = new DataGridViewTextBoxColumn
                        {
                            Name = col.column_name,
                            HeaderText = col.header_text,
                            DataPropertyName = col.column_name
                        };

                        // Format ngày nếu cần
                        if (col.column_name == "ID_DT" || col.column_name == "WORK_DT" || col.column_name == "UPD_DT")
                            dgvCol.DefaultCellStyle.Format = "dd/MM/yyyy";

                        grid.Columns.Add(dgvCol);
                    }

                    grid.ReadOnly = true;
                    grid.AllowUserToAddRows = false;
                    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Đăng ký STT helper (tránh đăng ký trùng)
                    grid.RowPostPaint -= DrawRowNumbers;
                    grid.CellPainting -= DrawHeaderSTT;
                    grid.RowPostPaint += DrawRowNumbers;
                    grid.CellPainting += DrawHeaderSTT;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo lưới: " + ex.Message, "Hệ Thống Lỗi");
            }
        }

        // Cập nhật class nhận JSON từ Python (đổi tên field cho khớp)
        public class DynamicHeader
        {
            public string column_name { get; set; }
            public string header_text { get; set; }
            public int seq { get; set; }
        }

        public class ApiHeaderResponse
        {
            public bool success { get; set; }
            public List<DynamicHeader> columns { get; set; }
            public string error { get; set; }
        }

    }
}