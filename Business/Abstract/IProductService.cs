using Entities;

namespace Business.Abstract;

public interface IProductService
{
    Task<IEnumerable<Product>> GetItems();
    Task<IEnumerable<ProductCategory>> GetCategories();
    Task<Product> GetItem(int id);
    Task<ProductCategory> GetCatetegory(int id);
}