using AutoMapper;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandle(IProductRepository _repo,IMapper _mapper) : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var isDeleted = await _repo.DeleteProduct(request.Id);
          return  _mapper.Map<ProductDto>(isDeleted);
        }
    }
}
