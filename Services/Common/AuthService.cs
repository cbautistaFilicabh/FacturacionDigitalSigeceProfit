using FacturacionDigital_SIGECE.AppUtilities;
using WISE.Helpers;
using WISE.Models.Auth;

namespace FacturacionDigital_SIGECE.Services.Common
{
    internal class AuthService : ApiService
    {
        public AuthService() : base()
        {
        }

        public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            try
            {
                var result = await PostAsync<LoginResponseDto>("auth/login", dto);

                if (result != null && !string.IsNullOrEmpty(result.Tokens.Access.Token))
                {
                    AppConfig.SessionToken = result.Tokens.Access.Token;
                    AppConfig.TokenExpiration = DateTime.Parse(result.Tokens.Access.Expires);

                    return new ServiceResult<LoginResponseDto>
                    {
                        Success = true,
                        Data = result
                    };
                }
                else
                {
                    return new ServiceResult<LoginResponseDto>
                    {
                        Success = false,
                        Message = "Respuesta inesperada: No se pudo obtener el token."
                    };
                }
            }
            catch (UnauthorizedException ex)
            {
                return new ServiceResult<LoginResponseDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
            catch (ApiException ex)
            {
                return new ServiceResult<LoginResponseDto>
                {
                    Success = false,
                    Message = $"Error API: {ex.StatusCode} - {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<LoginResponseDto>
                {
                    Success = false,
                    Message = $"Error inesperado: {ex.Message}"
                };
            }
        }
    }
}
