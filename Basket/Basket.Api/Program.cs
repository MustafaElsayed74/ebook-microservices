using Basket.Api.Repositories;
using StackExchange.Redis;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();
            builder.Services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var cs = builder.Configuration.GetConnectionString("Redis") ?? throw new InvalidOperationException("Connection String Not Found"); ;

                return ConnectionMultiplexer.Connect(cs);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
