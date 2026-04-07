using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).ValueGeneratedOnAdd();
            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CategoryDescription).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.CategoryCode).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ParentCategoryId).IsRequired(false);
            builder.Property(x => x.ParentCategoryCode).IsRequired(false).HasMaxLength(30);
            builder.HasIndex(x => x.CategoryCode).IsUnique();

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();
            builder.HasOne(x => x.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(x => x.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
