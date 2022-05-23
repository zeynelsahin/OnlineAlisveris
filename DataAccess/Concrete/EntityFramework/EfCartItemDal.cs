using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete.EntityFramework;

public class EfCartItemDal: EfEntityRepositoryBase<CartItem,ShopOnlineContext>, ICartItemDal
{
    
}