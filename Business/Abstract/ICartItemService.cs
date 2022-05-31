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
    Task<IDataResult<IEnumerable<CartItemDto>>> GetCartItemProductsByUserIdAsync(int userId);

    //
    
    Task<IResult> AddItem(CartItemToAddDto cartItemToAddDto);
    Task<IResult> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto);
    Task<IResult> DeleteItem(int id);
    
   
}