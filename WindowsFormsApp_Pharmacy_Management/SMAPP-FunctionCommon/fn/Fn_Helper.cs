using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Pharmacy_Management.SMAPP_FunctionCommon.fn
{
    public static class Alert
    {
        public static void Show(string message, frm_Notification.NotificationType type = frm_Notification.NotificationType.Success)
        {
            frm_Notification toast = new frm_Notification(message, type);
            toast.Show(); // Sử dụng Show() thay vì ShowDialog() để không block luồng xử lý chính
        }
    }
}
