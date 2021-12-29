using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Domain.EntityConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Quantity).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x=>x.Items).HasForeignKey(x=>x.OrderId);
            builder.HasOne(x => x.ProductType).WithMany(x => x.Items).HasForeignKey(x => x.ProductTypeId);
        }
    }
}
