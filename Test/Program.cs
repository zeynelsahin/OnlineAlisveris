// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Entities;

Console.WriteLine("Hello, World!");
Product product = new Product()
{
    CategoryId = 5,Description = "asd",Id = 5
};
var deneme=JsonSerializer.Serialize(product);
Console.WriteLine(deneme);
