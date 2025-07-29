using AbpDemo.Categories;
using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products
{
    public class ProductDto : AuditedEntityDto<long>
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }
        public string? ImageUrl { get; set; }


        public CategoryDto Category { get; set; }
    }
}
