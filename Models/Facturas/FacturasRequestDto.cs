using System.ComponentModel.DataAnnotations;

namespace FacturacionDigital_SIGECE.Models.Facturas
{
    public class FacturasRequestDto
    {
        [Required]
        [MaxLength(12)]
        public string Rif { get; set; }

        [Required]
        [MaxLength(20)]
        public string NroFactura { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal ImporteTotal { get; set; }

        [MaxLength(16)]
        public string CodigoSucursal { get; set; }

        [MaxLength(2)]
        public string Serie { get; set; }

        [MaxLength(2)]
        public string SerieNrofactura { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal SubTotal { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal MontoDescuento { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal TotalExento { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal TotalExonerado { get; set; }

        [Required]
        [MaxLength(10)]
        public string CondicionPago { get; set; }

        [Required]
        [MaxLength(3)]
        public string FacturaDivisa { get; set; }

        [Required]
        [MaxLength(15)]
        public decimal CambioDivisa { get; set; }

        [Required]
        [MaxLength(15)]
        public decimal TipoCambioDiaUsd { get; set; }

        [Required]
        public bool TipoColetilla { get; set; }

        [Required]
        [MaxLength(10)]
        public string TipoVenta { get; set; }

        [MaxLength(9)]
        public int? DiasCredito { get; set; }

        public string FechaVenciFactura { get; set; }

        [MaxLength(10)]
        public string? EstatusCredito { get; set; }

        public string FechaVencimiento { get; set; }

        [Required]
        [MaxLength(10)]
        public string ModeloFactura { get; set; }

        [MaxLength(15)]
        public string PagueAntes { get; set; }

        public bool CuentaTerceros { get; set; }

        [Required]
        [MaxLength(12)]
        public string RifPrestador { get; set; }

        public bool ColetillaIGTF { get; set; }

        [MaxLength(20)]
        public string NroContrato { get; set; }

        [MaxLength(100)]
        public string Observacion { get; set; }

        [MaxLength(100)]
        public string ObservacionInfo { get; set; }

        [Required]
        public ClienteDto Cliente { get; set; }

        [Required]
        public List<DetalleFacturaDto> IstDetallesFacturaGeneral { get; set; }

        public List<PagoDto> IstPagos { get; set; }

        public List<GravamenDto> IstGravamenes { get; set; }
    }

    public class ClienteDto
    {
        [Required]
        public bool ContribuyenteEspecial { get; set; }

        [Required]
        [MaxLength(1)]
        public string TipoDocumento { get; set; }

        [Required]
        [MaxLength(9)]
        public string NumeroDocumento { get; set; }

        [Required]
        [MaxLength(90)]
        public string Identificacion { get; set; }

        [Required]
        [MaxLength(200)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(12)]
        public string TelefonoMovil { get; set; }

        [Required]
        [MaxLength(50)]
        public string Correo { get; set; }

        [MaxLength(50)]
        public string CcCorreo { get; set; } // campo nuevo en JSON

        [Required]
        [MaxLength(20)]
        public string TipoPersona { get; set; }

        [Required]
        [MaxLength(4)]
        public string TipoProveedor { get; set; }
    }

    public class DetalleFacturaDto
    {
        [Required]
        [MaxLength(30)]
        public string CodigoProducto { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(10)]
        public string UnidadMedida { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal Cantidad { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal Precio { get; set; }

        public bool Exento { get; set; }

        [Required]
        public bool Exonerado { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal Importe { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal AlicuotaGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal MontoGravamen { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal MontoDescuento { get; set; }

        [Required]
        [MaxLength(20)]
        public decimal Descuento { get; set; }

        [MaxLength(20)]
        public string Nrolote { get; set; }

        [MaxLength(250)]
        public string FechaVenciProducto { get; set; }
    }

    public class PagoDto
    {
        [MaxLength(10)]
        public string ModoPago { get; set; }

        [MaxLength(15)]
        public string Nro { get; set; }

        [MaxLength(15)]
        public decimal Monto { get; set; }

        [MaxLength(10)]
        public string FechaComprobantePago { get; set; }

        [MaxLength(200)]
        public string Banco { get; set; } // no estaba en JSON de ejemplo, pero sí en tu clase inicial

        [MaxLength(3)]
        public string Divisa { get; set; }

        [MaxLength(3)]
        public decimal TasaDiaDivisa { get; set; }

        [MaxLength(15)]
        public int DiasCredito { get; set; }

        public bool Igtf { get; set; } // JSON lo manda como string
    }

    public class GravamenDto
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
