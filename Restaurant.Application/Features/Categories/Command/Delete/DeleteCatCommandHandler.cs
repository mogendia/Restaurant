using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;


namespace Restaurant.Application.Features.Categories.Command.Delete
{
    public class DeleteCatCommandHandler(ICategoryRepository _cat,IMapper _mapper) : IRequestHandler<DeleteCatCommand, CategoryDto>
    {
        public async Task<CategoryDto> Handle(DeleteCatCommand request, CancellationToken cancellationToken)
        {
           var isDeleted = await _cat.DeleteCategory(request.Id);
            return _mapper.Map<CategoryDto>(isDeleted);
        }
    }
}
