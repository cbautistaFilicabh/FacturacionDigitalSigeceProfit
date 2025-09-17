using System.Configuration;

namespace FacturacionDigital_SIGECE.AppUtilities
{
    public static class AppConfig
    {
        public static string ApiBaseUrl = (ConfigurationManager.AppSettings["url"] ?? string.Empty).Trim();
        public static string Email = (ConfigurationManager.AppSettings["email"] ?? string.Empty).Trim();
        public static string Password = (ConfigurationManager.AppSettings["password"] ?? string.Empty).Trim();
        public static string SessionToken = string.Empty;
        public static DateTime TokenExpiration { get; set; } = DateTime.MinValue;
    }
}
