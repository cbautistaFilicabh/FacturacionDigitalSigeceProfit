using System.ComponentModel.DataAnnotations;

namespace FacturacionDigital_SIGECE.Models.NotaDebidoCredito
{
    public class NotaDebitoCreditoRequestDto
    {
        [Required]
        [MaxLength(12)]
        public string rif { get; set; }

        [MaxLength(9)]
        public int? codigoSucursal { get; set; }

        [Required]
        [MaxLength(9)]
        public required string nroFactura { get; set; }

        [Required]
        [MaxLength(9)]
        public required string nroNota { get; set; }

        [Required]
        public required string tipo { get; set; }

        [MaxLength(2)]
        public string? serie { get; set; }

        [Required]
        [MaxLength(1)]
        public required int categoria { get; set; }

        [Required]
        [MaxLength(99)]
        public required string concepto { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal importeTotal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal subtotal { get; set; }

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
        [MaxLength(20)]
        public required decimal tasaCambio { get; set; }

        [Required]
        [MaxLength(3)]
        public required string facturaDivisa { get; set; }

        [Required]
        public required List<List<DetalleNota>> lstDetallesNota { get; set; }

        [Required]
        public required List<List<GravamenDto>> lstGravamenes { get; set; }
    }

    public class DetalleNota
    {
        [Required]
        [MaxLength(30)]
        public required string codigoProducto { get; set; }

        [Required]
        [MaxLength(250)]
        public required string descripcion { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal cantidad { get; set; }

        [Required]
        [MaxLength(10)]
        public string unidadMedida { get; set; }

        [MaxLength(20)]
        public decimal? cantidadOriginal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal precio { get; set; }

        [MaxLength(20)]
        public decimal? precioOriginal { get; set; }

        [MaxLength(20)]
        public decimal? precioDevolucion { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal importe { get; set; }

        public bool? exento { get; set; }

        public bool? exonerado { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal alicuotaGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal descuento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal montoDescuento { get; set; }
    }
}
