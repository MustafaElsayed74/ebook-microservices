using Catalog.Api.Entities;

namespace Catalog.Api.Repositories
{
    public interface IProductsRepository
    {
        //CRUD + by name + by category

        Task CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<IReadOnlyList<Product>> GetAllProductsAsync();
        Task<Product> GetByIdAsync(string id);
        Task<Product> GetByNameAsync(string name);
        Task<IReadOnlyList<Product>> GetByCategoryAsync(string category);
        Task<bool> DeleteProductAsync(string  id);
    }
}

