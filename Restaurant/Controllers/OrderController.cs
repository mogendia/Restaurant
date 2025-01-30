using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Models;
using Restaurant.Infracture.Repository.Features.Orders.Commands.CreateOrder;
using Restaurant.Infracture.Repository.Features.Orders.Commands.DeleteOrder;
using Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrders;
using Restaurant.Infracture.Repository.Features.Orders.Queries.GetOrdersByUserId;

namespace Restaurant.Api.Controllers;
[Authorize(AuthenticationSchemes ="Bearer", Policy = "EmployeesOnly")]

public class OrderController(IMediator _mediator) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _mediator.Send(new GetOrderQuery()));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrdersById(string userId)
    {
        return Ok(await _mediator.Send(new GetOrderByUserIdQuery(){UserId = userId}));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(DeleteOrderCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}