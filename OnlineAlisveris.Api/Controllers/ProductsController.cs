using Microsoft.AspNetCore.Mvc;

namespace OnlineAlisveris.Api.Controllers;

[Route("/api/[contoller]")]
[ApiController]
public class ProductsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return null;
    }
   
}