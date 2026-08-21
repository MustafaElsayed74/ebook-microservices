using Basket.Api.Entities;
using StackExchange.Redis;
using System.Text.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<CustomerBasket?> GetBasketAsync(string username)
        {
            var basket = await _database.StringGetAsync(username);

            if(basket.IsNullOrEmpty)
            {
                return null;
            }

            return JsonSerializer.Deserialize<CustomerBasket>(basket.ToString()); 
        }



        public async Task<CustomerBasket> UpdateBasketAsnyc(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(
                basket.Username,
                JsonSerializer.Serialize(basket)
            );

            if (!created)
                throw new Exception("Error Ssving basket");

            return basket;
        }


        public async Task<bool> DeleteBasketAsync(string username)
        {
            return await _database.KeyDeleteAsync(username);
        }
    }
}
