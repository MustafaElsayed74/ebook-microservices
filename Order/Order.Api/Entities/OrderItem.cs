namespace Order.Api.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
            
        }

        public OrderItem(string productId, string productName, decimal price, int quantiry)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantiry = quantiry;
        }

        public int OrderId { get; set; }

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        

        public decimal Price { get; set; }
        public int Quantiry { get; set; }
        
    }
}