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
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired();
        builder.Property(p => p.TotalPrice)
            .HasComputedColumnSql("[Quantity]*[Price]");

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(f=>f.ProductId).OnDelete(DeleteBehavior.NoAction); 

    }
}