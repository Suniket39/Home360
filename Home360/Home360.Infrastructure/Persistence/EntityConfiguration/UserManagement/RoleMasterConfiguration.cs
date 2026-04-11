using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence
{
    public class RoleMasterConfiguration : IEntityTypeConfiguration<RoleMaster>
    {
        public void Configure(EntityTypeBuilder<RoleMaster> builder)
        {
            // Primary Key
            builder.HasKey(e => e.RoleId);

            builder.Property(e => e.RoleId).ValueGeneratedOnAdd();
            builder.Property(e => e.RoleName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).HasMaxLength(255);
        }
    }
}
