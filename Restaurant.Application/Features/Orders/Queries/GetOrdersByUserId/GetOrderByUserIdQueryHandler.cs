using AutoMapper;
using MediatR;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrderByUserIdQueryHandler(IOrderRepository _repo, IMapper _mapper):IRequestHandler<GetOrderByUserIdQuery, List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(GetOrderByUserIdQuery request, CancellationToken cancellationToken)
    {
        var order =await _repo.GetOrderById(request.UserId);
        return _mapper.Map<List<OrderDto>>(order);
    }
}