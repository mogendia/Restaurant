using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Command.UpdateCategory
{
    internal class UpdateCatCommandHandler(ICategoryRepository _cat,IMapper _mapper) : IRequestHandler<UpdateCatCommand, CategoryDto>
    {
        public async Task<CategoryDto> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
        {
            var edit = _mapper.Map<Category>(request);
            var update = await _cat.UpdateCategory(edit);
            return _mapper.Map<CategoryDto>(update);
        }
    }
}
