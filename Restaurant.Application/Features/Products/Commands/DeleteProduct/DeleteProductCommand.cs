﻿using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
