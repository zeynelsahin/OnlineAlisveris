using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities;

namespace DataAccess.Abstract;

public interface ICartItemDal: IEntityRepository<CartItem>
{
    
}