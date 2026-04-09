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

        public async Task<string> RegisterTypesAsync(ExpenseTypeRequest categoryRequest)
        {
            var (nameExists, codeExists) = await _typeRepository.CheckDuplicateTypeNameOrCode(categoryRequest.ExpenseTypeName, categoryRequest.ExpenseTypeCode);
            if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            if (nameExists) return "Category Name already exists!";
            if (codeExists) return "Category Code already exists!";

            var category = _mapper.Map<ExpenseTypes>(categoryRequest);

            bool categoryAdded = await _typeRepository.RegisterTypeAsync(category);
            return categoryAdded ? "Category Added Successfully" : "Category failed to add!";
        }

        public async Task<List<ExpenseTypeResponse>> GetAllTypesAsync()
        {
            // Add Cache as Data will not change Frequently
            var category = _mapper.Map<List<ExpenseTypeResponse>>(await _typeRepository.GetAllTypesAsync());
            return category;
        }
    }
}
