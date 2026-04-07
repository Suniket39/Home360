using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Persistence
{
    public class HomeDbContext : DbContext
    {
        public DbContextOptions<HomeDbContext> Options { get; }

        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options)
        {
            Options = options;
        }

        #region User Manager
        public virtual DbSet<User> UserManager { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }

        #endregion

        #region Expense Tracker
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User Management Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            #endregion

            #region Expense tracker
            modelBuilder.ApplyConfiguration(new ExpenseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTransactionConfiguration());
            #endregion
        }
    }
}
