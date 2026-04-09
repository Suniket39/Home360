using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<bool> RegisterCategoryAsync(ExpenseCategory category);
        Task<List<ExpenseCategory>> GetAllCategoriesAsync();
        Task<(bool categoryNameExists, bool categoryCodeExists)> CheckDuplicateCategoryNameOrCode(string categoryName, string categoryCode);
    }
}
