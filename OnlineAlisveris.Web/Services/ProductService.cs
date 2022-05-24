using System.Net.Http.Json;
using Entities.Dtos;
using OnlineAlisveris.Web.Services.Contracts;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services;

public class ProductService : IProductService
{
    private HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductDto()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<DataResult<IEnumerable<ProductDto>>>("api/Products/GetAllProductDto");
            return products.Data;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public async Task<DataResult<ProductDto>> GetAllProductDtoByProductId(int productId)
    {
        var product = await _httpClient.GetFromJsonAsync<DataResult<ProductDto>>($"api/Products/GetAllProductDtoByProductId?productId=1");
        return product;
    }
}