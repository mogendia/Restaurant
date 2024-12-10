using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Commands.DeleteCart
{
    public class DeleteCartCommandHandler(ICartRepository _cart , IMapper _mapper) : IRequestHandler<DeleteCartCommand, CartDto>
    {
        public async Task<CartDto> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cart.DeleteCart(request.Id);
            return _mapper.Map<CartDto>(cart);
        }
    }
}
