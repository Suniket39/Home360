using Home360.Application.Interfaces;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    internal class ExpenseTypeRepository : IExpenseTypeRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;
        public ExpenseTypeRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterTypeAsync(ExpenseTypes types)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.ExpenseTypes.Add(types);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTypeAsync(ExpenseTypes types)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.ExpenseTypes.Update(types);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ExpenseTypes>> GetAllTypesAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.ExpenseTypes.ToListAsync();
        }

        public async Task<ExpenseTypes?> GetTypeOnIdAsync(int typeId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.ExpenseTypes.FirstOrDefaultAsync();
        }


        public async Task<(bool typeNameExists, bool typeCodeExists)>   CheckDuplicateTypeNameOrCode(
            string typeName, string typeCode, int typeId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            var result = await context.ExpenseTypes
                                .Where(x => x.ExpenseCategoryId != typeId &&
                                    (x.ExpenseTypeName == typeName || x.ExpenseTypeCode == typeCode))
                                .Select(x => new
                                {
                                    NameMatch = x.ExpenseTypeName == typeName,
                                    CodeMatch = x.ExpenseTypeCode == typeCode,
                                })
                                .ToListAsync();
            bool nameExists = result.Any(x => x.NameMatch);
            bool codeExists = result.Any(x => x.CodeMatch);
            return (nameExists, codeExists);
        }
    }
}
