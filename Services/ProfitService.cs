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
                cmd.CommandTimeout = 120;
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
                            TipoDoc = SafeGetHelper.SafeGet(rd, "TipoDoc", ""),
                            NroDoc = SafeGetHelper.SafeGet(rd, "NroDoc", ""),
                            FecEmis = SafeGetHelper.SafeGet(rd, "FecEmis", DateTime.Now),
                            FecVenc = SafeGetHelper.SafeGet(rd, "FecVenc", DateTime.Now),
                            Serie = SafeGetHelper.SafeGet(rd, "Serie", ""),
                            Sucursal = SafeGetHelper.SafeGet(rd, "Sucursal", ""),
                            TipoDeVenta = SafeGetHelper.SafeGet(rd, "TipoDeVenta", ""),
                            //datos del cliente
                            CoCli = SafeGetHelper.SafeGet(rd, "CoCli", ""),
                            CliDes = SafeGetHelper.SafeGet(rd, "CliDes", ""),
                            CoPais = SafeGetHelper.SafeGet(rd, "CoPais", ""),
                            Rif = SafeGetHelper.SafeGet(rd, "Rif", ""),
                            TipoIdentificacion = SafeGetHelper.SafeGet(rd, "TipoIdentificacion", ""),
                            NumeroIdentificacion = SafeGetHelper.SafeGet(rd, "NumeroIdentificacion", ""),
                            DireccionComercial = SafeGetHelper.SafeGet(rd, "DireccionComercial", ""),
                            DireccionEntrega = SafeGetHelper.SafeGet(rd, "DireccionEntrega", ""),
                            Email = SafeGetHelper.SafeGet(rd, "Email", ""),
                            Telefonos = SafeGetHelper.SafeGet(rd, "Telefonos", ""),
                            // Comentarios / campos libres
                            ComentarioGeneral = SafeGetHelper.SafeGet(rd, "ComentarioGeneral", ""),
                            InfoAdicional1 = SafeGetHelper.SafeGet(rd, "InfoAdicional1", ""),
                            InfoAdicional2 = SafeGetHelper.SafeGet(rd, "InfoAdicional2", ""),
                            InfoAdicional3 = SafeGetHelper.SafeGet(rd, "InfoAdicional3", ""),
                            InfoAdicional4 = SafeGetHelper.SafeGet(rd, "InfoAdicional4", ""),
                            InfoAdicional5 = SafeGetHelper.SafeGet(rd, "InfoAdicional5", ""),
                            InfoAdicional6 = SafeGetHelper.SafeGet(rd, "InfoAdicional6", ""),
                            InfoAdicional7 = SafeGetHelper.SafeGet(rd, "InfoAdicional7", ""),
                            InfoAdicional8 = SafeGetHelper.SafeGet(rd, "InfoAdicional8", ""),
                            Descripcion = SafeGetHelper.SafeGet(rd, "Descripcion", ""),



                        };

                        while (rd.Read())
                        {
                            var det = new DetalleFacturaProfit
                            {
                                //inicualizo los atributos de DetalleFacturaProfit
                                NroRenglon = SafeGetHelper.SafeGet(rd, "NroRenglon", 0),
                                CodigoArticulo = SafeGetHelper.SafeGet(rd, "CodigoArticulo", ""),
                                DescripcionArticulo = SafeGetHelper.SafeGet(rd, "DescripcionArticulo", ""),
                                Cantidad = SafeGetHelper.SafeGet(rd, "Cantidad", 0m),
                                UnidadDeMedida = SafeGetHelper.SafeGet(rd, "UnidadDeMedida", ""),
                                DescripcionUnidadDeMedida = SafeGetHelper.SafeGet(rd, "DescripcionUnidadDeMedida", ""),
                                Almacen = SafeGetHelper.SafeGet(rd, "Almacen", ""),
                                PorcDescuento = SafeGetHelper.SafeGet(rd, "PorcDescuento", 0m),
                                MontoDescuento = SafeGetHelper.SafeGet(rd, "MontoDescuento", 0m),
                                PorcIvaRenglon = SafeGetHelper.SafeGet(rd, "PorcIvaRenglon", 0m),
                                Subtotal = SafeGetHelper.SafeGet(rd, "Subtotal", 0m),
                                ComentarioRenglon = SafeGetHelper.SafeGet(rd, "ComentarioRenglon", ""),
                                PrecioUnitario = SafeGetHelper.SafeGet(rd, "PrecioUnitario", 0m),



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
