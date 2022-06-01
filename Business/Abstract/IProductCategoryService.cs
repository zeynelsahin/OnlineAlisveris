using Core.Utilities.Results;
using Entities;

namespace Business.Abstract;

public interface IProductCategoryService
{
    Task<IDataResult<IEnumerable<ProductCategory>>> GetAll();
    Task<IDataResult<ProductCategory>> GetById(int categoryId);
    Task<IResult> Delete(int id);
    Task<IResult> Add(ProductCategory productCategory);
    Task<IResult> Update(ProductCategory productCategory);
}