using System.Net.Http.Json;
using Entities.Dtos;
using OnlineAlisveris.Web.Services.Contracts;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services;

public class CartService: ICartService
{
    private HttpClient _httpClient;
    
    public async Task<DataResult<IEnumerable<CartItemDto>>> GetAll(int userId)
    {
        DataResult<IEnumerable<CartItemDto>> carts = await _httpClient.GetFromJsonAsync<DataResult<IEnumerable<CartItemDto>>>($"api/CartItem/GetAllByUserId?userId={userId}");
        return carts;
    }

    public async Task<Result> Add(CartItemToAddDto cartItemToAddDto)
    {
        var  add = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/CartItem/Add",cartItemToAddDto);
        var result = await add.Content.ReadFromJsonAsync<Result>();
        return result;
    }
}