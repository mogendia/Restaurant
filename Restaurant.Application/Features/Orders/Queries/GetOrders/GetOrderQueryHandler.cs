using AutoMapper;
using MediatR;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrders;

public class GetOrderQueryHandler(IOrderRepository _repo,IMapper _mapper) : IRequestHandler<GetOrderQuery,List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _repo.GetOrder();
        return _mapper.Map<List<OrderDto>>(order);
    }
}