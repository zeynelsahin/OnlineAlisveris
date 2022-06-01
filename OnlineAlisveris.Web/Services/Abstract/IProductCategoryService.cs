using Core.Utilities.Results;
using Entities;

namespace OnlineAlisveris.Web.Services.Abstract;

public interface IProductCategoryService
{
    Task<DataResult<IEnumerable<ProductCategory>>?> GetAll();
    Task<DataResult<ProductCategory>> GetById(int productId);
}