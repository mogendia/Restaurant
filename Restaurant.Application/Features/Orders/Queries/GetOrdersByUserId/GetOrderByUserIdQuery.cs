using MediatR;
using Restaurant.Domain.Models;

namespace Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrderByUserIdQuery:IRequest<List<OrderDto>>
{
    public string UserId { get; set; }
}