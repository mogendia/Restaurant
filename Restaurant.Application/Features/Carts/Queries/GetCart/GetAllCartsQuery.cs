﻿using Restaurant.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Carts.Queries.GetCart
{
    public class GetAllCartsQuery:IRequest<List<CartDto>>
    {
    }
}
