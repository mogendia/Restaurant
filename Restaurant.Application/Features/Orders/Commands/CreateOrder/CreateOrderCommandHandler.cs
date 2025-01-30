using AutoMapper;
using MediatR;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infracture.Repository.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(IOrderRepository _repo,IMapper _mapper):IRequestHandler<CreateOrderCommand,OrderDto>
{
    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);
        var orderList = await _repo.CreateOrder(request.cartId,order);
        return _mapper.Map<OrderDto>(orderList);
    }
}