using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; // Đảm bảo đã cài thư viện Newtonsoft.Json

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
        /// Hàm khởi tạo cấu trúc cột ĐỘNG cho DataGridView dựa trên cấu hình từ DB truyền về
        /// </summary>
        /// <param name="dgv">Tên DataGridView cần xử lý</param>
        /// <param name="headersJson">Mảng JSON headers nhận được từ API</param>
        public static void SetupDynamicColumns(DataGridView dgv, JArray headersJson)
        {
            if (dgv == null || headersJson == null) return;

            // 1. Xóa toàn bộ cấu hình cột cũ đang hiển thị trên UI (nếu có)
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = false; // Tắt tự sinh cột tự do để kiểm soát thứ tự tuyệt đối

            // 2. Duyệt qua danh sách cấu hình header đã được sắp xếp sẵn từ DB (theo seq)
            foreach (var item in headersJson)
            {
                string columnName = item["column_name"]?.ToString();
                string headerText = item["header_text"]?.ToString();
                bool isVisible = (item["is_visible"]?.ToObject<int>() ?? 1) == 1;
                int columnWidth = item["column_width"]?.ToObject<int>() ?? 120;

                if (string.IsNullOrEmpty(columnName)) continue;

                // 3. Khởi tạo cột mới bằng code
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.Name = columnName;                        // Định danh của cột
                col.DataPropertyName = columnName;            // Khớp chính xác với KEY trong mảng dữ liệu JSON "data"
                col.HeaderText = headerText;                  // Tiêu đề hiển thị tiếng Việt
                col.Visible = isVisible;                      // Ẩn/Hiện cột
                col.Width = columnWidth;                      // Độ rộng cột

                // Cấu hình định dạng bổ sung (tùy chọn)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // 4. Add cột vào Grid theo đúng thứ tự vòng lặp (đã xếp bằng seq từ DB)
                dgv.Columns.Add(col);
            }
        }
    }
}