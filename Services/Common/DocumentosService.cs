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
        public void CreateDocument(string typeDocument, string data)
        {
            switch (typeDocument.ToLowerInvariant())
            {
                case "factura":
                    var _facturaService = new FacturasService();
                    var listData = DeserializeJsonToList<FacturasRequestDto>(data);
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
                    new ClienteDto
                    {
                        contribuyenteEspecial = false,
                        tipoDocumento = "",
                        numeroDocumento = "",
                        identificacion = "",
                        direccion = "",
                        telefonoMovil = "",
                        correo = "",
                        ccCorreo = "",
                        tipoPersona = "",
                        tipoProveedor = ""
                    };

                    new DetalleFacturaDto
                    {
                        codigoProducto = "",
                        descripcion = "",
                        unidadMedida = "",
                        cantidad = 0,
                        precio = 0,
                        exento = false,
                        exonerado = false,
                        importe = 0,
                        alicuotaGravamen = 0,
                        montoGravamen = 0,
                        montoDescuento = 0,
                        descuento = 0,
                        nrolote = "",
                        fechaVenciProducto = ""
                    };

                    new PagoDto
                    {
                        modoPago = "",
                        nro = "",
                        monto = 0,
                        fechaComprobantePago = "",
                        banco = "",
                        divisa = "",
                        tasaDiaDivisa = 0,
                        diasCredito = 0,
                        igtf = false
                    };

                    facturaDto = new FacturasRequestDto
                    {
                        rif = item.Encabezado.Rif ?? "",
                        nroFactura = item.Encabezado.NroDoc ?? "",
                        importeTotal = item.Encabezado.TotalGeneral ?? 0,
                        codigoSucursal = item.Encabezado.Sucursal,
                        serie = item.Encabezado.Serie,
                        serieNrofactura = item.Encabezado.Serie,
                        //subTotal = 0,
                        montoDescuento = item.Encabezado.MontoDescGlob ?? 0,
                        totalExento = item.Encabezado.MontoExentoTotal ?? 0,
                        //totalExonerado = 0,
                        condicionPago = "",
                        facturaDivisa = item.Encabezado.CoMone,
                        cambioDivisa = 1,
                        tipoCambioDiaUsd = item.Encabezado.Tasa ?? 0,
                        tipoColetilla = false,
                        tipoVenta = "",
                        diasCredito = 0,
                        fechaVenciFactura = item.Encabezado.FecVenc.ToString(),
                        estatusCredito = "",
                        fechaVencimiento = item.Encabezado.FecVenc.ToString(),
                        modeloFactura = "",
                        pagueAntes = "",
                        cuentaTerceros = false,
                        rifPrestador = "",
                        coletillaIGTF = false,
                        nroContrato = "",
                        observacion = "",
                        observacionInfo = "",
                        cliente = new ClienteDto
                        {
                            contribuyenteEspecial = false,
                            tipoDocumento = "",
                            numeroDocumento = "",
                            identificacion = "",
                            direccion = "",
                            telefonoMovil = "",
                            correo = "",
                            ccCorreo = "",
                            tipoPersona = "",
                            tipoProveedor = ""
                        },
                        istDetallesFacturaGeneral = new List<DetalleFacturaDto>(),
                        istPagos = new List<PagoDto>(),
                        istGravamenes = new List<GravamenDto>()
                    };

                    newDto.Add((T)(object)facturaDto);
                }
            }
            else
            {
                throw new NotSupportedException($"Mapping to type {typeof(T).Name} is not supported.");
                return null;
            }

            return newDto;

        }

    }
}
