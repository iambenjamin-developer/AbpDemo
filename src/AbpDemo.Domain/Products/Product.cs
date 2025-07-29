using AbpDemo.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpDemo.Products
{
    public class Product : AuditedAggregateRoot<long>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public string? ImageUrl { get; set; }


        public long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
