using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class ScreenMasterConfiguration : IEntityTypeConfiguration<ScreenMaster>
    {
        public void Configure(EntityTypeBuilder<ScreenMaster> builder)
        {
            builder.HasKey(e => e.ScreenId);
            builder.Property(e => e.ScreenId).ValueGeneratedOnAdd();

            builder.Property(e => e.ScreenName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ScreenCode).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MenuName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ParentId).IsRequired();
            builder.Property(e => e.RoutingURL).IsRequired().HasMaxLength(255);
            builder.Property(e => e.MenuIcon).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Sequence).IsRequired();
        }
    }
}
