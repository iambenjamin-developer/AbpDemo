using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpDemo.Products
{
    public interface IProductAppService :
     ICrudAppService< //Defines CRUD methods
         ProductDto, //Used to show books
         long, //Primary key of the book entity
         PagedAndSortedResultRequestDto, //Used for paging/sorting
         CreateUpdateProductDto> //Used to create/update a book
    {

    }
}
