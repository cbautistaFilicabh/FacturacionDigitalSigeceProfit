namespace FacturacionDigital_SIGECE.Models.Retenciones
{
    public class RetencionResponseDto
    {
        public int TotalRetencionIvaconError { get; set; }
        public List<DetalleErrorRetencion> DetalleErrorRetencionesIva { get; set; } = new List<DetalleErrorRetencion>();
        public int TotalRentecionIvaProcedas { get; set; }
        public List<DetalleRetencionProcesada> DetalleretencionesProcesadas { get; set; } = new List<DetalleRetencionProcesada>();
    }

    public class DetalleRetencionProcesada
    {
        public string msg { get; set; } = "";
        public string NroControlComprobante { get; set; } = "";
        public string nroComprobante { get; set; } = "";
    }

    public class DetalleErrorRetencion
    {
        public string msg { get; set; } = "";
    }
}
