using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Core.Utilities.Results;
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

    public async Task<List<ProductDto>> GetAllProductDto()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<ReturnData<List<ProductDto>>>("api/Products/GetAllProductDto");
            return products.Data;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}