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
        public NotaDebitoCreditoService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<ServiceResult<NotaDebitoCreditoResponseDto>> CreateAsync(List<NotaDebitoCreditoRequestDto> dto)
        {
            try
            {
                //funcional solo cuando se procesa una única factura
                var numberNota = dto.Select(f => f.nroNota);
                var typeNota = dto.Select(f => f.tipo);

                var url = "facturas/notas/masivanotas";
                var result = await PostAsync<NotaDebitoCreditoResponseDto>(url, dto);

                if (result != null)
                {
                    _profitService.RegistrarRespuestaApi(typeNota.ToString(), numberNota.ToString(), result);

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
                return new ServiceResult<NotaDebitoCreditoResponseDto>
                {
                    Success = false,
                    Message = $"Error API: {ex.StatusCode} - {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<NotaDebitoCreditoResponseDto>
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
        }
    }
}
