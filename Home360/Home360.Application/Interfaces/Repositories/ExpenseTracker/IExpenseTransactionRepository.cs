using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IExpenseTransactionRepository
    {
        Task<bool> RegisterTransactionAsync(ExpenseTransaction category);
        Task<bool> UpdateTransactionAsync(ExpenseTransaction transaction);
        Task<List<ExpenseTransaction>> GetAllTransactionsAsync();
        Task<ExpenseTransaction?> GetTransactionOnIdAsync(int transactionId);
    }
}
