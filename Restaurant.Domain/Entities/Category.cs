using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Category : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
