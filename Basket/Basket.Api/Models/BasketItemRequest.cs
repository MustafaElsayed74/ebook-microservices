namespace Basket.Api.Models
{
    public class BasketItemRequest
    {
        public int Quantity { get; set; }
        public string Color { get; set; } = default!;
        public string ProductId { get; set; } = default!;
    }
}