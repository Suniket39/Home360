using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Services
{
    public interface IExpenseCategoryService
    {
        Task<string> RegisterCategoryAsync(ExpenseCategoryRequest category);
        Task<List<ExpenseCategoryResponse>> GetAllCategoriesAsync();
    }
}
