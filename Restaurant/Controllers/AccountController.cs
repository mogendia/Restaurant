﻿using Restaurant.Domain.Entities;
using Restaurant.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IConfiguration _config,UserManager<User> _user): ControllerBase
    {
        private string GenerateToken(User user)
        {
            var userClaims = new List<Claim>
                    {
                        new (JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new (ClaimTypes.NameIdentifier,user.Id),
                        new (ClaimTypes.Name,user.UserName),
                        new (ClaimTypes.Role,"Admin"),
                        new ("UserType","Employee")

                    };
            

            var smKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signCred = new SigningCredentials(smKey, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken
                (
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: signCred,
                    claims: userClaims
                );
            return new JwtSecurityTokenHandler().WriteToken(myToken);

        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           
            var user = new User()
            {
                UserName = dto.Name,
                Email = dto.Email,                
            };
            var result = await _user.CreateAsync(user, dto.Password);
            if (result.Succeeded) return Ok(result);
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("Password", item.Description);
            }
            return BadRequest(ModelState);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _user.FindByNameAsync(dto.Name);

            if (user != null && await _user.CheckPasswordAsync(user, dto.Password))
            {
                    var token = GenerateToken(user);
                    
                    var refreshToken = GenerateRefreshToken();

                    user.RefreshTokens.Add(new RefreshToken
                    {
                        Token = refreshToken,
                        Expiration=DateTime.Now.AddDays(8),
                        UserId = user.Id
                    });
                    await _user.UpdateAsync(user);

                    return Ok(new
                    {
                        myToken = token,
                        RefreshToken = refreshToken,
                        expiresIn = DateTime.Now.AddHours(5),
                    });
            }

            ModelState.AddModelError("UserName", "UserName or Password Not Valid");
            return BadRequest(ModelState);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {
            var user = await _user.Users.Include(x => x.RefreshTokens)
                .FirstOrDefaultAsync(y => y.RefreshTokens.Any(z => z.Token == token));

            if (user == null || !user.RefreshTokens.Any(rt => rt.Token == token))
            {
                return Unauthorized();
            }

            var refreshToken = user.RefreshTokens.First(rt => rt.Token == token);
            if (refreshToken.Expiration <= DateTime.UtcNow)
            {
                return Unauthorized();
            }

            // Generate new token and refresh token
            var newToken = GenerateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            refreshToken.Token = newRefreshToken;
            refreshToken.Expiration = DateTime.UtcNow.AddDays(7);

            await _user.UpdateAsync(user);

            return Ok(new
            {
                token = newToken,
                refreshToken = newRefreshToken,
                expiresIn = DateTime.Now.AddHours(2),
            });
        }
    }
}