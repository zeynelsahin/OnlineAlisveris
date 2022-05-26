using Core.Utilities.Results;
using Entities;
using Entities.Dtos;

namespace Business.Abstract;

public interface ICartItemService
{
    // Task<IDataResult<CartItem>> GetAll();
    //join
    Task<IDataResult<CartItem>> GetByIdAsync(int id);
    Task<IDataResult<IEnumerable<CartItem>>> GetAllByUserIdAsync(int userId);
    Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsAsync();
    Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsByCartIdAsync(int cartId);

    //
    
    Task<IResult> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<IResult> UpdateQty(int id , CartItemQtyUpdateDto cartItemQtyUpdateDto);
    Task<IResult> DeleteItem(int id);
    
   
}