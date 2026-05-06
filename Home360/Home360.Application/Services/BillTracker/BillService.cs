using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories.BlillTracker;
using Home360.Application.Interfaces.Services.BillTracker;
using Home360.Domain.Entities;

namespace Home360.Application.Services.BillTracker
{
    public class BillService : IBillsService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public BillService(IBillRepository billRepository, IMapper mapper)
        {
            _billRepository = billRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterBillAsync(BillRequest request)
        {
            //var (nameExists, codeExists) = await _billRepository.CheckDuplicateCategoryNameOrCode(
            //    categoryRequest.CategoryName, categoryRequest.CategoryCode, 0);
            //if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            //if (nameExists) return "Category Name already exists!";
            //if (codeExists) return "Category Code already exists!";

            var bill = _mapper.Map<Bills>(request);

            bool categoryAdded = await _billRepository.RegisterBillAsync(bill);
            return categoryAdded ? "Bill Added Successfully" : "Bill failed to add!";
        }

        public async Task<string> UpdateBillAsync(BillRequest request)
        {
            var billExists = await _billRepository.GetBillOnIdAsync(request.BillId);
            if (billExists == null) return "Bill does not exists!";

            //var (nameExists, codeExists) = await _categoryRepository.CheckDuplicateCategoryNameOrCode(
            //    categoryRequest.CategoryName, categoryRequest.CategoryCode, categoryExists.CategoryId);
            //if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            //if (nameExists) return "Category Name already exists!";
            //if (codeExists) return "Category Code already exists!";

            billExists.BillName = request.BillName;
            billExists.Category = request.Category;
            billExists.Amount = request.Amount;
            billExists.BillDate = request.BillDate;
            billExists.DueDate = request.DueDate;
            billExists.BillingCycle = request.BillingCycle;
            billExists.IsRecurring = request.IsRecurring;

            bool updated = await _billRepository.UpdateBillAsync(billExists);
            return updated ? "Bills Updated Successfully" : "Bills failed to Update!";
        }

        public async Task<List<BillResponse>> GetAllBillsAsync()
        {
            var category = _mapper.Map<List<BillResponse>>(await _billRepository.GetAllBillsAsync());
            return category;
        }
    }
}