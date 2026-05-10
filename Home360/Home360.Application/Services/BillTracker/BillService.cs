using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Repositories.BlillTracker;
using Home360.Application.Interfaces.Services.BillTracker;
using Home360.Domain.Entities;

namespace Home360.Application.Services.BillTracker
{
    public class BillService : IBillsService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        private readonly IExpenseTransactionService _expenseTransactionService;

        public BillService(IBillRepository billRepository,
                           IMapper mapper,
                           IExpenseTransactionService expenseTransactionService)
        {
            _billRepository = billRepository;
            _mapper = mapper;
            _expenseTransactionService = expenseTransactionService;
        }

        public async Task<string> RegisterBillAsync(BillRequest request)
        {
            try
            {
                var bill = _mapper.Map<Bills>(request);

                bool added = await _billRepository.RegisterBillAsync(bill);

                if (!added) return "Bill failed to add!";

                if (added && request.Status != "Paid")
                    return "Bills Added Successfully";

                ExpenseTransactionRequest expenseTranReq = new()
                {
                    Amount = request.Amount,
                    ExpenseName = request.Category,
                    TransactionDate = DateTime.Now,
                    TransactionType = "Debit",
                    TransactionMode = "UPI", // ToDo get from BillRquest
                    ExpenseCategoryId = 1, // ToDo Get from request or From Db
                    ExpenseCategoryTypeId = 1, // ToDo Get from request or From Db
                };
                await _expenseTransactionService.RegisterTransactionAsync(expenseTranReq);
                return "Bill Added Successfully";
            }
            catch (Exception ex)
            {
                //Add logger here
                return "Bill failed to add!";
            }
        }

        public async Task<string> UpdateBillAsync(BillRequest request)
        {
            var billExists = await _billRepository.GetBillOnIdAsync(request.BillId);
            if (billExists == null) return "Bill does not exists!";

            billExists.BillName = request.BillName;
            billExists.Category = request.Category;
            billExists.Amount = request.Amount;
            billExists.BillDate = request.BillDate;
            billExists.DueDate = request.DueDate;
            billExists.BillingCycle = request.BillingCycle;
            billExists.IsRecurring = request.IsRecurring;
            billExists.Status = request.Status;
            billExists.IsActive = request.IsActive;

            bool updated = await _billRepository.UpdateBillAsync(billExists);

            if (updated && billExists.Status != "Paid")
            {
                return updated ? "Bills Updated Successfully" : "Bills failed to Update!";
            }

            ExpenseTransactionRequest expenseTranReq = new()
            {
                Amount = request.Amount,
                ExpenseName = request.Category,
                TransactionDate = DateTime.Now,
                TransactionType = "Debit",
                TransactionMode = "UPI", // ToDo get from BillRquest
                ExpenseCategoryId = 1, // ToDo Get from request or From Db
                ExpenseCategoryTypeId = 1, // ToDo Get from request or From Db
            };
            await _expenseTransactionService.RegisterTransactionAsync(expenseTranReq);
            return updated ? "Bills Updated Successfully" : "Bills failed to Update!";
        }

        public async Task<List<BillResponse>> GetAllBillsAsync()
        {
            var category = _mapper.Map<List<BillResponse>>(await _billRepository.GetAllBillsAsync());
            return category;
        }
    }
}