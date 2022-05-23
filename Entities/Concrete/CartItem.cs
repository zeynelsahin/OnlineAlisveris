using Core.Entities;

namespace Entities;

public class CartItem: IEntity
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
}