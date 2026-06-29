using Azure;
using FacturacionDigital_SIGECE.Helpers;
using FacturacionDigital_SIGECE.Models;
using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
using FacturacionDigital_SIGECE.Models.Profit;
using FacturacionDigital_SIGECE.Models.Retenciones;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FacturacionDigital_SIGECE.Services.Common
{
    public class DocumentosService
    {
        /// <summary>
        /// Se encarga de procesar una lista de documentos (facturas, notas de débito/crédito) y enviarlos a la API externa correspondiente.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task CreateDocument(List<DocumentoProfit> data)
        {
            string typeDocument = data.First().Encabezado.TipoDoc ?? "fact";

            switch (typeDocument.ToLowerInvariant())
            {
                case "fact":
                    var _facturaService = new FacturasService();
                    var listDataFact = MapAdminToApi<FacturasRequestDto>(data) ?? new List<FacturasRequestDto>();

                    var responseFact = await _facturaService.CreateAsync(listDataFact);

                    if (responseFact.Data != null)
                    {
                        var msg = new StringBuilder();

                        if (responseFact.Data.DetalleFacturaProcesadas?.Any() == true)
                        {
                            msg.AppendLine("Facturas procesadas correctamente:");

                            var facturasProcesadas = responseFact.Data.DetalleFacturaProcesadas
                                .SelectMany(list => list) // aplanar la lista de listas
                                .ToList();

                            foreach (var proc in facturasProcesadas)
                            {
                                msg.AppendLine($" Número:{proc.NroFactura} | N. Control: {proc.NroControl}");
                            }
                            msg.AppendLine();
                        }

                        if (responseFact.Data.DetalleErrorFacturas?.Any() == true)
                        {
                            var facturasError = responseFact.Data.DetalleErrorFacturas.SelectMany(list => list).ToList();

                            var facturasUnicas = facturasError.GroupBy(e => e.NroFactura).Select(g => g.First()).ToList();

                            msg.AppendLine("Facturas no procesadas:" + string.Join(", ", facturasUnicas.Select(e => e.NroFactura)));

                            msg.AppendLine();
                            msg.AppendLine($"Total de errores: {facturasError.Count}");
                            msg.AppendLine("Revisa el histórico para más detalles.");
                        }
                        // Mostrar mensaje al usuario
                        MessageBox.Show(msg.ToString(), "Resultado Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show($"Error al crear facturas: {responseFact.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "n/cr":
                case "n/db":
                    var _notaDebitoCreditoService = new NotaDebitoCreditoService();
                    var listDataNota = MapAdminToApi<NotaDebitoCreditoRequestDto>(data) ?? new List<NotaDebitoCreditoRequestDto>();

                    var responseNota = await _notaDebitoCreditoService.CreateAsync(listDataNota);

                    if (responseNota.Success && responseNota.Data != null)
                    {
                        var msg = new StringBuilder();

                        if (responseNota.Data.DetalleNotasProcesadas?.Any() == true)
                        {
                            msg.AppendLine("Documentos procesados correctamente:");

                            var facturasProcesadas = responseNota.Data.DetalleNotasProcesadas
                                .SelectMany(list => list) // aplanar la lista de listas
                                .ToList();

                            foreach (var proc in facturasProcesadas)
                            {
                                msg.AppendLine($"Número:{proc.nroNota}");
                                msg.AppendLine($"N. Control: {proc.nroControl}");
                            }
                            msg.AppendLine();
                        }

                        if (responseNota.Data.DetalleErrorNotas?.Any() == true)
                        {

                            var notasError = responseNota.Data.DetalleErrorNotas.SelectMany(list => list).ToList();

                            var notasUnicas = notasError.GroupBy(e => e.nroNota).Select(g => g.First()).ToList();

                            msg.AppendLine("Documentos no procesados:" + string.Join(", ", notasUnicas.Select(e => e.nroNota)));

                            msg.AppendLine();
                            msg.AppendLine($"Total de errores: {notasError.Count}");
                            msg.AppendLine("Revisa el histórico para más detalles.");
                        }
                        // Mostrar mensaje al usuario
                        MessageBox.Show(msg.ToString(), "Resultado Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show($"{responseNota.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    throw new ArgumentException("Tipo de documento no soportado.");
            }
        }

        /// <summary>
        /// Se encarga de mapear los datos desde el formato de DocumentoProfit al formato requerido por la API externa.
        /// Aquí se manejan dos tipos de mapeos: uno para facturas y otro para notas de débito/crédito, y se setean los campos necesarios.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="profitItems"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public List<T>? MapAdminToApi<T>(List<DocumentoProfit> profitItems)
        {
            var newDto = new List<T>();

            if (typeof(T) == typeof(FacturasRequestDto))
            {
                FacturasRequestDto facturaDto;

                foreach (var item in profitItems)
                {
                    //Datos del cliente
                    var client = new ClienteDto
                    {
                        contribuyenteEspecial = false, //falta
                        tipoDocumento = (item.Encabezado.TipoIdentificacion ?? "V").Trim(),
                        numeroDocumento = (item.Encabezado.NumeroIdentificacion ?? "").Trim(),
                        identificacion = item.Encabezado.CliDes != null ? item.Encabezado.CliDes.Trim() : "S/N",
                        direccion = (item.Encabezado.DireccionComercial ?? "").Trim(),
                        telefonoMovil = (item.Encabezado.Telefonos ?? "").Trim(),
                        correo = (item.Encabezado.Email ?? "").Trim(),
                        ccCorreo = !item.Encabezado.ccCorreo.IsNullOrEmpty() ? item.Encabezado.ccCorreo.Trim() : null,
                        tipoPersona = "CLIENTE",
                        tipoProveedor = item.Encabezado.tipoPersona != null ? item.Encabezado.tipoPersona.Trim() : "PJD"
                    };

                    //Descuentos de la factura
                    decimal descuentoFactura = 0.0m;
                    decimal totalFactura = 0;

                    var detalleFac = new List<DetalleFacturaDto>();
                    foreach (var detalle in item.Detalles)
                    {
                        detalleFac.Add(
                            new DetalleFacturaDto
                            {
                                codigoProducto = (detalle.CodigoArticulo ?? "").Trim(),
                                descripcion = (detalle.DescripcionArticulo ?? "").Trim(),
                                unidadMedida = detalle.DescripcionUnidadDeMedida ?? "UNIDAD",
                                cantidad = detalle.Cantidad,
                                precio = detalle.PrecioUnitario,
                                exento = detalle.PorcIvaRenglon == 0 ? true : false,
                                exonerado = detalle.exonerado, //falta
                                importe = detalle.PorcIvaRenglon == 0 ? detalle.ExentoRenglon : detalle.BaseImponibleRenglon,
                                alicuotaGravamen = detalle.PorcIvaRenglon,
                                montoGravamen = detalle.IvaMontoRenglon,
                                montoDescuento = Math.Abs(detalle.MontoDescuento),
                                descuento = detalle.PorcDescuento,
                                nrolote = detalle.nrolote, ///falta
                                fechaVenciProducto = detalle.fechaVenciProducto.HasValue ? detalle.fechaVenciProducto.Value.ToString("yyyy-MM-dd") : null
                            }
                        );

                        descuentoFactura += Math.Abs(detalle.MontoDescuento);
                        totalFactura += detalle.TotalRenglon;
                    }

                    var lstGravamen = GravamenList(detalleFac);

                    string? observacionfact = "";

                    if (!string.IsNullOrWhiteSpace(item.Encabezado.InfoAdicional1))
                    {
                        observacionfact = (item.Encabezado.InfoAdicional1 != null ? item.Encabezado.InfoAdicional1.Trim() : "");
                    }

                    if (!string.IsNullOrWhiteSpace(item.Encabezado.InfoAdicional2))
                    {
                        observacionfact = observacionfact + "/n" + (item.Encabezado.InfoAdicional2 != null ? item.Encabezado.InfoAdicional2.Trim() : "");
                    }


                    facturaDto = new FacturasRequestDto
                    {
                        rif = (item.Encabezado.RifEmisor ?? "").Trim(),
                        nroFactura = (item.Encabezado.NroDoc ?? "").Trim(),
                        importeTotal = totalFactura,//item.Encabezado.TotalGeneral ?? 0,
                        codigoSucursal = string.IsNullOrWhiteSpace(item.Encabezado.Sucursal) ? null : item.Encabezado.Sucursal.Trim(),
                        serie = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        serieNrofactura = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        subTotal = (item.Encabezado.SubTotal) ?? 0,
                        montoDescuento = item.Encabezado.MontoDescGlob ?? 0,
                        totalExento = item.Encabezado.MontoExentoTotal ?? 0,
                        totalExonerado = item.Encabezado.TotalExonerado,
                        condicionPago = (item.Encabezado.CondDes ?? "CONTADO").Trim(),
                        facturaDivisa = (item.Encabezado.CoMone ?? "").Trim(),
                        cambioDivisa = 1,
                        tipoCambioDiaUsd = item.Encabezado.Tasa ?? 0,
                        tipoColetilla = item.Encabezado.TipoColetilla,
                        tipoVenta = "INTERNA",
                        diasCredito = item.Encabezado.DiasCredito,
                        fechaVenciFactura = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToString("yyyy-MM-dd").Trim() : null,
                        fechaVencimiento = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToString("yyyy-MM-dd").Trim() : null,
                        modeloFactura = "GENERAL",
                        pagueAntes = null,
                        cuentaTerceros = false,
                        rifPrestador = (item.Encabezado.Rif ?? "").Trim(),
                        coletillaIGTF = true,
                        nroContrato = null,
                        observacion = (observacionfact != "" ? observacionfact + "/n" : null) + (item.Encabezado.ComentarioGeneral != null ? item.Encabezado.ComentarioGeneral.Trim() : null),
                        observacionInfo = item.Encabezado.Descripcion != null ? item.Encabezado.Descripcion.Trim() : null,
                        ordenCompra = null,
                        cliente = client,
                        lstDetallesFacturaGeneral = detalleFac,
                        lstPagos = null,
                        lstGravamenes = lstGravamen
                    };

                    if (item.Encabezado.InfoAdicional3 != "" && item.Encabezado.InfoAdicional3 != null)
                    {
                        facturaDto.ordenCompra = item.Encabezado.InfoAdicional3!.Trim() ?? null;
                    }

                    //ObjectCleaner.Clean(facturaDto);

                    newDto.Add((T)(object)facturaDto);
                }
            }
            else if (typeof(T) == typeof(NotaDebitoCreditoRequestDto))
            {
                NotaDebitoCreditoRequestDto notaDto;

                foreach (var item in profitItems)
                {
                    //Descuentos de la factura
                    decimal descuentoNota = 0.0m;
                    decimal totalNota = 0;
                    var detallesNota = new List<DetalleNota>();
                    foreach (var detalle in item.Detalles)
                    {
                        detallesNota.Add(
                            new DetalleNota
                            {
                                codigoProducto = (detalle.CodigoArticulo ?? "").Trim(),
                                descripcion = (detalle.DescripcionArticulo ?? "").Trim(),
                                cantidad = detalle.Cantidad,
                                unidadMedida = detalle.DescripcionUnidadDeMedida ?? "UNIDAD",
                                cantidadDevolucion = detalle.CantidadDevolucion ?? 0,
                                precio = detalle.PrecioUnitario,
                                precioOriginal = detalle.PrecioUnitarioOriginal,
                                precioDevolucion = detalle.TotalRenglon,
                                descuento = detalle.PorcDescuento,
                                montoDescuento = Math.Abs(detalle.MontoDescuento),
                                exento = detalle.PorcIvaRenglon == 0 ? true : false,
                                exonerado = detalle.exonerado,
                                importe = detalle.PorcIvaRenglon == 0 ? detalle.ExentoRenglon : detalle.BaseImponibleRenglon,
                                alicuotaGravamen = detalle.PorcIvaRenglon,
                                montoGravamen = detalle.IvaMontoRenglon
                            }
                        );
                        descuentoNota += Math.Abs(detalle.MontoDescuento);
                        totalNota += detalle.TotalRenglon;
                    }

                    var lstGravamen = GravamenList(detallesNota);

                    notaDto = new NotaDebitoCreditoRequestDto
                    {
                        rif = item.Encabezado.RifEmisor ?? "",
                        codigoSucursal = string.IsNullOrWhiteSpace(item.Encabezado.Sucursal) ? null : item.Encabezado.Sucursal.Trim(),
                        nroFactura = item.Encabezado.NumeroFacturaAfectada ?? "",
                        nroNota = item.Encabezado.NroDoc ?? "",
                        tipo = item.Encabezado.TipoDoc.ToLowerInvariant() == "n/cr" ? "Credito" : "Debito",
                        serie = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        categoria = item.Encabezado.Categoria.ToString() ?? "0", // falta
                        concepto = item.Encabezado.ComentarioGeneral ?? "",
                        importeTotal = totalNota, //item.Encabezado.TotalGeneral ?? 0,
                        subTotal = item.Encabezado.SubTotal ?? 0,
                        montoDescuento = (descuentoNota + item.Encabezado.MontoDescGlob) ?? 0,
                        totalExento = item.Encabezado.MontoExentoTotal ?? 0,
                        totalExonerado = item.Encabezado.TotalExonerado,
                        tasaCambio = (item.Encabezado.CoMone ?? "").Trim() == "VEF" ? 1 : item.Encabezado.Tasa ?? 0,
                        facturaDivisa = (item.Encabezado.CoMone ?? "").Trim(),
                        lstDetallesNota = detallesNota,
                        lstGravamenes = lstGravamen
                    };

                    newDto.Add((T)(object)notaDto);
                }
            }
            else
            {
                throw new NotSupportedException($"Mapping to type {typeof(T).Name} is not supported.");
            }

            return newDto;
        }


        /// <summary>
        /// Se encarga de generar una lista de gravámenes a partir de una lista de productos o detalles de factura/nota.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="productsList"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public static List<GravamenDto> GravamenList<T>(List<T> productsList)
        {
            try
            {
                if (productsList == null || productsList.Count == 0)
                    return new List<GravamenDto>();

                var alicuotasValidas = new decimal[] { 16, 8, 31 };
                var result = new List<GravamenDto>();

                if (typeof(T) == typeof(DetalleFacturaDto))
                {
                    foreach (var item in productsList.Cast<DetalleFacturaDto>())
                    {
                        if (item.exento || !alicuotasValidas.Contains(item.alicuotaGravamen))
                            continue;

                        var existente = result.FirstOrDefault(x => x.alicuota == item.alicuotaGravamen);

                        if (existente == null)
                        {
                            result.Add(new GravamenDto
                            {
                                alicuota = item.alicuotaGravamen,
                                baseImponible = item.importe,
                                montoAlicuota = item.montoGravamen
                            });
                        }
                        else
                        {
                            existente.baseImponible += item.importe;
                            existente.montoAlicuota += item.montoGravamen;
                        }
                    }
                }
                else if (typeof(T) == typeof(DetalleNota))
                {
                    foreach (var item in productsList.Cast<DetalleNota>())
                    {
                        if (item.exento.GetValueOrDefault() || !alicuotasValidas.Contains(item.alicuotaGravamen))
                            continue;

                        var existente = result.FirstOrDefault(x => x.alicuota == item.alicuotaGravamen);

                        if (existente == null)
                        {
                            result.Add(new GravamenDto
                            {
                                alicuota = item.alicuotaGravamen,
                                baseImponible = item.importe,
                                montoAlicuota = item.montoGravamen
                            });
                        }
                        else
                        {
                            existente.baseImponible += item.importe;
                            existente.montoAlicuota += item.montoGravamen;
                        }
                    }
                }
                else
                {
                    throw new NotSupportedException($"El tipo {typeof(T).Name} no está soportado en GravamenList");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al generar la lista de gravámenes.", ex);
            }
        }

        /// <summary>
        /// Procesa un lote de comprobantes de retención (IVA o ISLR) y los envía a la API.
        /// Cada lista interior representa las filas del SP para un comprobante.
        /// </summary>
        public async Task CreateRetenciones(List<List<RetencionProfit>> data, string tipoDoc)
        {
            if (!data.Any(g => g.Count > 0))
            {
                MessageBox.Show("No se encontraron datos de retención para los documentos seleccionados.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var _retencionService = new RetencionService();
            var listDto = MapRetencioneToApi(data, tipoDoc);

            var response = await _retencionService.CreateAsync(listDto);

            if (response.Data != null)
            {
                var msg = new StringBuilder();

                if (response.Data.DetalleretencionesProcesadas?.Any() == true)
                {
                    msg.AppendLine("Retenciones procesadas correctamente:");
                    foreach (var proc in response.Data.DetalleretencionesProcesadas)
                    {
                        msg.AppendLine($" Comprobante: {proc.nroComprobante} | N. Control: {proc.NroControlComprobante}");
                    }
                    msg.AppendLine();
                }

                if (response.Data.TotalRetencionIvaconError > 0)
                {
                    msg.AppendLine("Retenciones con error:");
                    foreach (var err in response.Data.DetalleErrorRetencionesIva)
                    {
                        if (!string.IsNullOrWhiteSpace(err.msg))
                            msg.AppendLine($" - {err.msg}");
                    }
                    msg.AppendLine();
                    msg.AppendLine($"Total errores: {response.Data.TotalRetencionIvaconError}");
                    msg.AppendLine("Revisa el histórico para más detalles.");
                }

                MessageBox.Show(msg.ToString(), "Resultado Retenciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error al enviar retenciones: {response.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<RetencionRequestDto> MapRetencioneToApi(List<List<RetencionProfit>> data, string tipoDoc)
        {
            bool esIslr = tipoDoc.ToUpperInvariant() == "ISLR";
            string modeloRetencion = esIslr ? "ISLR" : "IVA";
            var result = new List<RetencionRequestDto>();

            foreach (var filas in data)
            {
                if (!filas.Any()) continue;

                var first = filas.First();

                var (del, al) = CalcularPeriodoFiscal(
                    first.FechaEmision, first.mesfiscal, first.annofiscal, first.esContribuyente, esIslr);

                string rifProveedor = string.IsNullOrWhiteSpace(first.tipoRifProv)
                    ? first.RifProv
                    : $"{first.tipoRifProv}-{first.RifProv}";
                //string rifProveedor = first.RifProv;
                // Para IVA la tasaRetencion se determina a nivel de comprobante (todos los ítems comparten la misma lógica)
                string tasaRetencionGrupo = esIslr ? "" : (filas.Any(f => f.Impuesto > 0 && f.MontoRetenido < f.Impuesto) ? "75" : "100");

                var items = filas.Select(fila => new RetencionItemDto
                {
                    tipoTransaccion      = esIslr ? "01-REG" : fila.CodigoOperacion,
                    fechaDocumento       = fila.FechaDocumento.ToString("yyyy-MM-dd"),
                    nroDocumento         = fila.NumeroFactura,
                    nroNota              = ObtenerNroNota(fila, esIslr),
                    nroControlDocumento  = fila.NumeroControl,
                    montoTotalDocumento  = fila.Total.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                    baseImponible        = fila.Base.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                    alicuota             = esIslr ? null : (int?)fila.alicuota,
                    impuestoCausado      = fila.Impuesto.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                    impuestoRetenido     = fila.MontoRetenido.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                    compraExento         = fila.Exento.ToString("F2", System.Globalization.CultureInfo.InvariantCulture),
                    nroDocumentoAfectado = fila.Relacionado,
                    conceptoIslr         = esIslr ? fila.CodigoOperacion : null,
                    causadoRetenido      = esIslr ? fila.MontoRetenido.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) : null,
                }).ToList();

                result.Add(new RetencionRequestDto
                {
                    NroDocProfit     = first.NroDoc,
                    TipoDocProfit    = first.TipoDoc,
                    rif              = first.RifEmisor,
                    periodoFiscalDel = del,
                    periodoFiscalAl  = al,
                    rifProveedor     = rifProveedor,
                    identificacion   = first.NombreProv,
                    direccion        = first.DireccionProv,
                    correo           = first.EmailProv,
                    modeloRetencion  = modeloRetencion,
                    tipoDocumento    = first.TipoComprobante,
                    tasaRetencion    = tasaRetencionGrupo,
                    lstRetenciones   = items,
                });
            }

            return result;
        }

        private static (string del, string al) CalcularPeriodoFiscal(
            DateTime fechaEmision, int mes, int año, bool esContribuyente, bool esIslr = false)
        {
            int lastDay = DateTime.DaysInMonth(año, mes);

            // ISLR siempre usa el mes completo (1 al último día)
            if (esIslr)
                return ($"{año}-{mes:00}-01", $"{año}-{mes:00}-{lastDay:00}");

            if (esContribuyente)
            {
                if (fechaEmision.Day <= 15)
                    return ($"{año}-{mes:00}-01", $"{año}-{mes:00}-15");
                else
                    return ($"{año}-{mes:00}-16", $"{año}-{mes:00}-{lastDay:00}");
            }
            else
            {
                return ($"{año}-{mes:00}-01", $"{año}-{mes:00}-{lastDay:00}");
            }
        }

        private static string ObtenerNroNota(RetencionProfit fila, bool esIslr)
        {
            if (esIslr) return "";
            return fila.CodigoOperacion switch
            {
                "02-AJUSNC" => fila.NumeroCredito,
                "03-AJUSND" => fila.NumeroDebito,
                _           => "",
            };
        }
    }
}
