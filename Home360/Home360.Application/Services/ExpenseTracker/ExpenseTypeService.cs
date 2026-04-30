using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseTypeRepository _typeRepository;
        private readonly IMapper _mapper;

        public ExpenseTypeService(IExpenseTypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterTypesAsync(ExpenseTypeRequest expenseRequest)
        {
            var (nameExists, codeExists) = await _typeRepository.CheckDuplicateTypeNameOrCode(
                expenseRequest.ExpenseTypeName, expenseRequest.ExpenseTypeCode, 0);
            if (nameExists && codeExists) return "Expense Type Name & Code already exists!";
            if (nameExists) return "Expense Type Name already exists!";
            if (codeExists) return "Expense Type Code already exists!";

            var category = _mapper.Map<ExpenseTypes>(expenseRequest);

            bool categoryAdded = await _typeRepository.RegisterTypeAsync(category);
            return categoryAdded ? "Category Added Successfully" : "Category failed to add!";
        }

        public async Task<string> UpdateTypeAsync(ExpenseTypeRequest typeRequest)
        {
            var typeExists = await _typeRepository.GetTypeOnIdAsync(typeRequest.ExpenseTypeId                                                           );
            if (typeExists == null) return "Type does not exists!";

            var (nameExists, codeExists) = await _typeRepository.CheckDuplicateTypeNameOrCode(
                typeRequest.ExpenseTypeName, typeRequest.ExpenseTypeCode, typeExists.ExpenseCategoryId);
            if (nameExists && codeExists) return "Type Name & Code already exists!";
            if (nameExists) return "Type Name already exists!";
            if (codeExists) return "Type Code already exists!";

            typeExists.ExpenseTypeName = typeRequest.ExpenseTypeName;
            typeExists.ExpenseTypeCode = typeRequest.ExpenseTypeCode;
            typeExists.ExpenseCategoryId = typeRequest.ExpenseCategoryId;
            typeExists.ExpenseTypeDescription = typeRequest.ExpenseTypeDescription;

            bool updated = await _typeRepository.UpdateTypeAsync(typeExists);
            return updated ? "Exepnse Type Updated Successfully" : "Exepnse Type failed to Update!";
        }
        public async Task<List<ExpenseTypeResponse>> GetAllTypesAsync()
        {
            // Add Cache as Data will not change Frequently
            var category = _mapper.Map<List<ExpenseTypeResponse>>(await _typeRepository.GetAllTypesAsync());
            return category;
        }
    }
}
