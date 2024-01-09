namespace Ecommerce.Api.Models
{
    public class Product : BaseApiEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public Brand? Brand { get; set; }

        public ProductType? ProductType { get; set; }
    }
}
