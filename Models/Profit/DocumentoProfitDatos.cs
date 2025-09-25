using System;
using System.Collections.Generic;

namespace FacturacionDigital_SIGECE.Models.Profit
{
    // Clase principal que agrupa encabezado y detalles
    public class DocumentoProfitsf
    {
        public EncabezadoDocumentoProfit Encabezado { get; set; } = new EncabezadoDocumentoProfit();
        public List<DetalleDocProfit> Detalles { get; set; } = new List<DetalleDocProfit>();
    }

    public class EncabezadoDocumentoProfit
    {
        // Identificación documento y cliente
        public string? TipoDoc { get; set; }                     

        public string? NroDoc { get; set; }                      
        public string? NroControl { get; set; }                  
        public DateTime? FecEmis { get; set; }                   
        public DateTime? FecVenc { get; set; }                   
        public string? Serie { get; set; }                       
        public string? Sucursal { get; set; }                    
        public string? TipoDeVenta { get; set; }                 
        public string? RifEmisor { get; set; }                  

        //datos del cliente
        public string? CoCli { get; set; }                      

        public string? CliDes { get; set; }                     
        public string? CoPais { get; set; }                     
        public string? Rif { get; set; }                        
        public string? TipoIdentificacion { get; set; }         
        public string? NumeroIdentificacion { get; set; }       
        public string? DireccionComercial { get; set; }
        public string? DireccionEntrega { get; set; }
        public string? Email { get; set; }
        public string? Telefonos { get; set; }
        public bool? contribuyenteEspecial { get; set; }
        public string? tipoPersona { get; set; }

        // Comentarios / campos libres
        public string? ComentarioGeneral { get; set; }

        public string? InfoAdicional1 { get; set; }
        public string? InfoAdicional2 { get; set; }
        public string? InfoAdicional3 { get; set; }
        public string? InfoAdicional4 { get; set; }
        public string? InfoAdicional5 { get; set; }
        public string? InfoAdicional6 { get; set; }
        public string? InfoAdicional7 { get; set; }
        public string? InfoAdicional8 { get; set; }
        public string? Descripcion { get; set; }

        // Vendedor / condición pago
        public string? CoVen { get; set; }                      

        public string? VenDes { get; set; }                     
        public string? CoCond { get; set; }                     
        public string? CondDes { get; set; }                    
        public int DiasCredito { get; set; }                   
        public string? CoTran { get; set; }                    
        public string? DesTran { get; set; }                   

        // Descuentos / recargos / totales doc
        public decimal? PorcGdesc { get; set; }           

        public decimal? MontoDescGlob { get; set; }       
        public decimal? PorcIva { get; set; }             
        public decimal? MontoImp { get; set; }            
        public decimal? MontoGravadoTotal { get; set; }   
        public decimal? MontoExentoTotal { get; set; }    
        public bool? Anulado { get; set; }                
        public decimal? BaseIgtf { get; set; }            

        public decimal? Igtf { get; set; }                

        public decimal? TotalGeneral { get; set; }        

        public decimal? SubTotal { get; set; }            

        public decimal TotalExonerado { get; set; }       
        public decimal? Tasa { get; set; }                
        public string? CoMone { get; set; }               

        public string? NumeroPlanillaExportacion { get; set; }
        public string? NumeroExpedienteExportacion { get; set; }
        public string? FiscalNumeroDoc { get; set; }
        public string? FiscalImpresora { get; set; }
        public string? FiscalNumeroZ { get; set; }

        //Datos que se usan para notas de credito y debito
        public string? SerieFacturaAfectada { get; set; }
        public string? NumeroFacturaAfectada { get; set; }
        public DateTime? FechaFacturaAfectada { get; set; }
        public decimal? MontoFacturaAfectada { get; set; }
        public string? ComentarioFacturaAfectada { get; set; }

    }

    public class DetalleDocumentoProfit
    {
        public int? NroRenglon { get; set; }
        public string? CodigoArticulo { get; set; }
        public string? DescripcionArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? UnidadDeMedida { get; set; }
        public string? DescripcionUnidadDeMedida { get; set; }
        public string Almacen { get; set; }
        public decimal PorcIvaRenglon { get; set; }
        public decimal IvaMontoRenglon { get; set; }
        public decimal BaseImponibleRenglon { get; set; }
        public decimal ExentoRenglon { get; set; }
        public string? nrolote { get; set; }
        public DateTime? fechaVenciProducto { get; set; }
        public decimal Subtotal { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal PorcDescuento { get; set; }
        public decimal TotalRenglon { get; set; }
        public string? ComentarioRenglon { get; set; }
    }
}