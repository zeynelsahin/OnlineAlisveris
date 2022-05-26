namespace OnlineAlisveris.Web.Services.Models;

public class DataResult<T>: Result
{
    public T Data { get; set; }

}