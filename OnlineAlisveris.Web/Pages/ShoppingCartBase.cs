using Business.Concrete;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using OnlineAlisveris.Web.Services.Contracts;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Pages;

public class ShoppingCartBase : ComponentBase
{
    [Inject]
    public IJSRuntime Js { get; set; }
    [Inject] public ICartItemService CartItemService { get; set; }

    protected DataResult<List<CartItemDto>> CartItems { get; private set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CartItems = await CartItemService.GetAllByUserId(HardCodded.UserId);
        CalculateCartSummaryTotals();
    }


    protected Result Result { get; set; }
    protected string TotalPrice { get; set; }
    protected int TotalQuantity { get; set; }

    protected async Task DeleteCartItem_Click(int id)
    {
        var result = await CartItemService.Delete(id);
        var entity = CartItems.Data.SingleOrDefault(dto => dto.Id == id);
        var data = CartItems.Data.ToList();
        data.Remove(entity);
        Result = result;
        CartItems.Data = data;
        
        CalculateCartSummaryTotals();
    }

    protected async Task UpdateCartItemQty_Click(int id, int qty)
    {
        if (qty > 0)
        {
            var result = await CartItemService.UpdateQty(new CartItemQtyUpdateDto() { CartItemId = id, Qty = qty });
            Result = result;
            var updatedEntity = GetCartItem(id);
            UpdateItemTotalPrice(updatedEntity);
            CalculateCartSummaryTotals();
        }
        else
        {
            Result = new Result() { Message = "Adet 0 dan farklı olmalıdır.", Success = false };
        }
    }

    private void UpdateItemTotalPrice(CartItemDto cartItemDto)
    {
        var item = GetCartItem(cartItemDto.Id);
        if (item != null)
        {
            item.TotalPrice = cartItemDto.Price * cartItemDto.Qty;
        }
    }

    private CartItemDto GetCartItem(int id)
    {
        return CartItems.Data.FirstOrDefault(i => i.Id == id);
    }

    private void CalculateCartSummaryTotals()
    {
        SetTotalPrice();
        SetTotalQuantity();
    }

    private void SetTotalPrice()
    {
        TotalPrice = CartItems.Data.Sum(dto => dto.TotalPrice).ToString("C");
    }

    private void SetTotalQuantity()
    {
        TotalQuantity = CartItems.Data.Sum(dto => dto.Qty);
    }

    protected async Task UpdateQty_Input(int id)
    {
        await MakeUpdateQtyButtonVisible(id, true);
    }

    private async Task MakeUpdateQtyButtonVisible(int id, bool visible)
    {
        await Js.InvokeVoidAsync("MakeUpdateQtyButtonVisible", id, visible);
    }

}