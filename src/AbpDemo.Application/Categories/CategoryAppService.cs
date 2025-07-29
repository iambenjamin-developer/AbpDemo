using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpDemo.Categories
{
    public class CategoryAppService :
   CrudAppService<
       Category, //The Category entity
       CategoryDto, //Used to show categories
       long, //Primary key of the Category entity
       PagedAndSortedResultRequestDto, //Used for paging/sorting
       CreateUpdateCategoryDto>, //Used to create/update a Category
   ICategoryAppService//implement the ICategoryAppService
    {
        public CategoryAppService(IRepository<Category, long> repository)
            : base(repository)
        {

        }
    }
}
