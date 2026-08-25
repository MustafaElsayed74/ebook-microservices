using Basket.Api.Entities;

namespace Basket.Api.Models
{
    public class BasketRequest
    {
        public string Username { get; set; } = default!;
        public List<BasketItemRequest> Items { get; set; } = [];
    }

    
}
