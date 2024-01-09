using Ecommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Faking a repo
        private readonly List<Product> _products = new();

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this._logger = logger;

            this.PopulateProducts();
        }

        [HttpGet("{id}")]
        public IActionResult FindProduct(int id)
        {
            var product = this._products.Find(e => e.Id == id);

            if (product == null)
            {
                this._logger.LogInformation("Product with id {Id} not found", id);

                return NotFound();
            }

            return Ok(product);
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
