using MediatR;
using Restaurant.Domain.Models;

namespace Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrders;

public class GetOrderQuery : IRequest<List<OrderDto>>
{
    
}