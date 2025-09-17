using System.ComponentModel.DataAnnotations;

namespace FacturacionDigital_SIGECE.Models.NotaDebidoCredito
{
    public class NotaDebitoCreditoRequestDto
    {
        [Required]
        [MaxLength(12)]
        public string Rif { get; set; }

        [MaxLength(9)]
        public int? CodigoSucursal { get; set; }

        [Required]
        [MaxLength(9)]
        public required string NroFactura { get; set; }

        [Required]
        [MaxLength(9)]
        public required string NroNota { get; set; }

        [Required]
        public required string Tipo { get; set; }

        [MaxLength(2)]
        public string? Serie { get; set; }

        [Required]
        [MaxLength(1)]
        public required int Categoria { get; set; }

        [Required]
        [MaxLength(99)]
        public required string Concepto { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal ImporteTotal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal Subtotal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal MontoDescuento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal TotalExento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal TotalExonerado { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal TasaCambio { get; set; }

        [Required]
        [MaxLength(3)]
        public required string FacturaDivisa { get; set; }

        [Required]
        public required List<DetalleNota> IstDetallesNota { get; set; }

        [Required]
        public required List<GravamenNota>? IstGravamenes { get; set; }
    }

    public class DetalleNota
    {
        [Required]
        [MaxLength(30)]
        public required string CodigoProducto { get; set; }

        [Required]
        [MaxLength(250)] // El documento indica 250 para descripción del producto en Facturas Generales, asumo lo mismo aquí.
        public required string Descripcion { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal Cantidad { get; set; }

        [Required]
        [MaxLength(10)]
        public string UnidadMedida { get; set; }

        [MaxLength(20)]
        public decimal? CantidadOriginal { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal Precio { get; set; }

        [MaxLength(20)]
        public decimal? PrecioOriginal { get; set; }

        [MaxLength(20)]
        public decimal? PrecioDevolucion { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal Importe { get; set; }

        public bool? Exento { get; set; }

        public bool? Exonerado { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal AlicuotaGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal MontoGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal Descuento { get; set; }

        [Required]
        [MaxLength(20)]
        public required decimal MontoDescuento { get; set; }
    }

    public class GravamenNota
    {
        [Required]
        [MaxLength(20)]
        public decimal BaseImponible { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal Alicuota { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal MontoAlicuota { get; set; }
    }
}
