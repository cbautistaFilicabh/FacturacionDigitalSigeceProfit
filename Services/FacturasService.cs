using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Services.Common;
using FacturacionDigital_SIGECE.AppUtilities;
using WISE.Helpers;

namespace FacturacionDigital_SIGECE.Services
{
    public class FacturasService : ApiService
    {
        public FacturasService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<ServiceResult<FacturasResponseDto>> CreateAsync(List<FacturasRequestDto> dto)
        {
            try
            {
                var url = "facturas/masivafacturacion";
                var result = await PostAsync<FacturasResponseDto>(url, dto);

                if (result != null)
                {
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
                return new ServiceResult<FacturasResponseDto>
                {
                    Success = false,
                    Message = $"Error API: {ex.StatusCode} - {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<FacturasResponseDto>
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
        }

    }
}
