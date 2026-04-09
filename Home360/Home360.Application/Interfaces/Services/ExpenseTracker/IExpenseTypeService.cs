using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IExpenseTypeService
    {
        Task<string> RegisterTypesAsync(ExpenseTypeRequest category);
        Task<List<ExpenseTypeResponse>> GetAllTypesAsync();
    }
}
