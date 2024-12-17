using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQuery:IRequest<PaginationResultDto<ProductDto>>
    {
        public PaginationParameters Pagination { get; set; }
    }
}
