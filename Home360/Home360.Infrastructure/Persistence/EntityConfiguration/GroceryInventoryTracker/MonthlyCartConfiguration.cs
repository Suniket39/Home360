using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class MonthlyCartConfiguration : IEntityTypeConfiguration<MonthlyCart>
    {
        public void Configure(EntityTypeBuilder<MonthlyCart> builder)
        {
            builder.HasKey(x => x.CartId);
            builder.Property(x => x.CartId).ValueGeneratedOnAdd();
            builder.Property(x => x.RequiredQty).IsRequired().HasPrecision(10, 4);
            builder.Property(x => x.IsPurchased);
            builder.Property(x => x.Price).IsRequired().HasPrecision(10, 4);
            builder.HasOne(x => x.GroceryItem)
                .WithMany(i => i.MonthlyCart)
                .HasForeignKey(x => x.ItemId)
                .IsRequired();
        }
    }
}
