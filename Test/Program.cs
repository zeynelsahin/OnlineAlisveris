// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using Business.Concrete;
using Business.Extensions;
using DataAccess.Concrete.EntityFramework;
using Entities;

Console.WriteLine("Hello, World!");
Product product = new Product()
{
    CategoryId = 5,Description = "asd",Id = 5
};
var deneme=JsonSerializer.Serialize(product);
Console.WriteLine(deneme);
ProductManager productManager = new ProductManager(new EfProductDal());
ProductCategoryManager productCategoryManager = new ProductCategoryManager(new EfProductCategoryDal());

//Convert join vs join

    var sw = Stopwatch.StartNew();
    var products=await productManager.GetItems();
    var categories = await productCategoryManager.GetAll();
    var dto= products.Data.ConverToDto(categories.Data);
    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds} saniye sürdü");
    var sw1=Stopwatch.StartNew();
    var  dto1=productManager.GetProductCategoriesAsync();
    sw1.Stop();
    Console.WriteLine($"{sw1.ElapsedMilliseconds} saniye sürdü");
    
