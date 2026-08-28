using Order.Api.Dtos;

namespace Order.Api.Services
{
    public class BasketApiClient
    {
        private readonly HttpClient _httpClient;
        public BasketApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketResponseModel> GetBasketAsync(string username) {

            return await _httpClient
                  .GetFromJsonAsync<BasketResponseModel>($"api/v1/basket/{username}");
        }

    }
}
