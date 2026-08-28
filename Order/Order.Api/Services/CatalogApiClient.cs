using Order.Api.Dtos;

namespace Order.Api.Services
{
    public class CatalogApiClient
    {
        private readonly HttpClient _httpClient;

        public CatalogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogProductModel> GetProductById(string id)
        {
            return await _httpClient
                .GetFromJsonAsync<CatalogProductModel>($"api/v1/catalog/products/{id}");

        }
    }
