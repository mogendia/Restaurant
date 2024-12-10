using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Command.UpdateCategory
{
    public class UpdateCatCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
