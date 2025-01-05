using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using Restaurant.Domain.Entities;
using Restaurant.Infracture;
using Restaurant.Infracture.Data;
using Restaurant.Infracture.Repository;
using Microsoft.AspNetCore.Identity;

namespace Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddConfigService(builder.Configuration);
            builder.Services.AddServiceConfig();
            builder.Services.AddControllers();
            builder.Services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            
            builder.Services.AddProblemDetails();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options=>options.SwaggerEndpoint("/openapi/v1.json","v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
