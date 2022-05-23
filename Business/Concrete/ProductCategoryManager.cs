using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete;

public class ProductCategoryManager: IProductCategoryService
{
    private IProductCategoryDal _productCategoryDal;

    public ProductCategoryManager(IProductCategoryDal productCategoryDal)
    {
        _productCategoryDal = productCategoryDal;
    }

    public async Task<IDataResult<List<ProductCategory>>> GetAll()
    {
        var categories = await _productCategoryDal.GetAllAsync();
        return new SuccessDataResult<List<ProductCategory>>(categories,Messages.CategoryListed);
    }

    public async Task<IDataResult<ProductCategory>> GetById(int categoryId)
    {
        var category = await _productCategoryDal.GetAsync(productCategory => productCategory.Id == categoryId);
        return new SuccessDataResult<ProductCategory>(category,Messages.CategoryListed);
    }
}