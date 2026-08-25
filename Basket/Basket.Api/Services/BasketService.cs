using Basket.Api.Entities;
using Basket.Api.Models;
using Basket.Api.Repositories;

namespace Basket.Api.Services
{
    // Just to handle the mapping of data comming from client and catalog api
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly CatalogApiClient _catalogApiClient;

        public BasketService(IBasketRepository basketRepository, CatalogApiClient catalogApiClient)
        {
            _basketRepository = basketRepository;
            _catalogApiClient = catalogApiClient;
        }

        public async Task<bool> DeleteBasketAsync(string username)
        {
            return await _basketRepository.DeleteBasketAsync(username);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string username)
        {
            return await _basketRepository.GetBasketAsync(username);
        }

        public async Task<CustomerBasket> UpdateBasketAsnyc(BasketRequest basketRequest)
        {
            var basket = new CustomerBasket()
            {
                Username = basketRequest.Username,
                Items = []
            };

            foreach (var item in basketRequest.Items)
            {

                var product = await _catalogApiClient.GetProductById(item.ProductId);
                if (product is null)
                    throw new KeyNotFoundException($"Product with id {item.ProductId} does not exist.");
                basket.Items.Add(new BasketItem()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Price = product.Price,
                    Color = item.Color,
                    Quantity = item.Quantity,
                });

            }
            return await _basketRepository.UpdateBasketAsnyc(basket);
        }
    }
}
