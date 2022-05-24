using Core.Utilities.Results;
using Entities;
using Entities.Dtos;

namespace Business.Abstract;

public interface IProductService
{
    Task<IDataResult<IEnumerable<Product>>> GetItems();
    Task<IDataResult<Product>> GetById(int productId);
    Task<IDataResult<IEnumerable<Product>>> GetByCategoryIdAsync(int categoryId);

    Task<IDataResult<IEnumerable<ProductDto>>> GetProductCategoriesAsync();
    Task<IDataResult<IEnumerable<ProductDto>>> GetProductCategoriesByCategoryIdAsync(int categoryId);
    Task<IDataResult<ProductDto>> GetProductCategoriesByProductIdAsync(int productId);
    
    
}