using FacturacionDigital_KatanaPanama.Class;
using FacturacionDigital_SIGECE.AppUtilities;
using FacturacionDigital_SIGECE.Models.Retenciones;
using FacturacionDigital_SIGECE.Services.Common;
using WISE.Helpers;

namespace FacturacionDigital_SIGECE.Services
{
    public class RetencionService : ApiService
    {
        private readonly ProfitService _profitService = new ProfitService();

        public RetencionService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<ServiceResult<RetencionResponseDto>> CreateAsync(List<RetencionRequestDto> dto)
        {
            var url = "retenciones/createRetencionIvaMasiva/";

            string nrosDocs = string.Join("_", dto.Select(r => r.NroDocProfit));
            string tipoDoc = string.Join("_", dto.Select(r => r.TipoDocProfit));

            string requestJson = System.Text.Json.JsonSerializer.Serialize(dto, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            });

            try
            {
                var result = await PostAsync<RetencionResponseDto>(url, dto);

                if (result != null)
                {
                    string responseJson = System.Text.Json.JsonSerializer.Serialize(result, new System.Text.Json.JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    ApiLogger.LogRequestAndResponse(url, requestJson, responseJson, $"{tipoDoc}_{nrosDocs}");

                    // Registrar cada comprobante (procesado o con error) en sfEstadoDocumento
                    foreach (var retencion in dto)
                    {
                        _profitService.RegistrarRespuestaApi(tipoDoc, retencion.NroDocProfit, result);
                    }

                    if (result.TotalRetencionIvaconError == 0)
                    {
                        return new ServiceResult<RetencionResponseDto>
                        {
                            Success = true,
                            Data = result
                        };
                    }
                    else
                    {
                        var errorMessages = result.DetalleErrorRetencionesIva
                            .Select(e => e.msg)
                            .Where(m => !string.IsNullOrEmpty(m))
                            .Select(m => $"- {m}");

                        return new ServiceResult<RetencionResponseDto>
                        {
                            Success = false,
                            Message = "Errores al procesar retenciones:\n" + string.Join("\n", errorMessages),
                            Data = result
                        };
                    }
                }
                else
                {
                    return new ServiceResult<RetencionResponseDto>
                    {
                        Success = false,
                        Message = "No se recibió respuesta del servidor."
                    };
                }
            }
            catch (ApiException ex)
            {
                string errorMsg = $"Error API: {ex.StatusCode} - {ex.Message}";
                ApiLogger.LogRequestAndResponse(url, requestJson, errorMsg, tipoDoc);

                var errorResponse = new RetencionResponseDto
                {
                    TotalRetencionIvaconError = dto.Count,
                    DetalleErrorRetencionesIva = new List<DetalleErrorRetencion>
                    {
                        new DetalleErrorRetencion { msg = errorMsg }
                    }
                };
                foreach (var retencion in dto)
                    _profitService.RegistrarRespuestaApi(tipoDoc, retencion.NroDocProfit.Trim(), errorResponse);

                return new ServiceResult<RetencionResponseDto>
                {
                    Success = false,
                    Message = errorMsg
                };
            }
            catch (Exception ex)
            {
                string errorMsg = $"Error inesperado: {ex.Message}";
                ApiLogger.LogRequestAndResponse(url, requestJson, errorMsg, tipoDoc);

                var errorResponse = new RetencionResponseDto
                {
                    TotalRetencionIvaconError = dto.Count,
                    DetalleErrorRetencionesIva = new List<DetalleErrorRetencion>
                    {
                        new DetalleErrorRetencion { msg = errorMsg }
                    }
                };
                foreach (var retencion in dto)
                    _profitService.RegistrarRespuestaApi(tipoDoc, retencion.NroDocProfit, errorResponse);

                return new ServiceResult<RetencionResponseDto>
                {
                    Success = false,
                    Message = errorMsg
                };
            }
        }
    }
}
