using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int Quantity { get; set; }
        public string UserId { get; set; }
      
        public User Users { get; set; }
        public ICollection< CartItem> CartItems { get; set; }
        // public decimal Price { get; set; }
        // public decimal TotalPrice { get; set; }
        // public ICollection< Product> Product { get; set; }
        // public int ProductId { get; set; }
        
    }
}
