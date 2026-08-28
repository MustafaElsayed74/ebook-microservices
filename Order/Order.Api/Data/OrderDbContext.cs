using Microsoft.EntityFrameworkCore;
using Order.Api.Entities;

namespace Order.Api.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options):base(options)
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerOrder>()
                .HasMany(o => o.Items)
                .WithOne()
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerOrder>().Property(o => o.SubTotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>().Property(i => i.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DeliviryMethod>().Property(i => i.Cost)
              .HasColumnType("decimal(18,2)");
        }

        public DbSet<CustomerOrder> Orders { get; set; } 
        public DbSet<OrderItem> items { get; set; } 
        public DbSet<DeliviryMethod> deliviryMethods { get; set; } 
    }
}
