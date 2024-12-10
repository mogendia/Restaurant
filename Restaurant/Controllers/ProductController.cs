using Restaurant.Application.Features.Products.Commands.CreateProduct;
using Restaurant.Application.Features.Products.Commands.DeleteProduct;
using Restaurant.Application.Features.Products.Commands.UpdateProduct;
using Restaurant.Application.Features.Products.Queries.GetProducts;
using Restaurant.Application.Features.Products.Queries.GetProductsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer",Policy = "EmployeesOnly")]

    public class ProductController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery() { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
      
        [HttpPut]

        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteProduct( [FromRoute] DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
      

      
    }
}
