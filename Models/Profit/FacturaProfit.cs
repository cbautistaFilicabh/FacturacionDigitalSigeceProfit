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

        public string? RifEmisor { get; set; }                  // Parametrizable
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
        public string? ccCorreo { get; set; }
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

        public bool TipoColetilla { get; set; } = false;

        public bool ColetillaIGTF { get; set; } = false;

        // Vendedor / condición pago
        public string? CoVen { get; set; }                        // f.co_ven
        public string? VenDes { get; set; }                       // v.ven_des
        public string? CoCond { get; set; }                       // con.co_cond
        public string? CondDes { get; set; }                      // con.cond_des
        public int DiasCredito { get; set; }                   // con.dias
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

        public decimal? SubTotal { get; set; }                // f.total_neto + 0

        public decimal TotalExonerado { get; set; }               // decimal(18,2)
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


        // Identificación artículo
        public int? NroRenglon { get; set; }
        public string? CodigoArticulo { get; set; }
        public string? DescripcionArticulo { get; set; }


        public decimal Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        // Unidad de medida - almacen 
        public string? UnidadDeMedida { get; set; }
        public string? DescripcionUnidadDeMedida { get; set; }

        public string? Almacen { get; set; }

        // Impuesto renglon // Subtotales por línea

        private decimal _tasaIva;
        public decimal PorcIvaRenglon
        {
            get => _tasaIva;
            set { _tasaIva = value; Recalcular(); }
        }


        public decimal IvaMontoRenglon { get; set; }
        public decimal BaseImponibleRenglon { get; set; }
        public decimal ExentoRenglon { get; set; }
        public string? nrolote { get; set; }

        public bool exonerado { get; set; } = false;
        public DateTime? fechaVenciProducto { get; set; }

        public decimal Subtotal { get; set; }               // NUEVO (mapper usa Subtotal)

        // Si deseas permitir monto de descuento fijo, también disparo recalcular
        public decimal MontoDescuento { get; set; }

        public decimal PorcDescuento { get; set; }
        public decimal TotalRenglon { get; set; }
        public string? ComentarioRenglon { get; set; }


        //   Decimales de cálculo (ajústalo a 2 o 5 según tu modelo)
        private const int DEC = 2;
        private static decimal R(decimal v, int d = DEC) => Math.Round(v, d, MidpointRounding.AwayFromZero);




        public void Recalcular(int decimales = DEC)
        {



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

            IvaMontoRenglon = R(BaseImponibleRenglon * (PorcIvaRenglon / 100m), decimales);
            //IvaMontoRenglon = R((Cantidad * PrecioUnitario - MontoDescuento) * (PorcIvaRenglon / 100m), decimales);


            // 3) Total
            TotalRenglon = R(Subtotal + IvaMontoRenglon, decimales);
        }

    }
}
