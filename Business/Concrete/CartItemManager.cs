using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;

namespace Business.Concrete;

public class CartItemManager : ICartItemService
{
    public Task<IDataResult<CartItem>> GetById()
    {
        return null;
    }

    public Task<IDataResult<List<CartItem>>> GetByUserId(int userId)
    {
        return null;
    }

    public Task<IResult> AddItem(CartItemToAddDto cartItemToAddDto)
    {
        return null;
    }

    public Task<IResult> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
        return null;
    }

    public Task<IResult> DeleteItem(int id)
    {
        return null;
    }
}