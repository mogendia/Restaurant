using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Queries.GetAllCatById
{
    public class GetCatByIdQueryHandler(ICategoryRepository _repo,IMapper _mapper) : IRequestHandler<GetCatByIdQuery, CategoryDto>
    {
        public async Task<CategoryDto> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repo.GetAllCategoriesById(request.Id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
