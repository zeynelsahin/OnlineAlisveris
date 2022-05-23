using Core.Utilities.Results;
using Entities;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICartItemService
{
    Task<IDataResult<CartItem>> GetById();
    Task<IDataResult<List<CartItem>>> GetByUserId(int userId);
    
    Task<IResult> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<IResult> UpdateQty(int id , CartItemQtyUpdateDto cartItemQtyUpdateDto);
    Task<IResult> DeleteItem(int id);
}