using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Repositories;
using Restaurant.Infracture.Data;

namespace Restaurant.Infracture.Repository;

public class OrderRepository(ApplicationDbContext _context) : IOrderRepository
{
    public async Task<List<Order>> GetOrderById(string userId)
    {
        return await _context.Orders.Where(o=>o.UserId == userId).ToListAsync();
    }public async Task<List<Order>> GetOrder()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return null;
        _context.Remove(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> CreateOrder(int cartId,Order order)
    {
        var cart = await _context.Carts.Include(c=>c.CartItems)
            .ThenInclude(c=>c.Product)
            .FirstOrDefaultAsync(c=>c.Id==cartId);
        if (cart == null) return null;

        var orderItems = cart.CartItems.Select(c => new OrderItem()

        {
            ProductId = c.ProductId,
            Quantity = c.Quantity,
            Price = c.Product.Price,
        }).ToList();
        
        var newOrder = new Order()
        {
            UserId = cart.UserId,
            OrderStatus = OrderStatus.Pending,
            CreatedAt = DateTime.Now,
            TotalAmount = orderItems.Sum(oi=>oi.Quantity * oi.Price),
            OrderItems = orderItems
          
        };

        _context.Orders.Add(newOrder);
        _context.Carts.RemoveRange(cart);
        await _context.SaveChangesAsync();
        return newOrder;
    }
}