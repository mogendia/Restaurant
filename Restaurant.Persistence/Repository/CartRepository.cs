using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infracture.Data;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infracture.Repository
{
    public class CartRepository(ApplicationDbContext _context) : ICartRepository
    {
        public async Task<Cart> CreateCart(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> DeleteCart(int id)
        {
            var isDelete =await _context.Carts.FindAsync(id);
            if (isDelete == null)
                throw new Exception($"CartId not found {id}");
            _context.Carts.Remove(isDelete);
            await _context.SaveChangesAsync();
            return isDelete;
        }

        public async Task<List<Cart>> GetAllCart()
        {
            return await _context.Carts.ToListAsync();
        }

        public async Task<Cart> GetAllCartById(int id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
           var edit = await _context.Carts.FindAsync(cart.Id);
            if (edit == null)
                throw new Exception($"CartId not found {cart.Id}");
            edit.Price = cart.Price;
            edit.Quantity = cart.Quantity;
            edit.ProductId = cart.ProductId;
            await _context.SaveChangesAsync();
            return edit;
        }
    }
}
