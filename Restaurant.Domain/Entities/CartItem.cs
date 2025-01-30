using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
