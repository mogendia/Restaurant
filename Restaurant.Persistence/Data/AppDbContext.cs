using Restaurant.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Restaurant.Infracture.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Product)
                .HasForeignKey(p => p.CategoryId);

        builder.Entity<Product>()
          .Property(p => p.TotalPrice)
          .HasComputedColumnSql("[Quantity]*[Price]");

        builder.Entity<Cart>()
           .HasOne(c => c.Product)
           .WithMany(p => p.Cart)
           .HasForeignKey(cart => cart.ProductId);

        builder.Entity<Cart>()
            .Property(p=>p.TotalPrice)
            .HasComputedColumnSql("[Quantity]*[Price]");



        base.OnModelCreating(builder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

   
}