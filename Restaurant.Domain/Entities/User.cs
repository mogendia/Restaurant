﻿using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.Entities;

public class User : IdentityUser
{
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
