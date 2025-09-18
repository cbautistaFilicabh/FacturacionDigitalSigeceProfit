using FacturacionDigital_SIGECE.Forms;
using FacturacionDigital_SIGECE.Services;

namespace FacturacionDigital_SIGECE
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ProfitService profitService = new ProfitService();
            profitService.BuscarDocumentosDigitales(null, DateTime.Now.AddYears(-1), DateTime.Now);
            profitService.BuscarFacturaDigital("1753");

            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
    }
}