using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQueryHandler(IProductRepository _repo, IMapper _mapper) : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetAllProduct();
            return _mapper.Map<List<ProductDto>>(product);
        }
    }
}
