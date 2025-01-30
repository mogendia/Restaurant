namespace Restaurant.Domain.Entities;

public class Order : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string UserId { get; set; }
    public virtual User Users { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}