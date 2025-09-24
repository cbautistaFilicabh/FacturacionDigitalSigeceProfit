using Azure;
using FacturacionDigital_SIGECE.Models;
using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
using FacturacionDigital_SIGECE.Models.Profit;
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
        public async Task CreateDocument(string typeDocument, List<FacturaProfit> data)
        {
            switch (typeDocument.ToLowerInvariant())
            {
                case "fact":
                    var _facturaService = new FacturasService();
                    var listDataFact = MapAdminToApi<FacturasRequestDto>(data) ?? new List<FacturasRequestDto>();

                    var responseFact = await _facturaService.CreateAsync(listDataFact);

                    if (responseFact.Success && responseFact.Data != null)
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

                        if (responseNota.Data.DetalleFacturaProcesadas?.Any() == true)
                        {
                            msg.AppendLine("Documentos procesados correctamente:");

                            var facturasProcesadas = responseNota.Data.DetalleFacturaProcesadas
                                .SelectMany(list => list) // aplanar la lista de listas
                                .ToList();

                            foreach (var proc in facturasProcesadas)
                            {
                                msg.AppendLine($"Número:{proc.NroFactura}");
                                msg.AppendLine("N. Control: {proc.NroControl}");
                            }
                            msg.AppendLine();
                        }

                        if (responseNota.Data.DetalleErrorFacturas?.Any() == true)
                        {

                            var facturasError = responseNota.Data.DetalleErrorFacturas.SelectMany(list => list).ToList();

                            var facturasUnicas = facturasError.GroupBy(e => e.NroFactura).Select(g => g.First()).ToList();

                            msg.AppendLine("Documentos no procesados:" + string.Join(", ", facturasUnicas.Select(e => e.NroFactura)));

                            msg.AppendLine();
                            msg.AppendLine($"Total de errores: {facturasError.Count}");
                            msg.AppendLine("Revisa el histórico para más detalles.");
                        }
                        // Mostrar mensaje al usuario
                        MessageBox.Show(msg.ToString(), "Resultado Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show($"Error al crear notas: {responseNota.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    throw new ArgumentException("Tipo de documento no soportado.");
            }
        }

        public List<T> DeserializeJsonToList<T>(string json)
        {
            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<T>();
        }

        public List<T>? MapAdminToApi<T>(List<FacturaProfit> profitItems)
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

                    //Detalles de la factura
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
                                montoDescuento = detalle.MontoDescuento,
                                descuento = detalle.PorcDescuento,
                                nrolote = detalle.nrolote, ///falta
                                fechaVenciProducto = detalle.fechaVenciProducto.HasValue ? detalle.fechaVenciProducto.Value.ToString("yyyy-MM-dd") : null
                            }
                        );
                    }

                    var lstGravamen = GravamenList(detalleFac);

                    facturaDto = new FacturasRequestDto
                    {
                        rif = (item.Encabezado.RifEmisor ?? "").Trim(),
                        nroFactura = (item.Encabezado.NroDoc ?? "").Trim(),
                        importeTotal = item.Encabezado.TotalGeneral ?? 0,
                        codigoSucursal = string.IsNullOrWhiteSpace(item.Encabezado.Sucursal) ? null : item.Encabezado.Sucursal.Trim(),
                        serie = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        serieNrofactura = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        subTotal = (item.Encabezado.SubTotal) ?? 0,
                        montoDescuento = item.Encabezado.MontoDescGlob ?? 0,
                        totalExento = item.Encabezado.MontoExentoTotal ?? 0,
                        totalExonerado = item.Encabezado.TotalExonerado,
                        condicionPago = "CONTADO", //(item.Encabezado.CondDes ?? "CONTADO").Trim(),
                        facturaDivisa = (item.Encabezado.CoMone ?? "").Trim(),
                        cambioDivisa = 1,
                        tipoCambioDiaUsd = item.Encabezado.Tasa ?? 0,
                        tipoColetilla = item.Encabezado.TipoColetilla, //falta
                        tipoVenta = "INTERNA",
                        diasCredito = item.Encabezado.DiasCredito,
                        fechaVenciFactura = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToString("yyyy-MM-dd").Trim() : null,
                        //estatusCredito = ,
                        fechaVencimiento = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToString("yyyy-MM-dd").Trim() : null,
                        modeloFactura = "GENERAL", ///falta
                        pagueAntes = null,
                        cuentaTerceros = false,
                        rifPrestador = (item.Encabezado.Rif ?? "").Trim(),
                        coletillaIGTF = true,
                        nroContrato = null,
                        observacion = item.Encabezado.ComentarioGeneral != null ? item.Encabezado.ComentarioGeneral.Trim() : null,
                        observacionInfo = item.Encabezado.Descripcion != null ? item.Encabezado.Descripcion.Trim() : null,
                        cliente = client,
                        lstDetallesFacturaGeneral = detalleFac,
                        lstPagos = null,
                        lstGravamenes = lstGravamen
                    };

                    newDto.Add((T)(object)facturaDto);
                }
            }
            else
            {
                throw new NotSupportedException($"Mapping to type {typeof(T).Name} is not supported.");
            }

            return newDto;
        }

        public static List<GravamenDto> GravamenList(List<DetalleFacturaDto> productsList)
        {
            try
            {
                if (productsList == null || productsList.Count == 0)
                    return new List<GravamenDto>();

                var alicuotasValidas = new int[] { 16, 8, 31 };
                var result = new List<GravamenDto>();

                foreach (var item in productsList)
                {
                    if (item.exento || !alicuotasValidas.Contains(Convert.ToInt32(item.alicuotaGravamen)))
                        continue;

                    // Buscar si ya existe un registro con esa alícuota
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

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al generar la lista de gravámenes.", ex);
            }
        }
    }
}
