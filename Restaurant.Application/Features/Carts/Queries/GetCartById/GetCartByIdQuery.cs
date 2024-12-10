using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Queries.GetCartById
{
    public class GetCartByIdQuery:IRequest<CartDto>
    {
        public int Id { get; set; }
    }
}
