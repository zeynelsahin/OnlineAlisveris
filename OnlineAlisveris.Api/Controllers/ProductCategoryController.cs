using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace OnlineAlisveris.Api.Controllers;

public class ProductCategoryController : Controller
{
    private readonly IProductCategoryService _productCategoryService;
    // GET
    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    
    [NonAction]
    private async Task<IActionResult> Dondur(IResult result)
    {
        if (result.Success) return  Ok(result);
        return BadRequest(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _productCategoryService.GetAll();
        return await Dondur(result);
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productCategoryService.GetById(id);
        return await Dondur(result);
    }
    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        var result = await _productCategoryService.Delete(id);
        return await Dondur(result);
    }
    [HttpGet("Update")]
    public async Task<IActionResult> Update(ProductCategory productCategory)
    {
        var result = await _productCategoryService.GetAll();
        return await Dondur(result);
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(ProductCategory productCategory)
    {
        var result = await _productCategoryService.Add(productCategory);
        return await Dondur(result);
    }
  
}