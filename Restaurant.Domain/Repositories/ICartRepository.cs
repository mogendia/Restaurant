﻿using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetAllCart();
        Task<Cart> GetAllCartById(int id);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> DeleteCart(int id);
        Task<Cart> CreateCart(Cart cart);
        
        /*
         *  Task<Cart> CreateCartItem(string userId, int productId, int quantity);
        Task<Cart> DeleteCart(int cartId);
        Task<List<Cart>> GetAllCarts();
        Task<Cart> GetCartById(int id);
        Task<Cart> UpdateCartItem(int cartItemId, int quantity);
         
         */
    }
}
