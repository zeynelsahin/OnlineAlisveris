using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace OnlineAlisveris.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartItemController : Controller
{
    private ICartItemService _cartItemService;

    public CartItemController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    // GET
    [NonAction]
    private async Task<IActionResult> Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _cartItemService.GetByIdAsync(id);
        return await Dondur(result);
    }

    [HttpGet("GetAllByUserId")]
    public async Task<IActionResult> GetProductDtoByProductId(int userId)
    {
        var result = await _cartItemService.GetAllByUserIdAsync(userId);
        return await Dondur(result);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CartItemToAddDto cartItemToAddDto)
    {
        var result = await _cartItemService.AddItem(cartItemToAddDto);
        return await Dondur(result);
    }
    [HttpGet("GetCartItemProducts")]
    public async Task<IActionResult> GetCartItemProducts()
    {
        var result = await _cartItemService.GetCartItemProductsAsync();
        return await Dondur(result);
    }
    [HttpGet("GetCartItemProductsByCartId")]
    public async Task<IActionResult> GetCartItemProductsByCartId(int cartId)
    {
        var result = await _cartItemService.GetCartItemProductsByCartIdAsync(cartId);
        return await Dondur(result);
    }
    
}