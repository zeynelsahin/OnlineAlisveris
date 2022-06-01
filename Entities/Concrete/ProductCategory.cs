using Core.Entities;

namespace Entities;

public class ProductCategory: IEntity
{
    public int? Id { get; set; }
    public string Name { get; set; }
    
    public string IconCSS { get; set; }
}