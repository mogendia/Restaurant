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

namespace Restaurant.Application.Features.Categories.Queries.GetAll
{
    public class GetAllQueryHandler(ICategoryRepository _cat, IMapper _mapper) : IRequestHandler<GetAllQuery, List<CategoryDto>>
    {
        async Task<List<CategoryDto>> IRequestHandler<GetAllQuery, List<CategoryDto>>.Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
           var get = await _cat.GetAllCategories();
            return _mapper.Map<List<CategoryDto>>(get);
        }
    }
}
