using FacturacionDigital_SIGECE.AppUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FacturacionDigital_KatanaPanama.Class
{
    public static class ApiLogger
    {
        /// <summary>
        /// Registra en un archivo .txt el JSON enviado y la respuesta recibida.
        /// Controlado por la configuración del App.config (ApiLoggingEnabled / ApiLogDirectory).
        /// </summary>
        public static void LogRequestAndResponse(string endpoint, string requestJson, string responseJson, string tipoDocumento)
        {
            // Verifica si el log está habilitado en App.config
            if (!AppConfig.ApiLoggingEnabled)
                return;

            try
            {
                string logDirectory = AppConfig.ApiLogDirectory;

                // Crea la carpeta si no existe
                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                // Limpia el nombre del tipo de documento para que sea válido
                tipoDocumento = SanitizeFileName(tipoDocumento);

                // Genera el nombre del archivo con timestamp
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
                string fileName = Path.Combine(logDirectory, $"ApiLog_{tipoDocumento}_{timestamp}.txt");

                // Escribe el contenido del log
                File.WriteAllText(fileName,
                    $"Fecha: {DateTime.Now}\r\n" +
                    $"Tipo de Documento: {tipoDocumento}\r\n" +
                    $"Endpoint: {endpoint}\r\n\r\n" +
                    $"--- REQUEST ---\r\n{requestJson}\r\n\r\n" +
                    $"--- RESPONSE ---\r\n{responseJson}");
            }
            catch (Exception ex)
            {
                // No interrumpe la ejecución del programa si hay un error al guardar el log
                Console.WriteLine($"[ApiLogger] Error al guardar el log: {ex.Message}");
            }
        }

        /// <summary>
        /// Reemplaza caracteres no válidos para nombres de archivo.
        /// </summary>
        private static string SanitizeFileName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "SinTipo";

            // Solo permite letras, números, guiones y guiones bajos
            return Regex.Replace(input, @"[^\w\-]", "_");
        }
    }

}
