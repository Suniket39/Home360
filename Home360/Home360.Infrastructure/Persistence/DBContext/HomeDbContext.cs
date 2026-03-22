using Home360.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region
            // User Management Configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            #endregion
        }
    }
}
