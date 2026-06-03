using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class GroceryInventoryConfiguration : IEntityTypeConfiguration<GroceryInventory>
    {
        public void Configure(EntityTypeBuilder<GroceryInventory> builder)
        {
            builder.HasKey(x => x.InventoryId);
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(10, 4)");
            builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Remarks).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.GroceryItem)
                .WithMany(i => i.GroceryInventories)
                .HasForeignKey(x => x.ItemId)
                .IsRequired();
        }
    }
}
