﻿namespace Entities.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Desciption { get; set; }
    public string ImageURl { get; set; }
    public decimal Price { get; set; }
    public int Qty { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}