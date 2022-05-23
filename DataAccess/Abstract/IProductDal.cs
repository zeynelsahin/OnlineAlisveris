using Core.DataAccess;
using Entities;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IProductDal: IEntityRepository<Product>
{
   Task<List<ProductDto>> GetProductCategoriesAsync();
   Task<List<ProductDto>> GetProductCategoriesByCategoryIdAsync(int categoryId);
}