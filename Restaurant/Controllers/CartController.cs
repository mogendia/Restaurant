using Restaurant.Application.Features.Carts.Commands.CreateCart;
using Restaurant.Application.Features.Carts.Commands.DeleteCart;
using Restaurant.Application.Features.Carts.Commands.UpdateCart;
using Restaurant.Application.Features.Carts.Queries.GetCart;
using Restaurant.Application.Features.Categories.Queries.GetAllCatById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Restaurant.Api.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer", Policy = "EmployeesOnly")]
    public class CartController(IMediator _mediator) : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCarts() { 
            return Ok(await _mediator.Send(new GetAllCartsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery() { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCart([FromRoute] DeleteCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
