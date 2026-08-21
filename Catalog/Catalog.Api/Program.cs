using Catalog.Api.Data;
using Catalog.Api.Repositories;
using Catalog.Api.Shared;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dependency Injection

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
            builder.Services.AddScoped<IProductsRepository,ProductsRepository>();

            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("DatabaseSettings")
            );

            var app = builder.Build();

            // Middleware

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}