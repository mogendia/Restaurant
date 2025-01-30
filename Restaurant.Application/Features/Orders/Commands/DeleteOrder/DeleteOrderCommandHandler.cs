using AutoMapper;
using MediatR;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;

namespace Restaurant.Infracture.Repository.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IOrderRepository _repo,IMapper _mapper):IRequestHandler<DeleteOrderCommand,OrderDto>
{
    public async Task<OrderDto> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _repo.DeleteOrder(request.Id);
        return _mapper.Map<OrderDto>(order);
    }
}