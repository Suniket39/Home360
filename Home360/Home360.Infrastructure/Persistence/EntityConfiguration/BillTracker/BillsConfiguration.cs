using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class BillsConfiguration : IEntityTypeConfiguration<Bills>
    {
        public void Configure(EntityTypeBuilder<Bills> builder)
        {
            builder.HasKey(x => x.BillId);
            builder.Property(x => x.BillId).ValueGeneratedOnAdd();
            builder.Property(x => x.BillName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(10, 4);
            builder.Property(x => x.Category).IsRequired().HasMaxLength(30);
            builder.Property(e => e.BillDate).IsRequired().HasColumnType("date");
            builder.Property(e => e.DueDate).IsRequired(false).HasColumnType("date");
            builder.Property(x => x.BillingCycle).IsRequired(false).HasMaxLength(30);
            builder.Property(x => x.IsRecurring);
            builder.Property(x => x.ReminderDaysBefore).IsRequired(false);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(30);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();
        }
    }
}
