using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Quantity)
            .IsRequired();
        builder.Property(x => x.Price).IsRequired();
        
        builder.HasOne(oi => oi.Order)
            .WithMany(o=>o.OrderItems)
            .HasForeignKey(oi =>oi.OrderId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}