using Core.DataAccess;
using Entities;
using Entities.Dtos;

namespace DataAccess.Abstract;

public interface IProductDal: IEntityRepository<Product>
{
   Task<IEnumerable<ProductDto>> GetProductCategoriesAsync();
   Task<IEnumerable<ProductDto>> GetProductCategoriesByCategoryIdAsync(int categoryId);
   Task<ProductDto> GetProductCategoriesByProductIdAsync(int productId);
}