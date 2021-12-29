using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Domain.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Entities.Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.CreatedDate).IsRequired();
        }
    }
}
