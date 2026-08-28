using Order.Api.Entities;

namespace Order.Api.Dtos.Order
{
    public class OrderRequestDto
    {
        public string Username { get; set; }
        public string BasketId { get; set; }
        public DeliviryMethod  DeliviryMethod { get; set; }
        public Address ShippingAddress { get; set; }
    }
}
