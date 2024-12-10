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

namespace Restaurant.Application.Features.Carts.Commands.UpdateCart
{
    public class UpdateCartCommandHanlder(ICartRepository _repo,IMapper _mapper) : IRequestHandler<UpdateCartCommand, CartDto>
    {
        public async Task<CartDto> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
           var cart = _mapper.Map<Cart>(request);
            var cartList = await _repo.UpdateCart(cart);
            return _mapper.Map<CartDto>(cartList);
        }
    }
}
