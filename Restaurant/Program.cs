using IdentityRole = Microsoft.AspNetCore.Identity.IdentityRole;
using Restaurant.Domain.Entities;
using Restaurant.Infracture;
using Restaurant.Infracture.Data;
using Restaurant.Infracture.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            
            
            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                try
                {
                     //dbContext.Database.MigrateAsync();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    AppIdentityDbContextSeed.SeedUserAsync(userManager, roleManager);
                    AppIdentityDbContextSeed.EnsureRolesAsync(roleManager);
                }
                catch (Exception ex)
                {
                    var logger = app.Services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred during migration seeding.");
                    Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
                }
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
