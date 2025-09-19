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
                        contribuyenteEspecial = false, //falta
                        tipoDocumento = (item.Encabezado.TipoIdentificacion ?? "V").Trim(),
                        numeroDocumento = (item.Encabezado.NumeroIdentificacion ?? "").Trim(),
                        identificacion = item.Encabezado.CliDes != null ? item.Encabezado.CliDes.Trim() : "S/N",
                        direccion = (item.Encabezado.DireccionComercial ?? "").Trim(),
                        telefonoMovil = (item.Encabezado.Telefonos ?? "").Trim(),
                        correo = (item.Encabezado.Email ?? "").Trim(),
                        ccCorreo = item.Encabezado.ccCorreo != null ? item.Encabezado.ccCorreo.Trim() : "", 
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
                                cantidad = 1,
                                precio = detalle.PrecioUnitario,
                                exento = detalle.PorcIvaRenglon == 0 ?  true : false, 
                                exonerado = detalle.exonerado, //falta
                                importe = detalle.TotalRenglon,
                                alicuotaGravamen = detalle.PorcIvaRenglon,
                                montoGravamen = detalle.IvaMontoRenglon,
                                montoDescuento = detalle.MontoDescuento,
                                descuento = detalle.PorcDescuento,
                                nrolote = detalle.nrolote, ///falta
                                fechaVenciProducto = detalle.fechaVenciProducto.ToString()  // convierto en formato DD/MM/YYYY
                            }
                        );
                    }

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
                        condicionPago = (item.Encabezado.CoCond ?? "CONTADO").Trim(),
                        facturaDivisa = (item.Encabezado.CoMone ?? "").Trim(),
                        cambioDivisa = 1,
                        tipoCambioDiaUsd = item.Encabezado.Tasa ?? 0,
                        tipoColetilla = item.Encabezado.TipoColetilla, //falta
                        tipoVenta = (item.Encabezado.TipoDeVenta ?? "").ToUpper().Trim(),
                        diasCredito = item.Encabezado.DiasCredito,
                        fechaVenciFactura = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToShortDateString().Trim() : null,
                        estatusCredito = null,
                        fechaVencimiento = item.Encabezado.FecVenc != null ? item.Encabezado.FecVenc.Value.ToShortDateString().Trim() : null,
                        modeloFactura = "GENERAL", ///falta
                        pagueAntes = null,
                        cuentaTerceros = false,
                        rifPrestador = (item.Encabezado.Rif ?? "").Trim(),
                        coletillaIGTF = item.Encabezado.ColetillaIGTF,
                        nroContrato = "",
                        observacion = item.Encabezado.ComentarioGeneral != null ? item.Encabezado.ComentarioGeneral.Trim() : null,
                        observacionInfo = item.Encabezado.Descripcion != null ? item.Encabezado.Descripcion.Trim() : null,
                        cliente = client,
                        istDetallesFacturaGeneral = detalleFac,
                        istPagos = null,
                        istGravamenes = null
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

    }
}
