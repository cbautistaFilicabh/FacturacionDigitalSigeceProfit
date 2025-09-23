using FacturacionDigital_SIGECE.AppUtilities;
using FacturacionDigital_SIGECE.Forms;
using FacturacionDigital_SIGECE.Services;
using FacturacionDigital_SIGECE.Services.Common;
using Newtonsoft.Json;
using Wise.Desktop.Helpers;
using WISE.Models.Auth;

namespace FacturacionDigital_SIGECE
{
    internal static class Program
    {
        static AuthService _authService = new AuthService();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            LogIn();
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }

        static void LogIn()
        {
            if (string.IsNullOrEmpty(AppConfig.SessionToken))
            {
                var request = new LoginRequestDto
                {
                    email = AppConfig.Email,
                    password = AppConfig.Password
                };

                var resultTask = _authService.LoginAsync(request);
                resultTask.Wait();
                var result = resultTask.Result;
            }
        }
    }
}