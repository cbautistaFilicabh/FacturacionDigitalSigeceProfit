using FacturacionDigital_KatanaPanama.Class;
using FacturacionDigital_SIGECE.AppUtilities;
using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
using FacturacionDigital_SIGECE.Services.Common;
using WISE.Helpers;

namespace FacturacionDigital_SIGECE.Services
{
    public class NotaDebitoCreditoService : ApiService
    {
        ProfitService _profitService = new ProfitService();
        private string nota;
        public NotaDebitoCreditoService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<ServiceResult<NotaDebitoCreditoResponseDto>> CreateAsync(List<NotaDebitoCreditoRequestDto> dto)
        {
            try
            {
                //funcional solo cuando se procesa una única factura
                var numberNota = dto.First().nroNota;
                var typeNota = dto.First().tipo.ToLowerInvariant() == "credito" ? "n/cr" : "n/db";
                nota = typeNota;

                var url = "facturas/nota/masivanotas";
                var result = await PostAsync<NotaDebitoCreditoResponseDto>(url, dto);

                string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                if (result != null)
                {

                    string responseJson = System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
                    {
                        WriteIndented = true
                    });


                    ApiLogger.LogRequestAndResponse(url, requestJson, responseJson, $"{typeNota}_{numberNota}");

                    _profitService.RegistrarRespuestaApi(typeNota.ToUpper(), numberNota.ToString(), result);

                    return new ServiceResult<NotaDebitoCreditoResponseDto>
                    {
                        Success = true,
                        Data = result
                    };
                }
                else
                {
                    return new ServiceResult<NotaDebitoCreditoResponseDto>
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
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                // También puedes registrar el error
                ApiLogger.LogRequestAndResponse("facturacion", requestJson, $"Error API: {ex.StatusCode} - {ex.Message}", nota);

                return new ServiceResult<NotaDebitoCreditoResponseDto>
                {
                    Success = false,
                    Message = $"Error API: {ex.StatusCode} - {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });

                // También puedes registrar el error
                ApiLogger.LogRequestAndResponse("facturacion", requestJson, $"Error inesperado: {ex.Message}", nota);

                return new ServiceResult<NotaDebitoCreditoResponseDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
