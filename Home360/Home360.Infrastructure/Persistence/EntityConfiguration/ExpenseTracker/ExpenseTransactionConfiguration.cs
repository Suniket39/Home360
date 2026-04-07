using Home360.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class ExpenseTransactionConfiguration : IEntityTypeConfiguration<ExpenseTransaction>
    {
        public void Configure(EntityTypeBuilder<ExpenseTransaction> builder)
        {
            builder.HasKey(x => x.TransactionId);
            builder.Property(x => x.TransactionId).ValueGeneratedOnAdd();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.ExpenseName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.Property(x => x.TransactionType).IsRequired().HasMaxLength(10);
            builder.Property(x => x.TransactionMode).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();

            builder.HasOne(x => x.ExpenseCategory)
                   .WithMany(x => x.ExpenseTransactions)
                   .HasForeignKey(x => x.ExpenseCategoryId)
                   .IsRequired();
            builder.HasOne(x => x.ExpenseCategoryType)
                   .WithMany(x => x.ExpenseTransactions)
                   .HasForeignKey(x => x.ExpenseCategoryTypeId)
                   .IsRequired();
        }
    }
}
