namespace Order.Api.Entities
{
    public class CustomerOrder : BaseEntity
    {

        public CustomerOrder()
        {
            
        }

        public CustomerOrder(string username, ICollection<OrderItem> items, DeliviryMethod deliviryMethod, Address shippingAddress, decimal subTotal, string paymentIntentId)
        {
            Username = username;
            Items = items;
            Status = status;
            OrderDate = orderDate;
            DeliviryMethod = deliviryMethod;
            ShippingAddress = shippingAddress;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }

        public string Username { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public DeliviryMethod  DeliviryMethod { get; set; }
        public Address ShippingAddress { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GetTotal() 
             => SubTotal + DeliviryMethod.Cost;

        public string PaymentIntentId { get; set; }


    }
}
