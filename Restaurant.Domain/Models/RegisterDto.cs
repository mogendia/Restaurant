using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passowrd Is Required")]
        public string Password { get; set; }
    }
}
