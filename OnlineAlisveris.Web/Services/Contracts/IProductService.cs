using Core.Utilities.Results;
using Entities.Dtos;

namespace OnlineAlisveris.Web.Services.Contracts;

public interface IProductService
{
    Task<List<ProductDto>> GetAllProductDto();
}