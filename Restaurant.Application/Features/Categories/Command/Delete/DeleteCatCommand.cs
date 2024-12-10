using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Categories.Command.Delete
{
    public class DeleteCatCommand:IRequest<CategoryDto>
    {
        public int Id { get; set; }
        
    }
}
