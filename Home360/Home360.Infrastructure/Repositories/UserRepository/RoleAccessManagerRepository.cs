using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class RoleAccessManagerRepository : IRoleAccessManagerRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public RoleAccessManagerRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterRoleAccessManagerAsync(RoleAccessManager role)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.RoleAccessManager.Add(role);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoleAccessManager>> GetAllRoleAccessAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.RoleAccessManager.ToListAsync();
        }

        public async Task<bool> RoleExistsAsync(int roleId)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                return await context.RoleAccessManager.AnyAsync(x => x.RoleId == roleId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<RoleAccessManager>> GetRoleAccessOnRoleIdAsync(int roleId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.RoleAccessManager.Where(x => x.RoleId == roleId).ToListAsync();
        }
    }
}
