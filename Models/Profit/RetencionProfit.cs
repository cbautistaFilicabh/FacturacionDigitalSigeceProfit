namespace FacturacionDigital_SIGECE.Models.Profit
{
    /// <summary>
    /// Modelo plano que representa una fila del SP sfConsultarDocumentosRetencionIva /
    /// sfConsultarDocumentosRetencionISLR. Cada fila contiene los datos del encabezado
    /// del comprobante (que se repiten en todas las filas) más los datos de un ítem de
    /// retención (lstRetenciones).
    /// </summary>
    public class RetencionProfit
    {
        // ─── Encabezado (se repite en cada fila del SP) ────────────────────────

        public string RifEmisor { get; set; } = "";
        public string NombreProv { get; set; } = "";
        public string RifProv { get; set; } = "";
        public string tipoRifProv { get; set; } = "";
        public string NumeroComprobante { get; set; } = "";
        public string NroDoc { get; set; } = "";
        public string TipoDoc { get; set; } = "";
        public string EmailProv { get; set; } = "";
        public string DireccionProv { get; set; } = "";
        public string TelefonoProv { get; set; } = "";

        /// <summary>Tipo de comprobante: "05" = IVA, "06" = ISLR</summary>
        public string TipoComprobante { get; set; } = "";

        public DateTime FechaEmision { get; set; }
        public DateTime? FechaEntrega { get; set; }

        /// <summary>Mes fiscal (1-12) para calcular el período fiscal</summary>
        public int mesfiscal { get; set; }

        /// <summary>Año fiscal para calcular el período fiscal</summary>
        public int annofiscal { get; set; }

        /// <summary>
        /// Indica si la empresa es contribuyente especial.
        /// true → períodos quincenales (1-15 / 16-fin de mes).
        /// false → período mensual completo.
        /// </summary>
        public bool esContribuyente { get; set; }

        // ─── Detalle de retención (varía por fila) ─────────────────────────────

        /// <summary>
        /// Para IVA  : tipo de transacción (01-REG, 02-AJUSNC, 03-AJUSND).
        /// Para ISLR : código de concepto ISLR (ej: "55").
        /// </summary>
        public string CodigoOperacion { get; set; } = "";

        public string DescripcionOperacion { get; set; } = "";
        public string NumeroControl { get; set; } = "";
        public string NumeroFactura { get; set; } = "";
        public string NumeroCredito { get; set; } = "";
        public string NumeroDebito { get; set; } = "";

        /// <summary>Número de documento relacionado / afectado (nroDocumentoAfectado)</summary>
        public string Relacionado { get; set; } = "";

        public DateTime FechaDocumento { get; set; }
        public decimal Exento { get; set; }
        public decimal Base { get; set; }
        public decimal Impuesto { get; set; }
        public decimal? sustraendopn { get; set; }
        public decimal alicuota { get; set; }
        public decimal PorcentajeRetenido { get; set; }
        public decimal MontoRetenido { get; set; }
        public decimal Total { get; set; }
    }
}
