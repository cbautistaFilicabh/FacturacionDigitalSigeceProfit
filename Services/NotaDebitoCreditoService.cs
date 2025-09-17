using FacturacionDigital_SIGECE.Models.NotaDebidoCredito;
using FacturacionDigital_SIGECE.Services.Common;
using FacturacionDigital_SIGECE.AppUtilities;

namespace FacturacionDigital_SIGECE.Services
{
    public class NotaDebitoCreditoService : ApiService
    {
        public NotaDebitoCreditoService() : base(AppConfig.SessionToken)
        {
        }

        public async Task<NotaDebitoCreditoResponseDto?> CreateAsync(NotaDebitoCreditoRequestDto dto)
        {
            var url = "facturas/notas/masivanotas";
            return await PostAsync<NotaDebitoCreditoResponseDto>(url, dto);
        }
    }
}
