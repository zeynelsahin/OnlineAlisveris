namespace OnlineAlisveris.Web.Services.Models;

public class DataResult<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } 
}