using Ecommerce.Api.Models;

namespace Ecommerce.MinimalApi.Infrastructure
{
    public interface IRepository
    {
        Task<List<Product>> ListAsync();

        Task<Product?> FindAsync(int id);

        Task<Product> CreateAsync(Product product);
    }
}
