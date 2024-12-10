using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Queries.GetCartById
{
    public class GetCartByIdQueryHandler(ICartRepository _repo , IMapper _mapper) : IRequestHandler<GetCartByIdQuery, CartDto>
    {
        public async Task<CartDto> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _repo.GetAllCartById(request.Id);
            return _mapper.Map<CartDto>(cart);
        }
    }
}
