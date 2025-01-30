using MediatR;
using Restaurant.Domain.Models;

namespace Restaurant.Infracture.Repository.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand:IRequest<OrderDto>
{
    public int Id { get; set; }
}