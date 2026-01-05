using Home360.Domain.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId).ValueGeneratedOnAdd();
            builder.Property(e => e.Username).IsRequired().HasMaxLength(100);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.MobileNumber).HasMaxLength(15);
            builder.Property(e => e.DateOfBirth).HasColumnType("date");

            builder.HasOne(e => e.Role)
                   .WithMany(u => u.Users)
                   .HasForeignKey(e => e.RoleId)
                   .IsRequired();
        }
    }
}
