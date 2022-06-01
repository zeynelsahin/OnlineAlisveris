

using System.Net.Http.Json;
using Core.Utilities.Results;
using Entities;
using OnlineAlisveris.Web.Services.Abstract;

namespace OnlineAlisveris.Web.Services.Concreate;

public class ProductCategoryService: IProductCategoryService
{
    private HttpClient _httpClient;

    public ProductCategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DataResult<IEnumerable<ProductCategory>>> GetAll()
    {
        var result = await _httpClient.GetFromJsonAsync<DataResult<IEnumerable<ProductCategory>>>("api/ProductCategories/GetAll");
        return result;
    }

    public Task<DataResult<ProductCategory>> GetById(int productId)
    {
        return null;
    }
}