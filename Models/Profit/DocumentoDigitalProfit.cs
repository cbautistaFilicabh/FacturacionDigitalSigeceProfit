using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDigital_SIGECE.Models.Profit
{
    public class DocumentoDigitalProfit
    {
        public string TipoDoc { get; set; }
        public string NroDoc { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Rif { get; set; }
        public string RazonSocial { get; set; }
        public string Moneda { get; set; }
        public decimal Tasa { get; set; }
        public decimal MontoBaseImponible { get; set; }  // Monto base imponible del documento  
        public decimal MontoIva { get; set; }  // Monto del descuento aplicado al documento
        public decimal MontoTotalDocumento { get; set; }  // Monto total del documento después de aplicar impuestos y descuentos
        public string Estado { get; set; }  // Estado del documento (Ej. "Enviado", "Pendiente", etc.)
        public DateTime FechaEnvio { get; set; }  // Fecha de envío del documento

        public string ControlAsignado { get; set; }









    }
}
