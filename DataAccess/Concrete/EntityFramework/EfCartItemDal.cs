using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfCartItemDal : EfEntityRepositoryBase<CartItem, ShopOnlineContext>, ICartItemDal
{
    public async Task<IEnumerable<CartItem>> GetAllByUserIdAsync(int userId)
    {
        await using var context = new ShopOnlineContext();
        var result = (from cart in context.Carts
            join cartItem in context.CartItems on cart.Id equals cartItem.CartId
            where cart.UserId == userId
            select new CartItem()
            {
                Id = cartItem.Id,
                Qty = cartItem.Qty,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId
            }).ToListAsync();
        return  await result;
    }

    public async Task<CartItem> GetByIdAsync(int id)
    {
        await using var context = new ShopOnlineContext();
        var result = (from cart in context.Carts
            join cartItem in context.CartItems on cart.Id equals cartItem.CartId
            where cart.Id==id
            select new CartItem()
            {
                Id = cartItem.Id,
                Qty = cartItem.Qty,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId
            }).SingleOrDefaultAsync();
        return  await result;
    }

    public async Task<IEnumerable<CartItemDto>> GetCartItemProductsAsync()
    {
        await using var context = new ShopOnlineContext();
        var result = (from cartItem in context.CartItems join product in context.Products on cartItem.ProductId equals product.Id select new CartItemDto()
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            Price = product.Price,
            ProductDesciption = product.Description,
            ProductId = cartItem.ProductId,
            Qty = product.Qty,
            ProductImageURL = product.ImageURL,
            ProductName = product.Name,
            TotalPrice = product.Price*cartItem.Qty
        }).ToListAsync();
        return await result;
    }

    public async Task<IEnumerable<CartItemDto>> GetCartItemProductsByCartIdAsync(int cartId)
    {
        await using var context = new ShopOnlineContext();
        var result = (from cartItem in context.CartItems join product in context.Products on cartItem.ProductId equals product.Id where cartItem.Id==cartId select new CartItemDto()
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            Price = product.Price,
            ProductDesciption = product.Description,
            ProductId = product.Id,
            Qty = product.Qty,
            ProductImageURL = product.ImageURL,
            ProductName = product.Name,
            TotalPrice = product.Price*cartItem.Qty
        }).ToListAsync();
        return await result;
    }
}