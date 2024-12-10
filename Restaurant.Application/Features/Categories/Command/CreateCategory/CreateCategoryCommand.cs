using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using MediatR;

namespace Restaurant.Application.Restaurant.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }  
    }
}
