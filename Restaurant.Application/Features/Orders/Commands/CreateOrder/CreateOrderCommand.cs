using MediatR;
using Restaurant.Domain.Models;

namespace Restaurant.Infracture.Repository.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand:IRequest<OrderDto>
{
    public int cartId { get; set; }
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public string OrderStatus { get; set; } = "Pending";
}