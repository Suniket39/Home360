using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<bool> RegisterTypeAsync(ExpenseTypes category);
        Task<bool> UpdateTypeAsync(ExpenseTypes types);
        Task<List<ExpenseTypes>> GetAllTypesAsync();
        Task<ExpenseTypes?> GetTypeOnIdAsync(int typeId);
        Task<(bool typeNameExists, bool typeCodeExists)> CheckDuplicateTypeNameOrCode(
            string typeName, string typeCode, int typeId);

    }
}
