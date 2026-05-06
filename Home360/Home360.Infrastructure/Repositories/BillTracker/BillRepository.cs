using Home360.Application.Interfaces.Repositories.BlillTracker;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories.BillTracker
{
    internal class BillRepository : IBillRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;
        public BillRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterBillAsync(Bills bill)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.Bills.Add(bill);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateBillAsync(Bills bill)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.Bills.Update(bill);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Bills>> GetAllBillsAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.Bills.ToListAsync();
        }

        public async Task<Bills?> GetBillOnIdAsync(int billId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.Bills.FirstOrDefaultAsync(x => x.BillId == billId);
        }
    }
}

