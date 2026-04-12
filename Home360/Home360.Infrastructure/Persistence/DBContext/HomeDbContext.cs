using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence.EntityConfiguration;
using Home360.Infrastructure.Persistence.Helper;
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
        public virtual DbSet<RoleMaster> RoleMaster { get; set; }
        public virtual DbSet<RoleAccessManager> RoleAccessManager { get; set; }
        public virtual DbSet<ScreenMaster> AccessMaster { get; set; }

        #endregion

        #region Expense Tracker
        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }

        #endregion

        [System.Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region User Management Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleMasterConfiguration());
            modelBuilder.ApplyConfiguration(new RoleAccessManagerConfiguration());
            modelBuilder.ApplyConfiguration(new ScreenMasterConfiguration());
            #endregion

            #region Expense tracker
            modelBuilder.ApplyConfiguration(new ExpenseCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTransactionConfiguration());
            #endregion
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            AuditHelper.SetAuditFields(ChangeTracker, "Demo");
            return await base.SaveChangesAsync(cancellation);
        }
    }
}
