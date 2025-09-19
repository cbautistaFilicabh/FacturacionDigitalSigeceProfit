using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
using FacturacionDigital_SIGECE.Models.Profit;
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
        public void CreateDocument(string typeDocument, List<FacturaProfit> data)
        {
            //var json = DeserializeJsonToList<FacturaProfit>(data);
            switch (typeDocument.ToLowerInvariant())
            {
                case "factura":
                    var _facturaService = new FacturasService();
                    var listData = MapAdminToApi<FacturasRequestDto>(data) ?? new List<FacturasRequestDto>();
                    _facturaService.CreateAsync(listData);
                    break;
                case "nota_credito":
                case "nota_debito":
                    var _notaDebitoCreditoService = new NotaDebitoCreditoService();
                    //_notaDebitoCreditoService.CreateAsync((List<NotaDebitoCreditoRequestDto>)data);
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
                        contribuyenteEspecial = false,
                        tipoDocumento = (item.Encabezado.TipoIdentificacion ?? "V").Trim(),
                        numeroDocumento = (item.Encabezado.NumeroIdentificacion ?? "").Trim(),
                        identificacion = "Nombre",
                        direccion = (item.Encabezado.DireccionComercial ?? "").Trim(),
                        telefonoMovil = (item.Encabezado.Telefonos ?? "").Trim(),
                        correo = (item.Encabezado.Email ?? "").Trim(),
                        ccCorreo = null,
                        tipoPersona = "CLIENTE",
                        tipoProveedor = "PJD"
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
                                unidadMedida = "UNIDAD", //(detalle.UnidadDeMedida ?? "").Trim(),
                                cantidad = 1,
                                precio = detalle.PrecioUnitario,
                                exento = false,
                                exonerado = false,
                                importe = detalle.TotalRenglon,
                                alicuotaGravamen = detalle.PorcIvaRenglon,
                                montoGravamen = detalle.IvaMontoRenglon,
                                montoDescuento = detalle.MontoDescuento,
                                descuento = detalle.PorcDescuento,
                                nrolote = null,
                                fechaVenciProducto = null
                            }
                        );
                    }

                    var lstGravamen = GravamenList(detalleFac);

                    facturaDto = new FacturasRequestDto
                    {
                        rif = "J-411691283",//(item.Encabezado.Rif ?? "").Trim(),
                        nroFactura = (item.Encabezado.NroDoc ?? "").Trim(),
                        importeTotal = item.Encabezado.TotalGeneral ?? 0,
                        codigoSucursal = string.IsNullOrWhiteSpace(item.Encabezado.Sucursal) ? null : item.Encabezado.Sucursal.Trim(),
                        serie = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        serieNrofactura = string.IsNullOrWhiteSpace(item.Encabezado.Serie) ? null : item.Encabezado.Serie.Trim(),
                        subTotal = (item.Encabezado.MontoGravadoTotal + item.Encabezado.MontoExentoTotal) ?? 0,
                        montoDescuento = item.Encabezado.MontoDescGlob ?? 0,
                        totalExento = item.Encabezado.MontoExentoTotal ?? 0,
                        totalExonerado = 0,
                        condicionPago = (item.Encabezado.CoCond ?? "CONTADO").Trim(),
                        facturaDivisa = (item.Encabezado.CoMone ?? "").Trim(),
                        cambioDivisa = 1,
                        tipoCambioDiaUsd = 165.41m, // item.Encabezado.Tasa ?? 0,
                        tipoColetilla = false,
                        tipoVenta = (item.Encabezado.TipoDeVenta ?? "").ToUpper().Trim(),
                        diasCredito = null,
                        fechaVenciFactura = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToShortDateString().Trim() : null,
                        estatusCredito = null,
                        fechaVencimiento = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToShortDateString().Trim() : null,
                        modeloFactura = "GENERAL",
                        pagueAntes = null,
                        cuentaTerceros = false,
                        rifPrestador = (item.Encabezado.Rif ?? "").Trim(),
                        coletillaIGTF = true,
                        nroContrato = "1234567",
                        observacion = item.Encabezado.ComentarioGeneral != null ? item.Encabezado.ComentarioGeneral.Trim() : null,
                        observacionInfo = item.Encabezado.Descripcion != null ? item.Encabezado.Descripcion.Trim() : null,
                        cliente = client,
                        istDetallesFacturaGeneral = detalleFac,
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
                            baseImponible = item.precio,
                            montoAlicuota = item.montoGravamen
                        });
                    }
                    else
                    {
                        existente.baseImponible += item.precio;
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
