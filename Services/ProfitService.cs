using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacturacionDigital_SIGECE.AppUtilities;
using FacturacionDigital_SIGECE.Helpers;
using FacturacionDigital_SIGECE.Models.Profit;
using Microsoft.Data.SqlClient;


namespace FacturacionDigital_SIGECE.Services
{
    public class ProfitService
    {

        public List<DocumentoDigitalProfit> BuscarDocumentosDigitales(string tipoDoc, DateTime Desde, DateTime Hasta)
        {


            var connectionString = AppConfig.CadenaConexion;
            var doc = new DocumentoDigitalProfit();
            var documentos = new List<DocumentoDigitalProfit>();
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sfConsultarDocumentosDigital", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo_doc", tipoDoc);
                cmd.Parameters.AddWithValue("@desde", Desde);
                cmd.Parameters.AddWithValue("@hasta", Hasta);
                cmd.CommandTimeout = 30000;
                cn.Open();

                using (var rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {

                    if (rd.Read())
                    {

                        while (rd.Read())
                        {

                            doc = new DocumentoDigitalProfit
                            {

                                TipoDoc = SafeGetHelper.SafeGet(rd, "TipoDoc", ""),
                                NroDoc = SafeGetHelper.SafeGet(rd, "NroDoc", ""),
                                FechaEmision = SafeGetHelper.SafeGet(rd, "FechaEmision", DateTime.Now),
                                Rif = SafeGetHelper.SafeGet(rd, "Rif", ""),
                                RazonSocial = SafeGetHelper.SafeGet(rd, "RazonSocial", ""),
                                Moneda = SafeGetHelper.SafeGet(rd, "Moneda", "Bs"),
                                Tasa = SafeGetHelper.SafeGet(rd, "Tasa", 1m),
                                MontoBaseImponible = SafeGetHelper.SafeGet(rd, "MontoBaseImponible", 0m),
                                MontoIva = SafeGetHelper.SafeGet(rd, "MontoIva", 0m),
                                MontoTotalDocumento = SafeGetHelper.SafeGet(rd, "MontoTotalDocumento", 0m),
                                Estado = SafeGetHelper.SafeGet(rd, "Estado", ""),
                                // la fecha de envio puede venir nula, en caso de quiero inicializarla con una fecha por defecto 01/01/2000
                                FechaEnvio = SafeGetHelper.SafeGet(rd, "FechaEnvio", new DateTime(2000, 1, 1)),
                                ControlAsignado = SafeGetHelper.SafeGet(rd, "ControlAsignado", ""),




                            };
                            documentos.Add(doc);
                        }
                    }



                }
            }

            return documentos;
        }


