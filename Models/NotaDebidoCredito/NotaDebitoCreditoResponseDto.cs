namespace FacturacionDigital_SIGECE.Models.NotaDebidoCredito
{
    public class NotaDebitoCreditoResponseDto
    {
        public int code { get; set; }
        public int TotalFacturasProcedas { get; set; }
        public int totalFacturasNew { get; set; }
        public int totalFacturaconError { get; set; }
        public int totalIngrsosCliente { get; set; }
        public int totalErrorFactura { get; set; }
        public List<List<DetalleErrorFactura>> DetalleErrorFacturas { get; set; }
        public List<List<DetalleFacturaProcesadas>> DetalleFacturaProcesadas { get; set; }
    }

    public class DetalleErrorFactura
    {
        public int? posicion { get; set; }
        public string NroFactura { get; set; }
        public string Msg { get; set; }
    }

    public class DetalleFacturaProcesadas
    {
        public string NroFactura { get; set; }
        public string NroControl { get; set; }
        public string Cliente { get; set; }
        public string Msg { get; set; }
    }
}
