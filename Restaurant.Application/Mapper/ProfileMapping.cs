using AutoMapper;
using Restaurant.Application.Features.Carts.Commands.CreateCart;
using Restaurant.Application.Features.Carts.Commands.UpdateCart;
using Restaurant.Application.Features.Categories.Command.UpdateCategory;
using Restaurant.Application.Features.Products.Commands.CreateProduct;
using Restaurant.Application.Features.Products.Commands.UpdateProduct;
using Restaurant.Application.Restaurant.Categories.Command.CreateCategory;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Mapper
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping() 
        {
            // category mapping
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCatCommand>().ReverseMap();
            // product mapping
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<PaginationResult<Product>, PaginationResultDto<ProductDto>>().ReverseMap()
                .ForMember(dest=>dest.Result, option=>option.MapFrom(src=>src.Result))
                .ForMember(dest=>dest.TotalCount, option=>option.MapFrom(src=>src.TotalCount));
            // cart mappping
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Cart, CreateCartCommand>().ReverseMap();
            CreateMap<Cart, UpdateCartCommand>().ReverseMap();

        }
    }
}
