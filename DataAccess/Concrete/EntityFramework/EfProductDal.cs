using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, ShopOnlineContext>, IProductDal
{
    public async Task<IEnumerable<ProductDto>> GetProductCategoriesAsync()
    {
        await using var context = new ShopOnlineContext();
        var result = (from product in context.Products
            join category in context.ProductCategories on product.CategoryId equals category.Id
            select new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Desciption = product.Description,
                ImageURl = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = category.Name
            }).ToListAsync();
        return await result;
    }

    public async Task<IEnumerable<ProductDto>> GetProductCategoriesByCategoryIdAsync(int categoryId)
    {
        await using var context = new ShopOnlineContext();
        var result = (from product in context.Products
            join category in context.ProductCategories on product.CategoryId equals category.Id where product.CategoryId==categoryId
            select new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Desciption = product.Description,
                ImageURl = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = category.Name
            }).ToListAsync();
        return await result;
    }

    public async Task<ProductDto> GetProductCategoriesByProductIdAsync(int productId)
    {
        await using var context = new ShopOnlineContext();
        var result = (from product in context.Products
            join category in context.ProductCategories on product.CategoryId equals category.Id where product.Id==productId
            select new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Desciption = product.Description,
                ImageURl = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = category.Name,
            }).SingleOrDefaultAsync();
        return await result;
    }
}