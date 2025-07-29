using Volo.Abp.Application.Dtos;

namespace AbpDemo.Categories
{
    public class CategoryDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }
    }
}
