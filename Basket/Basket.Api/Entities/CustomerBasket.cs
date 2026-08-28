namespace Basket.Api.Entities
{
    public class CustomerBasket
    {
        public string Username { get; set; } = default!;
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public List<BasketItem> Items { get; set; } = [];

    }
}
