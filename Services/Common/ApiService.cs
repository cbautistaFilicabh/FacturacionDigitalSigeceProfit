using FacturacionDigital_SIGECE.AppUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FacturacionDigital_SIGECE.Services.Common
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        protected ApiService(string token = null)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(AppConfig.ApiBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public void SetToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        protected async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            //var jsonContent = JsonConvert.SerializeObject(data);
            var jsonContent = JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            var json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Si quieres, puedes lanzar una excepción personalizada
                throw new UnauthorizedAccessException("Credenciales incorrectas. Verifica tu usuario y contraseña.");
            }
            else
            {
                // O puedes lanzar otra excepción general
                throw new ApplicationException($"Error en API: {response.StatusCode} - {json}");
            }

        }
    }
}
