namespace Order.Api.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantiry { get; set; }
        public OrderStatus Status { get; set; }

        public CustomerOrder? Order { get; set; }
    }
}