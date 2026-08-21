namespace Basket.Api.Entities
{
    public class CustomerBasket
    {
        public string Username { get; set; } = default!;
        public List<BasketItem> Items { get; set; } = [];

    }
}
