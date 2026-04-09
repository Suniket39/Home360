using Home360.Application.Interfaces;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;
        public ExpenseCategoryRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterCategoryAsync(ExpenseCategory category)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.ExpenseCategories.Add(category);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ExpenseCategory>> GetAllCategoriesAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.ExpenseCategories.ToListAsync();
        }

        public async Task<(bool categoryNameExists, bool categoryCodeExists)> CheckDuplicateCategoryNameOrCode(string categoryName, string categoryCode)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            var result = await context.ExpenseCategories
                                .Where(x => x.CategoryName == categoryName || x.CategoryCode == categoryCode)
                                .Select(x => new
                                {
                                    NameMatch = x.CategoryName == categoryName,
                                    CodeMatch = x.CategoryCode == categoryCode,
                                })
                                .ToListAsync();
            bool nameExists = result.Any(x => x.NameMatch);
            bool codeExists = result.Any(x => x.CodeMatch);
            return (nameExists, codeExists);
        }
    }
}
