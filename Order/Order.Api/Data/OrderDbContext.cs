using Microsoft.EntityFrameworkCore;

namespace Order.Api.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {

        }
    }
}
