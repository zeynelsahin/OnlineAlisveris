using Business.Abstract;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete;

public class ProductManager: IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public Task<IEnumerable<Product>> GetItems()
    {
        return Task.FromResult<IEnumerable<Product>>(_productDal.GetAll());
    }

    public Task<IEnumerable<ProductCategory>> GetCategories()
    {
        return null;
    }

    public Task<Product> GetItem(int id)
    {
        return null;
    }

    public Task<ProductCategory> GetCatetegory(int id)
    {
        return null;
    }
}