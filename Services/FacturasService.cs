using FacturacionDigital_SIGECE.Models.Facturas;
using FacturacionDigital_SIGECE.Services.Common;
using FacturacionDigital_SIGECE.AppUtilities;

namespace FacturacionDigital_SIGECE.Services
{
    public class FacturasService : ApiService
    {
        public FacturasService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<FacturasResponseDto?> CreateAsync(List<FacturasRequestDto> dto)
        {
            var url = "facturas/masivafacturacion";
            return await PostAsync<FacturasResponseDto>(url, dto);
        }
    }
}
