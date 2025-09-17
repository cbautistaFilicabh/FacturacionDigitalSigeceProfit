using System;
using System.Collections.Generic;

namespace FacturacionDigital_SIGECE.Models.Profit
{
    // Clase principal que agrupa encabezado y detalles
    public class FacturaProfit
    {
        public EncabezadoDocumentoProfit Encabezado { get; set; } = new EncabezadoDocumentoProfit();
        public List<DetalleDocumentoProfit> Detalles { get; set; } = new List<DetalleDocumentoProfit>();
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
        public string? CoTran { get; set; }                       // T.co_tran
        public string? DesTran { get; set; }                      // T.des_tran


        //datos del cliente
        public string? CoCli { get; set; }                        // f.co_cli
        public string? CliDes { get; set; }                       // c.cli_des
        public string? CoPais { get; set; }                       // c.co_pais
        public string? Rif { get; set; }                          // c.rif
        public string? TipoIdentificacion { get; set; }           // left(c.rif,1)
        public string? NumeroIdentificacion { get; set; }         // substring(c.rif,2,len(c.rif))
        public string? Direc1 { get; set; }                       // c.direc1
        public string? Email { get; set; }                        // c.email
        public string? Telefonos { get; set; }                    // c.telefonos

        // Comentarios / campos libres
        public string? ComentarioGeneral { get; set; }            // replace(convert(...), '<Forma de pago: Efectivo>', '')
        public string? Campo1 { get; set; }                       // f.campo1
        public string? Campo2 { get; set; }                       // f.campo2
        public string? Campo3 { get; set; }                       // f.campo3
        public string? Campo4 { get; set; }                       // f.campo4
        public string? Campo5 { get; set; }                       // f.campo5
        public string? Campo6 { get; set; }                       // f.campo6 (aparece dos veces en el SELECT)
        public string? Campo8 { get; set; }                       // f.campo8
        public string? Descrip { get; set; }                      // f.descrip

        // Vendedor / condición pago
        public string? CoVen { get; set; }                        // f.co_ven
        public string? VenDes { get; set; }                       // v.ven_des
        public string? CoCond { get; set; }                       // con.co_cond
        public string? CondDes { get; set; }                      // con.cond_des


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
        public int Linea { get; set; }
        public string CodigoArticulo { get; set; }
        public string DescripcionArticulo { get; set; }

        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Unidad de medida
        public int? UnidadDeMedida { get; set; }            // NUEVO (mapper usa cUniMed)
        public string DescripcionUnidadDeMedida { get; set; }                  // NUEVO (mapper usa dDesUniMed)
      
        public decimal Factor { get; set; } = 1m;

        // Impuesto
        public int TasaIva { get; set; }                    // 0/5/10 (mapper lo toma)
        public decimal IvaMonto { get; set; }               // NUEVO (mapper dLiqIVAItem)
        public decimal BaseImponible { get; set; }          // NUEVO (mapper dBasGravIVA / dBasExe)

        // Subtotales por línea
        public decimal SubtotalBruto { get; set; }
        public decimal Subtotal { get; set; }               // NUEVO (mapper usa Subtotal)
        public decimal Descuento { get; set; }
        public decimal PorcDescuento { get; set; }
        public decimal TotalLinea { get; set; }

        // Otros
        public string ComentarioLinea { get; set; }
        public string Almacen { get; set; }

        public decimal Iva
        {
            get => IvaMonto;
            set => IvaMonto = value;
        }

        // Si en algún lado usan 'PorcentajeIva', lo enlazamos con TasaIva
        public int PorcentajeIva
        {
            get => TasaIva;
            set => TasaIva = value;
        }
    }
}
