using System.Net.Http.Json;
using Entities.Dtos;
using OnlineAlisveris.Web.Services.Contracts;
using OnlineAlisveris.Web.Services.Models;

namespace OnlineAlisveris.Web.Services.Concreate;

public class CartItemService : ICartItemService
{
    private HttpClient _httpClient;

    public CartItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DataResult<IEnumerable<CartItemDto>>> GetAll(int userId)
    {
        DataResult<IEnumerable<CartItemDto>> carts = await _httpClient.GetFromJsonAsync<DataResult<IEnumerable<CartItemDto>>>($"api/CartItem/GetAllByUserId?userId={userId}");
        return carts;
    }

    public async Task<Result> Add(CartItemToAddDto cartItemToAddDto)
    {
        var postAsJsonAsync = await _httpClient.PostAsJsonAsync<CartItemToAddDto>("api/CartItem/Add", cartItemToAddDto);
        var result = await postAsJsonAsync.Content.ReadFromJsonAsync<Result>();
        return  result;
    }

    public async Task<DataResult<List<CartItemDto>>> GetAllByUserId(int userId)
    {
        var response = await _httpClient.GetFromJsonAsync<DataResult<List<CartItemDto>>>($"api/CartItem/GetCartItemProductsByUserId?userId={userId}");
        return response;
    }

    public async Task<Result> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/CartItem/DeleteCartItemById?id={id}");
        var result = await response.Content.ReadFromJsonAsync<Result>();
        return result;
    }

    public async Task<DataResult<CartItemDto>> GetById(int id)
    {
        var response= await _httpClient.GetFromJsonAsync<DataResult<CartItemDto>>($"api/CartItem/GetById?id={id}") ;
        return response;
    }

    public async Task<Result> UpdateQty( CartItemQtyUpdateDto cartItemQtyUpdateDto)
    {
        var httpResponseMessage = await _httpClient.PutAsJsonAsync("api/CartItem/UpdateCartItemQty",cartItemQtyUpdateDto);
        var result = await httpResponseMessage.Content.ReadFromJsonAsync<Result>();
        return result;
    }
}