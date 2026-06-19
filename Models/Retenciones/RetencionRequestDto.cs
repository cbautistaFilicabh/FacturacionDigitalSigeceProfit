using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace FacturacionDigital_SIGECE.Models.Retenciones
{
    public class RetencionRequestDto
    {
        /// <summary>
        /// Número de comprobante de retención en Profit (NroDoc del grid).
        /// Se usa solo internamente para registrar en sfEstadoDocumento; no se envía a la API.
        /// </summary>
        
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string NroDocProfit { get; set; } = "";
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public string TipoDocProfit { get; set; } = "";
        public string rif { get; set; } = "";
        public string periodoFiscalDel { get; set; } = "";
        public string periodoFiscalAl { get; set; } = "";
        public string rifProveedor { get; set; } = "";
        public string identificacion { get; set; } = "";
        public string direccion { get; set; } = "";
        public string correo { get; set; } = "";
        public string modeloRetencion { get; set; } = "";
        public string tipoDocumento { get; set; } = "";
        public string tasaRetencion { get; set; } = "";
        public List<RetencionItemDto> lstRetenciones { get; set; } = new List<RetencionItemDto>();
    }

    public class RetencionItemDto
    {
        public string tipoTransaccion { get; set; } = "";
        public string fechaDocumento { get; set; } = "";
        public string nroDocumento { get; set; } = "";
        public string nroNota { get; set; } = "";
        public string nroControlDocumento { get; set; } = "";
        public string montoTotalDocumento { get; set; } = "";
        public string baseImponible { get; set; } = "";

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? alicuota { get; set; }

        public string impuestoCausado { get; set; } = "";
        public string impuestoRetenido { get; set; } = "";
        public string compraExento { get; set; } = "";
        public string nroDocumentoAfectado { get; set; } = "";

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? conceptoIslr { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? causadoRetenido { get; set; }
    }
}
