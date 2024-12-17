using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQueryHandler(IProductRepository _repo, IMapper _mapper) : IRequestHandler<GetAllProductsQuery, PaginationResultDto<ProductDto>>
    {
        public async Task<PaginationResultDto<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetAllProduct(request.Pagination);
            var productMapeper = _mapper.Map<List<ProductDto>>(product.Result);
            return new PaginationResultDto<ProductDto>
            {
                Result = productMapeper,
                TotalCount = product.TotalCount
            };
        }
    }
}
