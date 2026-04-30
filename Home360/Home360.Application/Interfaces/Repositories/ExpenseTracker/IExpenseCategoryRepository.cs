using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<bool> RegisterCategoryAsync(ExpenseCategory category);
        Task<bool> UpdateCategoryAsync(ExpenseCategory category);
        Task<List<ExpenseCategory>> GetAllCategoriesAsync();
        Task<ExpenseCategory?> GetCategoryOnIdAsync(int categoryId);
        Task<(bool categoryNameExists, bool categoryCodeExists)> CheckDuplicateCategoryNameOrCode(
            string categoryName, string categoryCode, int categoryId);
    }
}
