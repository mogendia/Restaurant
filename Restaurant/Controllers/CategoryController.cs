using Restaurant.Application.Restaurant.Categories.Command.CreateCategory;
using Restaurant.Application.Features.Categories.Command.Delete;
using Restaurant.Application.Features.Categories.Command.UpdateCategory;
using Restaurant.Application.Features.Categories.Queries.GetAll;
using Restaurant.Application.Features.Categories.Queries.GetAllCatById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Restaurant.Api.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer",Policy = "AdminsOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCategories(int id)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery() { Id=id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCatCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCatCommand command)
        {
            await _mediator.Send(command);
            return Ok(_mediator.Send(GetAllCategories()));
        }
        
    }
}
