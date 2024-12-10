using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Products.Queries.GetProductsById
{
    public class GetProductByIdQuery:IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
