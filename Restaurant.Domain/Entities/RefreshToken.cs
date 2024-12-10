using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class RefreshToken
    {
        [Key]
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
    }
}
