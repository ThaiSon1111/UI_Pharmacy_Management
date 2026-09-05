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
        /// Hàm dựng Header giao diện tự động từ mảng Schema nhận được dưới Database
        /// </summary>
        /// <param name="dgv">DataGridView cần dựng tiêu đề</param>
        /// <param name="headersArray">Mảng JArray chứa schema headers nhận từ API</param>
        public static void SetupDynamicColumns(DataGridView dgv, JArray headersArray)
        {
            if (dgv == null || headersArray == null) return;

            // 1. Tắt chế độ tự sinh cột bừa bãi và xóa toàn bộ cột cũ
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            // 2. Kích hoạt thuộc tính thanh cuộn ngang/dọc tránh bị mất cột khi kéo rộng
            dgv.ScrollBars = ScrollBars.Both;

            // 3. Duyệt mảng cấu hình từ Database gửi sang để thiết lập cột mới tuần tự
            foreach (var header in headersArray)
            {
                string colName = header["col_name"]?.ToString();
                string headerText = header["header_text"]?.ToString();

                if (!string.IsNullOrEmpty(colName))
                {
                    DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
                    newColumn.Name = colName;
                    newColumn.DataPropertyName = colName; // Khớp trường dữ liệu Mapping với JSON data
                    newColumn.HeaderText = headerText ?? colName; // Đổi chữ Tiếng Việt hiển thị lên UI
                    newColumn.AutoSizeMode = DataGridViewColumnAutoSizeMode.DisplayedCells; // Tự giãn theo nội dung dữ liệu

                    dgv.Columns.Add(newColumn);
                }
            }
        }
    }
}