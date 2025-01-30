using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasOne<Category>()
          .WithMany()
          .HasForeignKey(f => f.CategoryId)
          .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasKey(c=>c.Id);
        builder.Property(x => x.Name)
               .HasColumnType("VARCHAR")
               .HasMaxLength(100)
               .IsRequired();
        builder.Property(x => x.Description)
               .HasColumnType("VARCHAR")
               .HasMaxLength(1500)
               .IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        //builder.Property(x => x.TotalPrice).IsRequired();
        ////builder.Property(p => p.TotalPrice)
        ////    .HasComputedColumnSql("[Quantity]*[Price]");
        //builder.Ignore(x=>x.TotalPrice);
    }
}