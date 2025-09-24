namespace FacturacionDigital_SIGECE.Models.NotaDebidoCredito
{
    public class NotaDebitoCreditoResponseDto
    {
        public int code { get; set; }
        public int TotalNotasProcedas { get; set; }
        public int totalNotasNew { get; set; }
        public int totalNotasconError { get; set; }
        public List<List<DetalleErrorNotas>> DetalleErrorNotas { get; set; }
        public List<List<DetalleNotasProcesadas>> DetalleNotasProcesadas { get; set; }
    }

    public class DetalleErrorNotas
    {
        public string nroNota { get; set; }
        public string Msg { get; set; }
    }

    public class DetalleNotasProcesadas
    {
        public string serie { get; set; }
        public string nroNota { get; set; }
        public string nroControl { get; set; }
        public string Msg { get; set; }
    }
}
