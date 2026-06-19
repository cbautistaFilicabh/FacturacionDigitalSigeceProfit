using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace FacturacionDigital_SIGECE.AppUtilities
{
    public static class AppConfig
    {
        public static string ApiBaseUrl = (ConfigurationManager.AppSettings["url"] ?? string.Empty).Trim();
        public static string Email = (ConfigurationManager.AppSettings["email"] ?? string.Empty).Trim();
        public static string Password = (ConfigurationManager.AppSettings["password"] ?? string.Empty).Trim();
        public static string SessionToken = string.Empty;
        public static string CadenaConexion = ConfigurationManager.ConnectionStrings["Connection String"].ConnectionString;
        public static DateTime TokenExpiration { get; set; } = DateTime.MinValue;
        public static bool ApiLoggingEnabled = bool.TryParse(ConfigurationManager.AppSettings["ApiLoggingEnabled"], out bool enabled);
        public static string ApiLogDirectory = Directory.CreateDirectory(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs")).FullName;
        public static bool versionProfit2k8 = bool.TryParse(ConfigurationManager.AppSettings["versionProfit2k8"], out bool enabled);

    }
}
