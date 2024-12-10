using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Queries.GetAllCatById
{
    public class GetCatByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
