using Home360.Application.DTOs;

namespace Home360.Application.Interfaces
{
    public interface IExpenseTransactionService
    {
        Task<string> RegisterTransactionAsync(ExpenseTransactionRequest category);
        Task<List<ExpenseTransactionResponse>> GetAllTransactionsAsync();
    }
}
