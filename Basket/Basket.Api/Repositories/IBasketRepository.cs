using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string username);

        // Create or Update existed basket
        Task<CustomerBasket> UpdateBasketAsnyc(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string username);
    }
}
 