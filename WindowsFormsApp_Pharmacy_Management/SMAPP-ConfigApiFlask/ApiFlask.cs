using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_Pharmacy_Management.SMAPP_ConfigApiFlask
{
    public static class ApiConfig
    {
        // 1. Địa chỉ gốc của Server Flask
        // Sau này nếu đổi Server, bạn chỉ cần sửa duy nhất dòng này
        public const string BaseUrl = "http://127.0.0.1:5000";

        // 2. Danh sách các Endpoint (Đường dẫn chi tiết)

        // --- Module User / Hệ thống ---
        public static string LoginUrl => $"{BaseUrl}/api/users/login"; 
        public static string ChangePassUrl => $"{BaseUrl}/api/users/change_password";
        public static string UserInfoUrl => $"{BaseUrl}/api/users/search";
        public static string UserIudUrl => $"{BaseUrl}/api/users/iud";

        // --- Module Khách hàng ---
        public static string CustomerSearchUrl => $"{BaseUrl}/api/custinfo/search"; 
        public static string CustomerIudUrl => $"{BaseUrl}/api/custinfo/iud";

        // --- Module Sản phẩm ---
        public static string ProductSearchUrl => $"{BaseUrl}/api/products/search";
        public static string ProductIudUrl => $"{BaseUrl}/api/products/iud";

        // --- Module Bán hàng ---
        public static string SalesSearchUrl => $"{BaseUrl}/api/sales/search";
        public static string SalesCreateUrl => $"{BaseUrl}/api/sales/create";
    }
}
