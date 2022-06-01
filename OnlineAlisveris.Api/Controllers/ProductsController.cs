using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace OnlineAlisveris.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly IProductService _productService;

    [NonAction]
    public async Task<IActionResult> Dondur(IResult result)
    {
        if (result.Success) return Ok(result);
        return BadRequest(result);
    }

    [NonAction]
    public async Task<IActionResult> Dondur(List<IResult> result)
    {
        if (result[0].Success) return Ok(result);
        return BadRequest(result);
    }

    public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
    {
        _productService = productService;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET
    [HttpGet("GetAll")]
    public async Task<IDataResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _productService.GetItems();
        return products;
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<Product>> GetById(int id)
    {
        var products = await _productService.GetById(id);
        return products;
    }

    [HttpGet("GetAllProductDto")]
    public async Task<IDataResult<IEnumerable<ProductDto>>> GetProductDto()
    {
        var products = await _productService.GetProductCategoriesAsync();
        return products;
    }

    [HttpGet("GetAllProductByCategoyId")]
    public async Task<IDataResult<IEnumerable<Product>>> GetProductByCategoryId(int categoryId)
    {
        var products = await _productService.GetByCategoryIdAsync(categoryId);
        return products;
    }

    [HttpGet("GetAllProductDtoByCategoyId")]
    public async Task<IDataResult<IEnumerable<ProductDto>>> GetProductDtoByCategoryId(int categoryId)
    {
        var products = await _productService.GetProductCategoriesByCategoryIdAsync(categoryId);
        return products;
    }

    [HttpGet("GetAllProductDtoByProductId")]
    public async Task<IDataResult<ProductDto>> GetProductDtoByProductId(int productId)
    {
        var product = await _productService.GetProductCategoriesByProductIdAsync(productId);
        return product;
    }


    [HttpPost("AddImage")]
    public async Task<IDataResult<List<string>>> AddImage(List<IFormFile> files)
    {
        var result = new List<string>();
        if (files.Count <= 0)
        {
            return new ErrorDataResult<List<string>>(Messages.FileNotAdded);
        }

        string directorPath = Path.Combine(_webHostEnvironment.ContentRootPath.Split("OnlineAlisveris.Api")[0], "OnlineAlisveris.Web", "wwwroot", "Images", "Kategorisiz");
        foreach (var formFile in files)
        {
            // result.Data.Add(formFile.FileName);
            var filePath = Path.Combine(directorPath, formFile.FileName);
            var stream = new FileStream(filePath, FileMode.Create);
            formFile.CopyToAsync(stream);
            result.Add(formFile.FileName);
        }

        return new SuccessDataResult<List<string>>(result);
    }
}