        public FacturaProfit BuscarFacturaDigital(string nro_doc)
        {


            var connectionString = AppConfig.CadenaConexion;
            var doc = new FacturaProfit();
            using (var cn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("sfConsultarDocumentosFactura", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nro_doc", nro_doc);


                cn.Open();

                using (var rd = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    // ----------------- Result set 1: Encabezado -----------------
                    if (rd.Read())
                    {
                        doc.Encabezado = new EncabezadoFacturaProfit
                        {
                            TipoDoc = SafeGetHelper.SafeGet(rd, "TipoDoc", "").Trim(),
                            NroDoc = SafeGetHelper.SafeGet(rd, "NroDoc", "").Trim(),
                            FecEmis = SafeGetHelper.SafeGet(rd, "FecEmis", DateTime.Now),
                            FecVenc = SafeGetHelper.SafeGet(rd, "FecVenc", DateTime.Now),
                            Serie = SafeGetHelper.SafeGet(rd, "Serie", "").Trim(),
                            Sucursal = SafeGetHelper.SafeGet(rd, "Sucursal", "").Trim(),
                            TipoDeVenta = SafeGetHelper.SafeGet(rd, "TipoDeVenta", "").Trim(),
                            //datos del cliente
                            CoCli = SafeGetHelper.SafeGet(rd, "CoCli", "").Trim(),
                            CliDes = SafeGetHelper.SafeGet(rd, "CliDes", "").Trim(),
                            CoPais = SafeGetHelper.SafeGet(rd, "CoPais", "").Trim(),
                            Rif = SafeGetHelper.SafeGet(rd, "Rif", "").Trim(),
                            DireccionEntrega = SafeGetHelper.SafeGet(rd, "DireccionEntrega", "").Trim(),
                            DireccionComercial = SafeGetHelper.SafeGet(rd, "DireccionComercial", "").Trim(),
                            TipoIdentificacion = SafeGetHelper.SafeGet(rd, "TipoIdentificacion", "").Trim(),
                            NumeroIdentificacion = SafeGetHelper.SafeGet(rd, "NumeroIdentificacion", "").Trim(),
                            
                            Email = SafeGetHelper.SafeGet(rd, "Email", "").Trim(),
                            Telefonos = SafeGetHelper.SafeGet(rd, "Telefonos", "").Trim(),
                            // Comentarios / campos libres
                            ComentarioGeneral = SafeGetHelper.SafeGet(rd, "ComentarioGeneral", "").Trim(),
                            InfoAdicional1 = SafeGetHelper.SafeGet(rd, "InfoAdicional1", "").Trim(),
                            InfoAdicional2 = SafeGetHelper.SafeGet(rd, "InfoAdicional2", "").Trim(),
                            InfoAdicional3 = SafeGetHelper.SafeGet(rd, "InfoAdicional3", "").Trim(),
                            InfoAdicional4 = SafeGetHelper.SafeGet(rd, "InfoAdicional4", "").Trim(),
                            InfoAdicional5 = SafeGetHelper.SafeGet(rd, "InfoAdicional5", "").Trim(),
                            InfoAdicional6 = SafeGetHelper.SafeGet(rd, "InfoAdicional6", "").Trim(),
                            InfoAdicional7 = SafeGetHelper.SafeGet(rd, "InfoAdicional7", "").Trim(),
                            InfoAdicional8 = SafeGetHelper.SafeGet(rd, "InfoAdicional8", "").Trim(),
                            Descripcion = SafeGetHelper.SafeGet(rd, "Descripcion", "").Trim(),
                            TipoColetilla = SafeGetHelper.SafeGet(rd, "TipoColetilla", false),
                            ColetillaIGTF = SafeGetHelper.SafeGet(rd, "ColetillaIGTF", false),
                            contribuyenteEspecial = SafeGetHelper.SafeGet(rd, "contribuyenteEspecial", false),
                            tipoPersona = SafeGetHelper.SafeGet(rd, "tipoPersona", "").Trim(),
                            // Vendedor / condición pago
                            CoVen = SafeGetHelper.SafeGet(rd, "CoVen", "").Trim(),
                            VenDes = SafeGetHelper.SafeGet(rd, "VenDes", "").Trim(),
                            CoCond = SafeGetHelper.SafeGet(rd, "CoCond", "").Trim(),
                            CondDes = SafeGetHelper.SafeGet(rd, "CondDes", "").Trim(),
                            RifEmisor = SafeGetHelper.SafeGet(rd, "RifEmisor", "").Trim(),
                            DiasCredito = SafeGetHelper.SafeGet(rd, "DiasCredito", 0)   ,
                            CoTran = SafeGetHelper.SafeGet(rd, "CoTran", "").Trim(),
                            DesTran = SafeGetHelper.SafeGet(rd, "DesTran", "").Trim(),
                            ccCorreo = SafeGetHelper.SafeGet(rd, "ccCorreo", "").Trim(),


                          
                            PorcGdesc = SafeGetHelper.SafeGet(rd, "PorcGdesc", 0m),
                            MontoDescGlob = SafeGetHelper.SafeGet(rd, "MontoDescGlob", 0m),
                            PorcIva = SafeGetHelper.SafeGet(rd, "PorcIva", 0m),
                            MontoImp = SafeGetHelper.SafeGet(rd, "MontoImp", 0m),
                            MontoGravadoTotal = SafeGetHelper.SafeGet(rd, "MontoGravadoTotal", 0m),
                            MontoExentoTotal = SafeGetHelper.SafeGet(rd, "MontoExentoTotal", 0m),
                            Anulado = SafeGetHelper.SafeGet(rd, "Anulado", false),

                            BaseIgtf = SafeGetHelper.SafeGet(rd, "BaseIgtf", 0m),
                            Igtf = SafeGetHelper.SafeGet(rd, "Igtf", 0m),
                            TotalGeneral = SafeGetHelper.SafeGet(rd, "TotalGeneral", 0m),
                            SubTotal = SafeGetHelper.SafeGet(rd, "SubTotalGeneral", 0m),
                            TotalExonerado = SafeGetHelper.SafeGet(rd, "TotalExonerado", 0m),
                            Tasa = SafeGetHelper.SafeGet(rd, "Tasa", 1m),
                            CoMone = SafeGetHelper.SafeGet(rd, "CoMone", "Bs"),
                            CoSucuIn = SafeGetHelper.SafeGet(rd, "CoSucuIn", ""),
                            NumeroPlanillaImportacion = SafeGetHelper.SafeGet(rd, "NumeroPlanillaImportacion", "").Trim(),
                            NumeroExpedienteImportacion = SafeGetHelper.SafeGet(rd, "NumeroExpedienteImportacion", "").Trim(),
                            SerieFacturaAfectada = SafeGetHelper.SafeGet(rd, "SerieFacturaAfectada", "").Trim(),
                            NumeroFacturaAfectada = SafeGetHelper.SafeGet(rd, "NumeroFacturaAfectada", "").Trim(),
                            FechaFacturaAfectada = SafeGetHelper.SafeGet(rd, "FechaFacturaAfectada", (DateTime?)null),
                            MontoFacturaAfectada = SafeGetHelper.SafeGet(rd, "MontoFacturaAfectada", 0m),
                            ComentarioFacturaAfectada = SafeGetHelper.SafeGet(rd, "ComentarioFacturaAfectada", "").Trim(),


                        };
                            var det1 = new DetalleFacturaProfit
                            {
                                //inicualizo los atributos de DetalleFacturaProfit
                                NroRenglon = SafeGetHelper.SafeGet(rd, "NroRenglon", 0),
                                CodigoArticulo = SafeGetHelper.SafeGet(rd, "CodigoArticulo", "").Trim(),
                                DescripcionArticulo = SafeGetHelper.SafeGet(rd, "DescripcionArticulo", "").Trim(),
                                Cantidad = SafeGetHelper.SafeGet(rd, "Cantidad", 0m),
                                UnidadDeMedida = SafeGetHelper.SafeGet(rd, "UnidadDeMedida", "").Trim(),
                                DescripcionUnidadDeMedida = SafeGetHelper.SafeGet(rd, "DescripcionUnidadDeMedida", "").Trim(),
                                Almacen = SafeGetHelper.SafeGet(rd, "Almacen", "").Trim(),
                                MontoDescuento = SafeGetHelper.SafeGet(rd, "MontoDescuento", 0m),
                                Subtotal = SafeGetHelper.SafeGet(rd, "Subtotal", 0m),
                                ComentarioRenglon = SafeGetHelper.SafeGet(rd, "ComentarioRenglon", "").Trim(),
                                PrecioUnitario = SafeGetHelper.SafeGet(rd, "PrecioUnitario", 0m),
                                PorcIvaRenglon = SafeGetHelper.SafeGet(rd, "PorcIvaRenglon", 0m),
                                PorcDescuento = SafeGetHelper.SafeGet(rd, "PorcDescuento", 0m),
                            };
                            doc.Detalles.Add(det1);

                        while (rd.Read())
                        {
                            var det = new DetalleFacturaProfit
                            {
                                //inicualizo los atributos de DetalleFacturaProfit
                                NroRenglon = SafeGetHelper.SafeGet(rd, "NroRenglon", 0),
                                CodigoArticulo = SafeGetHelper.SafeGet(rd, "CodigoArticulo", "").Trim(),
                                DescripcionArticulo = SafeGetHelper.SafeGet(rd, "DescripcionArticulo", "").Trim(),
                                Cantidad = SafeGetHelper.SafeGet(rd, "Cantidad", 0m),
                                UnidadDeMedida = SafeGetHelper.SafeGet(rd, "UnidadDeMedida", "").Trim(),
                                DescripcionUnidadDeMedida = SafeGetHelper.SafeGet(rd, "DescripcionUnidadDeMedida", "").Trim(),
                                Almacen = SafeGetHelper.SafeGet(rd, "Almacen", "").Trim(),
                                MontoDescuento = SafeGetHelper.SafeGet(rd, "MontoDescuento", 0m),
                                Subtotal = SafeGetHelper.SafeGet(rd, "Subtotal", 0m),
                                ComentarioRenglon = SafeGetHelper.SafeGet(rd, "ComentarioRenglon", "").Trim(),
                                PrecioUnitario = SafeGetHelper.SafeGet(rd, "PrecioUnitario", 0m),
                                PorcIvaRenglon = SafeGetHelper.SafeGet(rd, "PorcIvaRenglon", 0m),
                                PorcDescuento = SafeGetHelper.SafeGet(rd, "PorcDescuento", 0m),
                            };
                            doc.Detalles.Add(det);


                        }
                    }

                    return doc;
                }
            }
        }
    }
}
