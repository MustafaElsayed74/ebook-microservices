namespace Order.Api.Dtos
{
    public class CatalogProductModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
