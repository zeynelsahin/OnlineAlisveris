using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using OnlineAlisveris.Web.Services.Contracts;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Pages;

public class ProductDetailsBase : ComponentBase
{
    [Parameter] public int Id { get; set; }
    [Parameter] public Result Result { get; set; }
    [Inject] public IProductService ProductService { get; set; }

    [Inject] public ICartItemService CartItemService { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }
    protected DataResult<ProductDto> Product { get; private set; } = new() { Data = null, Message = null, Success = false };

    protected override async Task OnInitializedAsync()
    {
        Product = await ProductService.GetAllProductDtoByProductId(Id);
    }

    protected async Task AddToCart_Click(CartItemToAddDto cartItemToAddDto)
    {
        Result = await CartItemService.Add(cartItemToAddDto);
        NavigationManager.NavigateTo("/ShoppingCart");
    }
}