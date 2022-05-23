using Entities.Dtos;
using Microsoft.AspNetCore.Components;

namespace OnlineAlisveris.Web.Pages;

public class DisplayProductBase: ComponentBase
{
    [Parameter]  
    public IEnumerable<ProductDto> Products { get; set; }
    
}