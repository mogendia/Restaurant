using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infracture.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c=>c.Id);
        builder.Property(x => x.OrderStatus)
            .HasConversion(orderStatus=>orderStatus.ToString(),
                orderStatus=>(OrderStatus)Enum.Parse(typeof(OrderStatus),orderStatus));
        
        
    }       

}