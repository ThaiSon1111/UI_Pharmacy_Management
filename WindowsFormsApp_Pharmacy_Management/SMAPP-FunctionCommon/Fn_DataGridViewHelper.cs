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
        public static void LoadDynamicHeaders(DataGridView grid, string reportCode)
        {
            try
            {
                // Khởi tạo HttpClient để gửi request lên Python Service
                using (HttpClient client = new HttpClient())
                {
                    // Lấy logic từ hàm btnSearch_Click và chỉnh sửa lại
                    string apiUrl = SMAPP_ConfigApiFlask.ApiConfig.getheaderreport;

                    // Thực hiện gọi API đồng bộ (.Result) để lấy chuỗi dữ liệu cấu hình trước khi lưới render
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Đọc nội dung chuỗi JSON phản hồi từ Service
                        string jsonString = response.Content.ReadAsStringAsync().Result;

                        // Phân tích cú pháp JSON sang đối tượng Class C# để dễ bóc tách dữ liệu
                        var apiResult = JsonConvert.DeserializeObject<ApiHeaderResponse>(jsonString);

                        if (apiResult != null && apiResult.success && apiResult.headers != null)
                        {
                            // 1. XÓA TOÀN BỘ CỘT CŨ: Đảm bảo lưới sạch sẽ trước khi dựng cột động
                            grid.Columns.Clear();

                            // 2. TẠO CỘT STT MẶC ĐỊNH: Tạo thủ công cột Số Thứ Tự ở đầu lưới giống giao diện hiện tại
                            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                            //sttColumn.Name = "STT";
                            //sttColumn.HeaderText = "STT";
                            //sttColumn.Width = 45;
                            //grid.Columns.Add(sttColumn);

                            // 3. VÒNG LẶP DỰNG CỘT ĐỘNG: Duyệt qua danh sách cấu hình lấy từ Oracle DB
                            foreach (var header in apiResult.headers)
                            {
                                DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();

                                // Định danh tên cột trong code (Dùng khi cần truy cập col theo Name)
                                dgvCol.Name = header.COLUMN_NAME;

                                // Tiêu đề hiển thị lên thanh Header của Grid (Tiếng Việt có dấu)
                                dgvCol.HeaderText = header.HEADER_TEXT;

                                // ÁNH XẠ DATA: Liên kết chính xác với tên trường trong JSON dữ liệu User trả về
                                dgvCol.DataPropertyName = header.COLUMN_NAME;

                                // Gán trực tiếp đối tượng cột vừa thiết lập vào DataGridView
                                grid.Columns.Add(dgvCol);

                            }
                        }
                        else if (apiResult != null)
                        {
                            MessageBox.Show("Lỗi cấu hình từ hệ thống: " + apiResult.error, "Thông Báo Lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể kết nối tới dịch vụ cấu hình giao diện!", "Lỗi Kết Nối API");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi khởi tạo lưới động: " + ex.Message, "Hệ Thống Lỗi");
            }
        }

        // --- CÁC CLASS ĐỊNH NGHĨA ĐỂ TRUYỀN NHẬN DỮ LIỆU JSON ---
        public class DynamicHeader
        {
            public string COLUMN_NAME { get; set; }
            public string HEADER_TEXT { get; set; }
        }

        public class ApiHeaderResponse
        {
            public bool success { get; set; }
            public List<DynamicHeader> headers { get; set; }
            public string error { get; set; }
        }
    }
}