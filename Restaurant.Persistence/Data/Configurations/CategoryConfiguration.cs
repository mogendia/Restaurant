using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.Property(x => x.Name)
               .HasColumnType("VARCHAR")
               .HasMaxLength(50)
               .IsRequired();
       
    }
}