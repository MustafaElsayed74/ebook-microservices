using Basket.Api.Models;
using System.Net.Http.Json;

namespace Basket.Api.Services
{
    // Handles Communications with catalog API
    public class CatalogApiClient
    {
        private readonly HttpClient _httpClient;

        public CatalogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogProduct> GetProductById(string id) { 
            return await _httpClient
                .GetFromJsonAsync<CatalogProduct>($"api/v1/catalog/products/{id}");

        }
    }
}
