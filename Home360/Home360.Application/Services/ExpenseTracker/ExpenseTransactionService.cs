using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    internal class ExpenseTransactionService : IExpenseTransactionService
    {
        private readonly IExpenseTransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public ExpenseTransactionService(IExpenseTransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterTransactionAsync(ExpenseTransactionRequest tranRequest)
        {
            var transaction = _mapper.Map<ExpenseTransaction>(tranRequest);

            bool categoryAdded = await _transactionRepository.RegisterTransactionAsync(transaction);
            return categoryAdded ? "Transaction Added Successfully" : "Transaction failed to add!";
        }

        public async Task<string> UpdateTransactionAsync(ExpenseTransactionRequest tranRequest)
        {
            var transactionExists = await _transactionRepository.GetTransactionOnIdAsync(tranRequest.TransactionId);
            if (transactionExists == null) return "Transaction does not exists!";

            transactionExists.ExpenseName = tranRequest.ExpenseName;
            transactionExists.Amount = tranRequest.Amount;
            transactionExists.Description = tranRequest.Description;
            transactionExists.TransactionDate = tranRequest.TransactionDate;
            transactionExists.TransactionType = tranRequest.TransactionType;    
            transactionExists.ExpenseCategoryId = tranRequest.ExpenseCategoryId;
            transactionExists.ExpenseCategoryTypeId = tranRequest.ExpenseCategoryTypeId;

            bool updated = await _transactionRepository.UpdateTransactionAsync(transactionExists);
            return updated ? "Transaction Updated Successfully" : "Transaction failed to Update!";
        }

        public async Task<List<ExpenseTransactionResponse>> GetAllTransactionsAsync()
        {
            // Add Cache as Data will not change Frequently
           return _mapper.Map<List<ExpenseTransactionResponse>>(await _transactionRepository.GetAllTransactionsAsync());
        }
    }
}
