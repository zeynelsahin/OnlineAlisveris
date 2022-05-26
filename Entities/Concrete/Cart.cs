using Core.Entities;

namespace Entities;

public class Cart : IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
}