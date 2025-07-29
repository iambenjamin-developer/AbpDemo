using AbpDemo.Books;
using AbpDemo.Categories;
using AbpDemo.Products;
using AutoMapper;

namespace AbpDemo;

public class AbpDemoApplicationAutoMapperProfile : Profile
{
    public AbpDemoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();

        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
    }
}
