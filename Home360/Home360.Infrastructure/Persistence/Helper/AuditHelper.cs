using Home360.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Home360.Infrastructure.Persistence.Helper
{
    public static class AuditHelper
    {
        public static void SetAuditFields(ChangeTracker changeTracker, string userName)
        {
            foreach (var entry in changeTracker.Entries<CommonEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userName;
                    entry.Entity.IsActive = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = userName;
                }
            }
        }
    }
}