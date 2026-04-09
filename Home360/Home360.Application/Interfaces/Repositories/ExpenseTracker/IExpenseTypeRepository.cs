using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseTypeRepository
    {
        Task<bool> RegisterTypeAsync(ExpenseTypes category);
        Task<List<ExpenseTypes>> GetAllTypesAsync();
        Task<(bool typeNameExists, bool typeCodeExists)> CheckDuplicateTypeNameOrCode(string typeName, string typeCode);

    }
}
