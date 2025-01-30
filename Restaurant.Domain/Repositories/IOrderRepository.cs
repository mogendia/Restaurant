using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrderById(string userId);
        Task<List<Order>> GetOrder();
        Task<Order> DeleteOrder(int id);
        Task<Order> CreateOrder(int cartId ,Order order);
    }
}
