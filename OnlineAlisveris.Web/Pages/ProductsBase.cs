using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using OnlineAlisveris.Web.Services.Contracts;

namespace OnlineAlisveris.Web.Pages;

public class ProductsBase: ComponentBase
{
    [Inject]
    public IProductService ProductService { get; set; }

    public IEnumerable<ProductDto> Products;

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetAllProductDto();
    }

    protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetGroupedProductByCategory()
    {
         return (from product in Products group product by product.CategoryId into prodByCatGroup orderby prodByCatGroup.Key select prodByCatGroup);
    }

    protected string GetCategoryName(IGrouping<int, ProductDto> groupedProductDtos)
    {
        return groupedProductDtos.FirstOrDefault(pg => pg.CategoryId == groupedProductDtos.Key).CategoryName;
    }
}