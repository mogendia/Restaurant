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

namespace Restaurant.Application.Restaurant.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository _repo , IMapper _mapper) : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
           var category = _mapper.Map<Category>(request);
            var cate = await _repo.CreateCategory(category);
            return _mapper.Map<CategoryDto>(cate);
        }
    }
}
