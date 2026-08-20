using Catalog.Api.Data;
using Catalog.Api.Shared;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region DI
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(typeof(ICatalogContext), typeof(CatalogContext));

            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));



            #endregion

            #region middelwares
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            

            app.Run();
            #endregion
        }
    }
}
