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

        public async Task<ServiceResult<FacturasResponseDto>> CreateAsync(List<FacturasRequestDto> dto)
        {
            try
            {
                //funcional solo cuando se procesa una única factura

                string numberFacts = "";

                foreach (var fact in dto)
                {
                    if (numberFacts == "")
                    {
                        numberFacts = fact.nroFactura;
                    }
                    else
                    {
                        numberFacts += $"_{fact.nroFactura}";
                    }
                }

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


                    ApiLogger.LogRequestAndResponse(url, requestJson, responseJson, $"FACT_{numberFacts}");

                    _profitService.RegistrarRespuestaApi("FACT", numberFacts, result);

                    if (result.DetalleErrorFacturas == null)
                    {
                        return new ServiceResult<FacturasResponseDto>
                        {
                            Success = true,
                            Data = result
                        };
                    }
                    else
                    {
                        var errorMessages = new List<string>();
                        foreach (var errorList in result.DetalleErrorFacturas)
                        {
                            foreach (var error in errorList)
                            {
                                errorMessages.Add($"{error.NroFactura}: {error.Msg} /n");
                            }
                        }

                        return new ServiceResult<FacturasResponseDto>
                        {
                            Success = false,
                            Message = "Errores al procesar las facturas. /N Detalles:" + errorMessages,
                            Data = result
                        };
                    }

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
                ApiLogger.LogRequestAndResponse("facturas", requestJson, $"Error API: {ex.StatusCode} - {ex.Message}", "FACT");


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

                ApiLogger.LogRequestAndResponse("facturas", requestJson, $"Error inesperado: {ex.Message}", "FACT");


                return new ServiceResult<FacturasResponseDto>
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
        }

    }
}
