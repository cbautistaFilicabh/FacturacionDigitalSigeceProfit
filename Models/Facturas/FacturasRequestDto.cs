using System.ComponentModel.DataAnnotations;

namespace FacturacionDigital_SIGECE.Models.Facturas
{
    public class FacturasRequestDto
    {
        [Required]
        [MaxLength(12)]
        public required string rif { get; set; }

        [Required]
        [MaxLength(20)]
        public required string nroFactura { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal importeTotal { get; set; }

        [MaxLength(16)]
        public string? codigoSucursal { get; set; }

        [MaxLength(2)]
        public string? serie { get; set; }

        [MaxLength(2)]
        public string? serieNrofactura { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal subTotal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoDescuento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal totalExento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal totalExonerado { get; set; }

        [Required]
        [MaxLength(10)]
        public required string condicionPago { get; set; }

        [Required]
        [MaxLength(3)]
        public required string facturaDivisa { get; set; }

        [Required]
        [MaxLength(15)]
        public required decimal cambioDivisa { get; set; }

        [Required]
        [MaxLength(15)]
        public required decimal tipoCambioDiaUsd { get; set; }

        [Required]
        public required bool tipoColetilla { get; set; }

        [Required]
        [MaxLength(10)]
        public required string tipoVenta { get; set; }

        [MaxLength(9)]
        public int? diasCredito { get; set; }

        [MaxLength(250)]
        public string? fechaVenciFactura { get; set; }

        [MaxLength(10)]
        public string? estatusCredito { get; set; }

        [MaxLength(250)]
        public string? fechaVencimiento { get; set; }

        [Required]
        [MaxLength(10)]
        public required string modeloFactura { get; set; }

        [MaxLength(15)]
        public string? pagueAntes { get; set; }

        public bool cuentaTerceros { get; set; }

        [Required]
        [MaxLength(12)]
        public required string rifPrestador { get; set; }

        public bool coletillaIGTF { get; set; }

        [MaxLength(20)]
        public string? nroContrato { get; set; }

        [MaxLength(100)]
        public string? observacion { get; set; }

        [MaxLength(100)]
        public string? observacionInfo { get; set; }

        [Required]
        public required ClienteDto cliente { get; set; }

        [Required]
        public required List<DetalleFacturaDto> lstDetallesFacturaGeneral { get; set; }

        public List<PagoDto>? lstPagos { get; set; }

        public List<GravamenDto>? lstGravamenes { get; set; }
    }

    public class ClienteDto
    {
        [Required]
        public bool contribuyenteEspecial { get; set; }

        [Required]
        [MaxLength(1)]
        public required string tipoDocumento { get; set; }

        [Required]
        [MaxLength(9)]
        public required string numeroDocumento { get; set; }

        [Required]
        [MaxLength(90)]
        public required string identificacion { get; set; }

        [Required]
        [MaxLength(200)]
        public required string direccion { get; set; }

        [Required]
        [MaxLength(12)]
        public required string telefonoMovil { get; set; }

        [Required]
        [MaxLength(50)]
        public required string correo { get; set; }

        [MaxLength(50)]
        public string? ccCorreo { get; set; } // campo nuevo en JSON

        [Required]
        [MaxLength(20)]
        public required string tipoPersona { get; set; }

        [Required]
        [MaxLength(4)]
        public required string tipoProveedor { get; set; }
    }

    public class DetalleFacturaDto
    {
        [Required]
        [MaxLength(30)]
        public required string codigoProducto { get; set; }

        [Required]
        [MaxLength(250)]
        public required string descripcion { get; set; }

        [Required]
        [MaxLength(10)]
        public required string unidadMedida { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal cantidad { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal precio { get; set; }

        public bool exento { get; set; }

        [Required]
        public required bool exonerado { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal importe { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal alicuotaGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoDescuento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal descuento { get; set; }

        [MaxLength(20)]
        public string? nrolote { get; set; }

        [MaxLength(250)]
        public string? fechaVenciProducto { get; set; }
    }

    public class PagoDto
    {
        [MaxLength(10)]
        public string? modoPago { get; set; }

        [MaxLength(15)]
        public string? nro { get; set; }

        [MaxLength(15)]
        public decimal? monto { get; set; }

        [MaxLength(10)]
        public string? fechaComprobantePago { get; set; }

        [MaxLength(200)]
        public string? banco { get; set; } // no estaba en JSON de ejemplo, pero sí en tu clase inicial

        [MaxLength(3)]
        public string? divisa { get; set; }

        [MaxLength(3)]
        public decimal? tasaDiaDivisa { get; set; }

        [MaxLength(15)]
        public int? diasCredito { get; set; }

        public bool igtf { get; set; } // JSON lo manda como string
    }

}
