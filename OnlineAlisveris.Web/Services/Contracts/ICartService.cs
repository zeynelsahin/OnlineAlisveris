using Entities.Dtos;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services.Contracts;

public interface ICartService
{
    Task<DataResult<IEnumerable<CartItemDto>>> GetAll(int userId);
    Task<Result> Add(CartItemToAddDto cartItemToAddDto);
}