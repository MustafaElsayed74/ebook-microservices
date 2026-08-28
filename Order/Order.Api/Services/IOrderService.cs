using Order.Api.Entities;

namespace Order.Api.Services
{
    public interface IOrderService
    {
        Task<CustomerOrder> CreateOrderAsync(string username, int basketId, DeliviryMethod deliviryMethod,Address address);
    }
}
