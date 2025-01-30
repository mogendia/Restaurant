using System.ComponentModel.DataAnnotations;
namespace Restaurant.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int CartId { get; set; }
        public virtual Category Categories { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];
        public ICollection<CartItem> CartItems { get; set; } = [];
        // public Cart Carts { get; set; }


        //public decimal  => Quantity * Price;


    }
}
