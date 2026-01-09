using Entities.Dtos.User;
using Web.Models.Common;
using Web.Models.Common.User;
using Web.Services.Auth.Abstract;

namespace Web.Services.Auth.Manager
{
    public class ApiAuthManager : IApiAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiAuthManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ApiResponse<UserForLoginResponseViewModel>> LoginAsync(UserForLoginViewModel dto)
        {
            // Program.cs üzerinden "ApiClient" bilgisini getirir
            var client = _httpClientFactory.CreateClient("ApiClient");

            // API isteği
            var response = await client.PostAsJsonAsync("auth/login", dto);

            // API'den dönen veriye göre cevap döndür
            if (!response.IsSuccessStatusCode)
            {
                return new ApiResponse<UserForLoginResponseViewModel>
                {
                    Success = false,
                    Data = null,
                    Message = "API ile bağlantı kurulamadı."
                };
            }

            return await response.Content.ReadFromJsonAsync<ApiResponse<UserForLoginResponseViewModel>>();
        }

    }
}
