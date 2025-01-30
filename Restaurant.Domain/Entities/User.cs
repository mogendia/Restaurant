using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities;

public class User : IdentityUser
{
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Cart> Carts { get; set; } = new List<Cart>();
}
