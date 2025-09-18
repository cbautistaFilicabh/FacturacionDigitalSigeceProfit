using System;
using System.Collections.Generic;

namespace FacturacionDigital_SIGECE.Models.Profit
{
    // Clase principal que agrupa encabezado y detalles
    public class FacturaProfit
    {
        public EncabezadoFacturaProfit Encabezado { get; set; } = new EncabezadoFacturaProfit();
        public List<DetalleFacturaProfit> Detalles { get; set; } = new List<DetalleFacturaProfit>();
    }

    public class EncabezadoFacturaProfit
    {

        // Identificación documento y cliente
        public string? TipoDoc { get; set; }                      // '01'
        public string? NroDoc { get; set; }                       // dbo.sfExtraerNumeros(rtrim(f.doc_num))
        public DateTime? FecEmis { get; set; }                    // f.fec_emis
        public DateTime? FecVenc { get; set; }                    // f.fec_venc
        public string? Serie { get; set; }                        // dbo.sfExtraerText(rtrim(f.doc_num))
        public string? Sucursal { get; set; }                     // 'PPAL'
        public string? TipoDeVenta { get; set; }                  // 'INTERNA'
       

        //datos del cliente
        public string? CoCli { get; set; }                        // f.co_cli
        public string? CliDes { get; set; }                       // c.cli_des
        public string? CoPais { get; set; }                       // c.co_pais
        public string? Rif { get; set; }                          // c.rif
        public string? TipoIdentificacion { get; set; }           // left(c.rif,1)
        public string? NumeroIdentificacion { get; set; }         // substring(c.rif,2,len(c.rif))
        public string? DireccionComercial { get; set; }                       
        public string? DireccionEntrega { get; set; }                       
        public string? Email { get; set; } 
        public string? Telefonos { get; set; }

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
        public string? CoVen { get; set; }                        // f.co_ven
        public string? VenDes { get; set; }                       // v.ven_des
        public string? CoCond { get; set; }                       // con.co_cond
        public string? CondDes { get; set; }                      // con.cond_des
        public string? CoTran { get; set; }                       // T.co_tran
        public string? DesTran { get; set; }                      // T.des_tran


        // Descuentos / recargos / totales doc
        public decimal? PorcGdesc { get; set; }                   // decimal(18,2) (porc_desc_glob)
        public decimal? MontoDescGlob { get; set; }               // decimal(18,2)
        public decimal? PorcIva { get; set; }                     // decimal(18,2) dbo.TasaImpuestoSobreVentaAUnaFecha('1',...)
        public decimal? MontoImp { get; set; }                    // f.monto_imp
        public decimal? MontoGravadoTotal { get; set; }           // decimal(18,2)
        public decimal? MontoExentoTotal { get; set; }            // decimal(18,2)
        public bool? Anulado { get; set; }                        // f.anulado (bit)
        public decimal? BaseIgtf { get; set; }                    // 0.000000000
        public decimal? Igtf { get; set; }                        // 0.000000000
        public decimal? TotalGeneral { get; set; }                // f.total_neto + 0
        public decimal? Tasa { get; set; }                        // decimal(18,4) f.tasa
        public string? CoMone { get; set; }                       // f.co_mone
        public string? CoSucuIn { get; set; }                     // f.co_sucu_in

        public string? NumeroPlanillaImportacion { get; set; }
        public string? NumeroExpedienteImportacion { get; set; }

        //Datos que se usan para notas de credito y debito 
        public string? SerieFacturaAfectada { get; set; }
        public string? NumeroFacturaAfectada { get; set; }
        public DateTime? FechaFacturaAfectada { get; set; }
        public decimal? MontoFacturaAfectada { get; set; }
        public string? ComentarioFacturaAfectada { get; set; }


    }

    public class DetalleFacturaProfit
    {
        // public DetalleFacturaProfit( ) => Recalcular();


        // Unidad de medida
        public int? UnidadDeMedida { get; set; }            // NUEVO (mapper usa cUniMed)
        public string DescripcionUnidadDeMedida { get; set; }                  // NUEVO (mapper usa dDesUniMed)
      
        public decimal Factor { get; set; } = 1m;

        public decimal IvaMontoRenglon
        {
            get => _IvaMontoRenglon;
            set { _IvaMontoRenglon = value; Recalcular(); }
        }
        public decimal BaseImponibleRenglon { get; set ; }
        public decimal ExentoRenglon { get; set; }

        public decimal Subtotal { get; set; }               // NUEVO (mapper usa Subtotal)

        // Si deseas permitir monto de descuento fijo, también disparo recalcular
        private decimal _descuento;
        public decimal MontoDescuento
        {
            get => _descuento;
            set { _descuento = value; Recalcular(); }
        }
 
      
        private decimal _porcDescuento;
        public decimal PorcDescuento
        {
            get => _porcDescuento;
            set { _porcDescuento = value; Recalcular(); }
        }
        public decimal TotalRenglon { get; set; }
        public string? ComentarioRenglon { get; set; }


        //   Decimales de cálculo (ajústalo a 2 o 5 según tu modelo)
        private const int DEC = 2;
        private static decimal R(decimal v, int d = DEC) => Math.Round(v, d, MidpointRounding.AwayFromZero);



    
        public void Recalcular(int decimales = DEC)
        {
            // 1) Subtotal
            Subtotal = R(_cantidad * _precioUnitario, decimales);

            
            // 2) Base/Exento según IVA
            if (_tasaIva > 0m)
            {
                BaseImponibleRenglon = R(Subtotal, decimales);
                ExentoRenglon = 0m;
            }
            else
            {
                BaseImponibleRenglon = 0m;
                ExentoRenglon = R(Subtotal, decimales);
            }

            
            // 3) Total
            TotalRenglon = R(Subtotal + IvaMontoRenglon, decimales);
        }

    }
}
