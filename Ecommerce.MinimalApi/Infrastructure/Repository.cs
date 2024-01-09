using Ecommerce.Api.Models;

namespace Ecommerce.MinimalApi.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly List<Product> _products = new();

        public Repository()
        {
            this.PopulateProducts();
        }

        public async Task<Product> Create(Product product)
        {
            this._products.Add(product);

            return await Task.FromResult(product);
        }

        public async Task<Product?> FindAsync(int id)
        {
            var product = this._products.Find(e => e.Id == id);
            
            return await Task.FromResult(product);
        }

        public async Task<List<Product>> ListAsync()
        {
            return await Task.FromResult(this._products);
        }

        private void PopulateProducts()
        {
            this._products.Add(new Product()
            {
                Id = 1,
                Name = "Calzini",
                Description = "Calzini di lana",
                Price = 9.99M,
                Brand = new Brand() { Id = 1, Name = ".NET" },
                ProductType = new ProductType() { Id = 1, Type = "Accessories" }
            });

            this._products.Add(new Product()
            {
                Id = 2,
                Name = ".NET T-Shirt",
                Description = "TShirt di cotone con logo .NET",
                Price = 18.99M,
                Brand = new Brand() { Id = 1, Name = ".NET" },
                ProductType = new ProductType() { Id = 1, Type = "Tshirts" }
            });
        }
    }
}
