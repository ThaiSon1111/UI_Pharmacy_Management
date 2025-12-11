using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Pharmacy_Management
{
    public static class SessionManager
    {
        // Thuộc tính tĩnh để lưu trữ Tên đăng nhập của người dùng hiện tại
        public static string LoggedInUsername { get; private set; } = string.Empty;

        // Phương thức để thiết lập tên đăng nhập sau khi đăng nhập thành công
        public static void SetLoggedInUser(string username)
        {
            LoggedInUsername = username;
        }

        // Phương thức để xóa tên đăng nhập khi người dùng đăng xuất
        public static void ClearUser()
        {
            LoggedInUsername = string.Empty;
        }

        // Phương thức kiểm tra xem người dùng đã đăng nhập chưa
        public static bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(LoggedInUsername);
        }
    }
}
