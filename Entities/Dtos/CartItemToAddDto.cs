using Core.Entities;

namespace Entities.Dtos;

public class CartItemToAddDto: IEntity
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
}