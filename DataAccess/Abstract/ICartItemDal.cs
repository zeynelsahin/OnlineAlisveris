using Core.DataAccess;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface ICartItemDal: IEntityRepository<CartItem>
{

    Task<IEnumerable<CartItem>> GetAllByUserIdAsync(int userId);
    Task<CartItem> GetByIdAsync(int id);
    Task<IEnumerable<CartItemDto>> GetCartItemProductsAsync();
    Task<IEnumerable<CartItemDto>> GetCartItemProductsByCartIdAsync(int cartId);
    Task<IEnumerable<CartItemDto>> GetCartItemProductByUserIdAsync(int userId);
}