using System.Runtime.CompilerServices;

using Entities;
using Entities.Dtos;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services.Contracts;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductDto();
    Task<DataResult<ProductDto>> GetAllProductDtoByProductId(int productId);
}