using Microsoft.AspNetCore.Identity;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data;


public static class AppIdentityDbContextSeed
{
    public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Ensure roles are created
        await EnsureRolesAsync(roleManager);

        // Check if any users exist; if not, create a default user
        if (!userManager.Users.Any())
        {
            var user = new User
            {
                Email = "Mohamed@yahoo.com",
                PhoneNumber = "01025213645",
                UserName = "Mohamed",
            };

            var result = await userManager.CreateAsync(user, "Mohamed123.");
            if (result.Succeeded)
            {
                var rolesToAssign = new[] { "SuperAdmin", "Admin", "User" };
                await userManager.AddToRolesAsync(user, rolesToAssign);
            }
        }
    }

    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "SuperAdmin", "Admin", "User" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}