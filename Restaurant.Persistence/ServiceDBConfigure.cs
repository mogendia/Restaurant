using Restaurant.Domain.Repositories;
using Restaurant.Infracture.Data;
using Restaurant.Infracture.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Entities;


namespace Restaurant.Infracture
{
    public static class ServiceDBConfigure
    {
        public static IServiceCollection AddConfigService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = config["Jwt:Audience"],
                    ValidIssuer = config["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
                };
            });
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 4;
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminsOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EmployeesOnly", policy => policy.RequireClaim("UserType", "Employee"));


            });



            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
