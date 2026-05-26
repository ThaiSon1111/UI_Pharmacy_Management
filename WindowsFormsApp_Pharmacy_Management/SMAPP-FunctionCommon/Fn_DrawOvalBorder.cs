using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon
{
    public static class ControlUIHelper
    {
        /// <summary>
        /// Hàm Common vẽ đường viền ô-von hỗ trợ cả TextBox thường và TextEdit DevExpress
        /// </summary>
        public static void DrawOvalBorder(Control targetControl, Graphics g, Color borderColor)
        {
            if (targetControl == null || g == null) return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // ĐỐI VỚI TEXTBOX THƯỜNG, NỚI RỘNG KHUNG VẼ LÊN 3 PIXEL ĐỂ ĐƯỜNG CONG ĐẸP HƠN
            int x = targetControl.Left - 3;
            int y = targetControl.Top - 3;
            int width = targetControl.Width + 6;
            int height = targetControl.Height + 6;

            using (Pen borderPen = new Pen(borderColor, 1.5f))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = height; // Bán kính bo tròn bằng chiều cao khung vẽ

                    path.AddArc(x, y, radius, radius, 180, 90);
                    path.AddArc(x + width - radius, y, radius, radius, 270, 90);
                    path.AddArc(x + width - radius, y + height - radius, radius, radius, 0, 90);
                    path.AddArc(x, y + height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    g.DrawPath(borderPen, path);
                }
            }
        }
    }
}