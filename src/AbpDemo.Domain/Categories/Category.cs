using AbpDemo.Products;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpDemo.Categories
{
    public class Category : AuditedAggregateRoot<long>
    {
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
