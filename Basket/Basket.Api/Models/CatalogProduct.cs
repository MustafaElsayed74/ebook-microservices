namespace Basket.Api.Models
{
    public class CatalogProduct
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
