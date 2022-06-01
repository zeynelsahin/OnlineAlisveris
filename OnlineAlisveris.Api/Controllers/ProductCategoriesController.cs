using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace OnlineAlisveris.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoriesController : Controller
{
    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    [HttpGet("GetAll")]
    public async Task<IDataResult<IEnumerable<ProductCategory>>> GetAll()
    {
        var categories = await _productCategoryService.GetAll();
        return categories;
    }

    [HttpGet("GetById")]
    public async Task<IDataResult<ProductCategory>> GetById(int id)
    {
        var category = await _productCategoryService.GetById(id);
        return category;
    }
}