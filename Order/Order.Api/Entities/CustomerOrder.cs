namespace Order.Api.Entities
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<OrderItem> Items { get; set; } = [];
        public Address Address { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public PaymentDetails PaymentDetils { get; set; }

    }
}
