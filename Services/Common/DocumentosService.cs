using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
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
        public void CreateDocument(string typeDocument, object data)
        {
            switch (typeDocument.ToLowerInvariant())
            {
                case "factura":
                    var _facturaService = new FacturasService();
                    _facturaService.CreateAsync((List<FacturasRequestDto>)data);
                    break;
                case "nota_credito":
                case "nota_debito":
                    var _notaDebitoCreditoService = new NotaDebitoCreditoService();
                    _notaDebitoCreditoService.CreateAsync((List<NotaDebitoCreditoRequestDto>)data);
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

        //public FacturasRequestDto MapAdminToApi(AdminFacturaDto adminDto)
        //{
        //    return new FacturasRequestDto
        //    {
        //        ClienteId = adminDto.CodCliente,
        //        Fecha = DateTime.Parse(adminDto.FechaEmision),
        //        Total = adminDto.MontoTotal
        //    };
        //}

    }
}
