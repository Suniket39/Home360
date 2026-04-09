using Home360.Application.Interfaces;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class ExpenseTransactionRepository : IExpenseTransactionRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public ExpenseTransactionRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterTransactionAsync(ExpenseTransaction transaction)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.ExpenseTransactions.Add(transaction);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ExpenseTransaction>> GetAllTransactionsAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.ExpenseTransactions.ToListAsync();
        }
    }
}
