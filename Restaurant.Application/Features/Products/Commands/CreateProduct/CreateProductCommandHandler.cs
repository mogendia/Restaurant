﻿using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using Restaurant.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository _repo, IMapper _mapper) : IRequestHandler<CreateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var productCreated = await _repo.CreateProduct(product);
            return _mapper.Map<ProductDto>(productCreated);
        }
    }
}