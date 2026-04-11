using Home360.Application.Interfaces;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure
{
    public class RoleMasterRepository : IRoleMasterRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public RoleMasterRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterRoleAsync(RoleMaster role)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.RoleMaster.Add(role);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoleMaster>> GetAllRolesAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.RoleMaster.ToListAsync();
        }

        public async Task<bool> RoleNameExistsAsync(string roleName)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                return await context.RoleMaster.AnyAsync(x => x.RoleName == roleName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
