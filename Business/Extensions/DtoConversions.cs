using Entities;
using Entities.Dtos;

namespace Business.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ProductDto> ConverToDto(this IEnumerable<Product> products,IEnumerable<ProductCategory> productCategory)
    {
        return (from product in products join category in productCategory on product.CategoryId equals category.Id select new ProductDto()
        {
            Id= product.Id,
            Name = product.Name,
            Desciption = product.Description,
            CategoryId = product.CategoryId,
            CategoryName = category.Name,
            ImageURl = product.ImageURL,
            Price = product.Price,
            Qty = product.Qty
        });
    }
}