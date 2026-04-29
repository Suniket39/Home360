using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class MonthlyCartRepository : IMonthlyCartRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public MonthlyCartRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterMonthlyCartAsync(MonthlyCart cart)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.MonthlyCarts.Add(cart);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateMonthlyCartAsync(MonthlyCart cart)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.MonthlyCarts.Update(cart);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<MonthlyCart>> GetAllMonthlyCartAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.MonthlyCarts.ToListAsync();
        }

        public async Task<MonthlyCart?> GetMonthlyCartByIdAsync(int id)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.MonthlyCarts.FirstOrDefaultAsync(x => x.CartId == id);
        }
    }
}