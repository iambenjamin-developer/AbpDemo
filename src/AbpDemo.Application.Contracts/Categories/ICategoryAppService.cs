using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpDemo.Categories
{
    public interface ICategoryAppService :
    ICrudAppService< //Defines CRUD methods
        CategoryDto, //Used to show books
        long, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCategoryDto> //Used to create/update a book
    {

    }
}
