using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Queries.GetAll
{
    public class GetAllQuery : IRequest<List<CategoryDto>>
    {
      
    }
    
}
