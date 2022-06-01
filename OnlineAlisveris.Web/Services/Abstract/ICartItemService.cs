using Entities;
using Entities.Dtos;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services.Contracts;

public interface ICartItemService
{
    Task<DataResult<IEnumerable<CartItemDto>>> GetAll(int userId);
    Task<Result> Add(CartItemToAddDto cartItemToAddDto);
    Task<DataResult<List<CartItemDto>>> GetAllByUserId(int userId);
    Task<Result> Delete(int id);

    Task<DataResult<CartItemDto>> GetById(int id); 
    Task<Result> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto);
}