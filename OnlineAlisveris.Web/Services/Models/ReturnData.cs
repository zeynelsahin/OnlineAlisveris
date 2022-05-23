namespace OnlineAlisveris.Web.Services.Models;

public class ReturnData<T>
{
    public T Data { get; set; }
    public bool Succcess { get; set; }
    public string Message { get; set; }
}