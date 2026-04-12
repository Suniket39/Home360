using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    internal class ScreenMasterRepository : IScreenMasterRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public ScreenMasterRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterScreenAsync(ScreenMaster screen)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.ScreenMaster.Add(screen);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ScreenMaster>> GetAllScreensAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.ScreenMaster.ToListAsync();
        }

        public async Task<bool> ScreenCodeExistsAsync(string screenCode)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                return await context.ScreenMaster.AnyAsync(x => x.ScreenCode == screenCode);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
