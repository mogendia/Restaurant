using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Commands.CreateCart
{
    public class CreateCartCommandHandler(ICartRepository _repo,IMapper _mapper) : IRequestHandler<CreateCartCommand, CartDto>
    {
        public async Task<CartDto> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
           var cart = _mapper.Map<Cart>(request);
            var cartList = await _repo.CreateCart(cart);
            return _mapper.Map<CartDto>(cartList);
        }
    }
}
