using Core.Utilities.Results;
using Entities;

namespace Business.Abstract;

public interface IProductCategoryService
{
    Task<IDataResult<List<ProductCategory>>> GetAll();
    Task<IDataResult<ProductCategory>> GetById(int categoryId);
}