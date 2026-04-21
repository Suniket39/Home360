using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration8
{
    public class GroceryItemConfiguration : IEntityTypeConfiguration<GroceryItem>
    {
        public void Configure(EntityTypeBuilder<GroceryItem> builder)
        {
            // Primary Key
            builder.HasKey(e => e.ItemId);

            builder.Property(e => e.ItemId).ValueGeneratedOnAdd();
            builder.Property(e => e.ItemName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ItemDescription).HasMaxLength(255);
            builder.Property(e => e.ItemUnit).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Status).IsRequired().HasMaxLength(10);
        }
    }
}
