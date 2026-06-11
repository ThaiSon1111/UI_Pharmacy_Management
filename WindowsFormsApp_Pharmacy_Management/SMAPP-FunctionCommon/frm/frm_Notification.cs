using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon
{
    public partial class frm_Notification : Form
    {
        public frm_Notification(string message, NotificationType type)
        {
            InitializeComponent();
            lbl_Message.Text = message;

            // Tùy biến màu sắc dựa theo loại hành động
            switch (type)
            {
                case NotificationType.Success:
                    this.BackColor = Color.FromArgb(40, 167, 69); // Màu xanh lá thành công
                    break;
                case NotificationType.Error:
                    this.BackColor = Color.FromArgb(220, 53, 69); // Màu đỏ nếu lỗi
                    break;
                case NotificationType.Info:
                    this.BackColor = Color.FromArgb(23, 162, 184); // Màu xanh dương thông tin
                    break;
            }
        }

        // Định nghĩa các kiểu thông báo
        public enum NotificationType
        {
            Success,
            Error,
            Info
        }

        private void frm_Notification_Load(object sender, EventArgs e)
        {
            // Thiết lập vị trí góc dưới cùng bên phải màn hình
            // Lấy kích thước vùng làm việc của màn hình (trừ đi thanh Taskbar)
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            int x = workingArea.Right - this.Width - 10;  // Cách lề phải 10px
            int y = workingArea.Bottom - this.Height - 10; // Cách lề dưới 10px

            this.Location = new Point(x, y);

            // Kích hoạt bộ đếm thời gian tự đóng
            timer_Close.Start();
        }

        // Sự kiện Tick của Timer (Nhấp đúp vào Timer ở giao diện Designer để sinh ra hàm này)
        private void timer_Close_Tick(object sender, EventArgs e)
        {
            timer_Close.Stop();
            this.Close(); // Tự giải phóng và đóng form thông báo
        }

        private void pic_Icon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
