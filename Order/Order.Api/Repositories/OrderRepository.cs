using Microsoft.EntityFrameworkCore;
using Order.Api.Data;
using Order.Api.Entities;

namespace Order.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CustomerOrder> CreateOrder(CustomerOrder order)
        {
            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order == null)
                return false;


            _dbContext.Orders.Remove(order);
            return await _dbContext.SaveChangesAsync() > 0;

        }

        public async Task<DeliviryMethod> GetDeliviryMethod(int id)
        {
            return await _dbContext.deliviryMethods.FindAsync(id);
        }

        public async Task<CustomerOrder?> GetOrdersById(int id)
        {
            return await _dbContext
                .Orders
                .Include(o => o.ShippingAddress)
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

        }

        public async Task<IReadOnlyList<CustomerOrder>> GetOrdersByUsername(string username)
        {
            return await _dbContext
                .Orders
                .Include(o => o.Items)
                .Include(o => o.ShippingAddress)
                .Where(o => o.Username == username)
                .ToListAsync();
        }

        public async Task<bool> UpdateOrder(CustomerOrder order)
        {
            _dbContext.Orders.Update(order);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
