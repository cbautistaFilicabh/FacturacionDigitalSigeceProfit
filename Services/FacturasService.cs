using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Services.Common;
using FacturacionDigital_SIGECE.AppUtilities;
using WISE.Helpers;
using FacturacionDigital_KatanaPanama.Class;

namespace FacturacionDigital_SIGECE.Services
{
    public class FacturasService : ApiService
    {
        ProfitService _profitService = new ProfitService();
        public FacturasService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<ServiceResult<FacturasResponseDto>> CreateAsync(List<FacturasRequestDto> dto, string tipoDoc)
        {
            try
            {
                //funcional solo cuando se procesa una única factura

                string numberFact = dto.First().nroFactura;
                var url = "facturas/masivafacturacion";
                var result = await PostAsync<FacturasResponseDto>(url, dto);

                string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

                if (result != null)
                {

                    string responseJson = System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
                    {
                        WriteIndented = true
                    });


                    ApiLogger.LogRequestAndResponse(url, requestJson, responseJson, $"{tipoDoc}_{numberFact}");


                    if (result != null)
                    {
                        _profitService.RegistrarRespuestaApi("FACT", numberFact.ToString(), result);
                        return new ServiceResult<FacturasResponseDto>
                        {
                            Success = true,
                            Data = result
                        };
                    }
                    else
                    {
                        return new ServiceResult<FacturasResponseDto>
                        {
                            Success = false,
                            Message = "No se recibió respuesta del servidor."
                        };
                    }
                }
            catch (ApiException ex)
            {
                string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // También puedes registrar el error
                ApiLogger.LogRequestAndResponse("facturas", requestJson, $"Error API: {ex.StatusCode} - {ex.Message}", tipoDoc);


                return new ServiceResult<FacturasResponseDto>
                {
                    Success = false,
                    Message = $"Error API: {ex.StatusCode} - {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

                ApiLogger.LogRequestAndResponse("facturas", requestJson, $"Error inesperado: {ex.Message}", tipoDoc);


                return new ServiceResult<FacturasResponseDto>
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
        }

    }
}
