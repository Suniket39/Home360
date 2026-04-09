using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseTransactionRepository
    {
        Task<bool> RegisterTransactionAsync(ExpenseTransaction category);
        Task<List<ExpenseTransaction>> GetAllTransactionsAsync();
    }
}
