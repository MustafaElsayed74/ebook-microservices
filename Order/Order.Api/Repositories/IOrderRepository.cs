using Order.Api.Entities;

namespace Order.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<CustomerOrder>> GetOrdersByUsername(string username);
        Task<CustomerOrder?> GetOrdersById(int id);
        Task<CustomerOrder> CreateOrder(CustomerOrder order);
        Task<bool> UpdateOrder(CustomerOrder order);
        Task<bool> DeleteOrder(int id);
        Task<DeliviryMethod> GetDeliviryMethod(int id);
    }
}
