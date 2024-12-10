using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Queries.GetCart
{
    public class GetAllCartsQueryHandler(ICartRepository repo, IMapper mapper) : IRequestHandler<GetAllCartsQuery, List<CartDto>>
    {
        public async Task<List<CartDto>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
        {
            var cart = await repo.GetAllCart();
            return mapper.Map<List<CartDto>>(cart);
        }
    }
}
