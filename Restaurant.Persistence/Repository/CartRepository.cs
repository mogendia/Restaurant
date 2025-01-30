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
            var exCart = await _context.Carts.Include(c=>c.CartItems)
                .FirstOrDefaultAsync(c=>c.UserId == cart.UserId);

            if (exCart != null)
            {
                foreach (var item in cart.CartItems)
                {
                    var exItem = exCart.CartItems.FirstOrDefault(c=>c.ProductId == item.ProductId);
                    if (exItem != null)
                    {
                        exItem.Quantity += item.Quantity;
                    }
                    else
                    {
                        exCart.CartItems.Add(item);
                    }
                }
                await _context.SaveChangesAsync();
                return exCart;
            }
            else
            {
                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
                return cart;
            }
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
            return await _context.Carts
                .Include(c=>c.CartItems)
                .ThenInclude(p=>p.Product).ToListAsync();
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
            if (cart.Quantity<1)
            {
                return await DeleteCart(cart.Id);
            }
            // edit.Price = cart.Price;
            edit.Quantity = cart.Quantity;
            await _context.SaveChangesAsync();
            return edit;
        }
    }
}
/*
 * public async Task<Cart> CreateCartItem(string userId, int productId, int quantity)
    {
        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            await _context.Carts.AddAsync(cart);
        }

        // تحقق مما إذا كان المنتج موجودًا في السلة
        var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += quantity;
        }
        else
        {
            cart.CartItems.Add(new CartItem
            {
                ProductId = productId,
                Quantity = quantity
            });
        }

        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task<Cart> DeleteCart(int cartId)
    {
        var cart = await _context.Carts.FindAsync(cartId);
        if (cart == null)
            throw new Exception($"CartId not found {cartId}");

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task<List<Cart>> GetAllCarts()
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .ToListAsync();
    }

    public async Task<Cart> GetCartById(int id)
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cart> UpdateCartItem(int cartItemId, int quantity)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem == null)
            throw new Exception($"CartItemId not found {cartItemId}");

        if (quantity < 1)
        {
            _context.CartItems.Remove(cartItem);
        }
        else
        {
            cartItem.Quantity = quantity;
        }

        await _context.SaveChangesAsync();
        return await GetCartById(cartItem.CartId);
    }
 */