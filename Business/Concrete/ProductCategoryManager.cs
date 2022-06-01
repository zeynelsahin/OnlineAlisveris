using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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

    public async Task<IDataResult<IEnumerable<ProductCategory>>> GetAll()
    {
        var categories = await _productCategoryDal.GetAllAsync();
        return new SuccessDataResult<IEnumerable<ProductCategory>>(categories,Messages.CategoryListed);
    }

    public async Task<IDataResult<ProductCategory>> GetById(int categoryId)
    {
        var category = await _productCategoryDal.GetAsync(productCategory => productCategory.Id == categoryId);
        return new SuccessDataResult<ProductCategory>(category,Messages.CategoryListed);
    }

    public async Task<IResult> Delete(int id)
    {
        var result= await BusinessRules.Run(await CheckIfCategoryExists(id));
        if (result.Success!=true)
        {
            return result;
        }

        var deletedEntity = await _productCategoryDal.GetAsync(category => category.Id == id);
        _productCategoryDal.DeleteAsync(deletedEntity);
        return new SuccessResult(Messages.CategoryDeleted);
    }

    public async Task<IResult> Add(ProductCategory productCategory)
    {
        productCategory.Id = null;
         _productCategoryDal.AddAsync(productCategory);
        return new SuccessResult(Messages.CategoryAdded);
    }

    public async Task<IResult> Update(ProductCategory productCategory)
    {
        var result= await BusinessRules.Run(await CheckIfCategoryExists(productCategory.Id));
        if (result.Success!=true)
        {
            return result;
        }
        _productCategoryDal.UpdateAsync(productCategory);
        return new SuccessResult(Messages.CategoryAdded);
    }

    private async Task<IResult> CheckIfCategoryExists(int? id)
    {
        var item = await _productCategoryDal.GetAsync(pc => pc.Id == id);
        if (item==null)
        {
            return new ErrorResult(Messages.CategoryNotFound);
        }

        return new  SuccessResult();
    }
}