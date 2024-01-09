using Ecommerce.Api.Models;
using Ecommerce.MinimalApi.Infrastructure;

namespace Ecommerce.MinimalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IRepository, Repository>();

            var app = builder.Build();

            app.MapGet("/api/products", async (IRepository repository) => await repository.ListAsync());

            app.MapGet("api/products/{id}", async (int id, IRepository repository) =>
            {
                var product = await repository.FindAsync(id);
                return product is not null ? Results.Ok(product) : Results.NotFound();
            });

            app.MapPost("api/products/", async (Product product, IRepository repository) => await repository.Create(product));

            app.Run();
        }
    }
}
