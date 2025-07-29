using Volo.Abp.Application.Dtos;

namespace AbpDemo.Categories
{
    public class CreateUpdateCategoryDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }
    }
}
