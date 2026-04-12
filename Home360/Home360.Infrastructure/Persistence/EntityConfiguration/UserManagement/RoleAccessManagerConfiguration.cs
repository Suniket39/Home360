using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class RoleAccessManagerConfiguration : IEntityTypeConfiguration<RoleAccessManager>
    {
        public void Configure(EntityTypeBuilder<RoleAccessManager> builder)
        {
            builder.HasKey(e => e.RoleAccessManagerId);
            builder.Property(e => e.RoleAccessManagerId).ValueGeneratedOnAdd();
            builder.Property(e => e.CanRead).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CanCreate).IsRequired().HasMaxLength(50);
            builder.Property(e => e.CanUpdate).IsRequired().HasMaxLength(50);
            builder.Property(e => e.CanDeactivate).IsRequired().HasMaxLength(255);

            builder.HasOne(e => e.RoleMaster)
                   .WithMany(r => r.RoleAccessManager)
                   .HasForeignKey(e => e.RoleId)
                   .IsRequired();
            builder.HasOne(s => s.ScreenMaster)
                   .WithMany(r => r.RoleAccessManagers)
                   .HasForeignKey(s => s.ScreenId)
                   .IsRequired();
        }
    }
}
