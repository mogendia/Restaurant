using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.Property(x => x.Quantity).IsRequired();
        // builder.Property(x => x.Price).IsRequired();
        // builder.Property(x => x.TotalPrice).IsRequired();
        // builder.Property(p => p.TotalPrice)
        //     .HasComputedColumnSql("[Quantity]*[Price]");

        builder.HasMany<Product>()
            .WithOne()
            .HasForeignKey(f=>f.CartId)
            .OnDelete(DeleteBehavior.Restrict); 
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x=>x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.CartItems)
            .WithOne(c => c.Cart)
            .HasForeignKey(c => c.CartId);

    }
}