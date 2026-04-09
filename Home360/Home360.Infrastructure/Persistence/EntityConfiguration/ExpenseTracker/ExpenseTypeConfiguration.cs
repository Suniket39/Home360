using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseTypes>
    {
        public void Configure(EntityTypeBuilder<ExpenseTypes> builder)
        {
            builder.HasKey(x => x.ExpenseTypeId);
            builder.Property(x => x.ExpenseTypeId).ValueGeneratedOnAdd();
            builder.Property(x => x.ExpenseTypeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ExpenseTypeDescription).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.ExpenseTypeCode).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ExpenseCategoryId).IsRequired(true);
            builder.HasIndex(x => x.ExpenseTypeCode).IsUnique();
            builder.HasOne(x => x.ExpenseCategory)
                   .WithMany(x => x.ExpenseTypes)
                   .HasForeignKey(x => x.ExpenseCategoryId)
                   .IsRequired();
        }
    }
}
