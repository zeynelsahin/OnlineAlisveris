using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task<IDataResult<IEnumerable<Product>>> GetItems()
    {
        var products = await _productDal.GetAllAsync();
        return new SuccessDataResult<IEnumerable<Product>>(products, Messages.ProductsListed);
    }

    public async Task<IDataResult<Product>> GetById(int productId)
    {
        var product = await _productDal.GetAsync(product => product.Id == productId);
        return new SuccessDataResult<Product>(product, Messages.ProductListed);
    }

    public async Task<IDataResult<IEnumerable<Product>>> GetByCategoryIdAsync(int categoryId)
    {
        var products = await _productDal.GetAllAsync(product => product.CategoryId == categoryId);
        return new SuccessDataResult<IEnumerable<Product>>(products);
    }

    public async Task<IDataResult<IEnumerable<ProductDto>>> GetProductCategoriesAsync()
    {
        var products = await _productDal.GetProductCategoriesAsync();
        return new SuccessDataResult<IEnumerable<ProductDto>>(products,Messages.ProductsListed);
    }

    public async Task<IDataResult<IEnumerable<ProductDto>>> GetProductCategoriesByCategoryIdIdAsync(int categoryId)
    {
        var products = await _productDal.GetProductCategoriesByCategoryIdAsync(categoryId);
        return new SuccessDataResult<IEnumerable<ProductDto>>(products, Messages.ProductsListed);
    }
}