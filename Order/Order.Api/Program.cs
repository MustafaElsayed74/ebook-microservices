using Microsoft.EntityFrameworkCore;
using Order.Api.Data;
using Order.Api.Repositories;

namespace Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            builder.Services.AddDbContext<OrderDbContext>(options =>
            {
                var cs = builder.Configuration.GetConnectionString("DefaultConection")
                ?? throw new InvalidOperationException("Connection String not found");

                options.UseSqlServer(cs);
            });

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
