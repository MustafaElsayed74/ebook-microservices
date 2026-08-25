using Basket.Api.Entities;
using Basket.Api.Models;

namespace Basket.Api.Services
{
    public interface IBasketService
    {
        Task<CustomerBasket?> GetBasketAsync(string username);

        // Create or Update existed basket
        Task<CustomerBasket> UpdateBasketAsnyc(BasketRequest basket);
        Task<bool> DeleteBasketAsync(string username);
    }
}
