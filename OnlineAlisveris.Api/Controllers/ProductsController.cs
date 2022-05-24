using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace OnlineAlisveris.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
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
        return  product;
    }
}