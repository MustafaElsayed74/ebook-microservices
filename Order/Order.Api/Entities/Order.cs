namespace Order.Api.Entities
{
    public class Order
    {
        public List<OrderItem> Items { get; set; } = [];
        public string Address { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
    }
}
