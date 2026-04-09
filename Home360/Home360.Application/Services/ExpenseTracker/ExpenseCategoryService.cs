using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ExpenseCategoryService(IExpenseCategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterCategoryAsync(ExpenseCategoryRequest categoryRequest)
        {
            var (nameExists, codeExists) = await _categoryRepository.CheckDuplicateCategoryNameOrCode(categoryRequest.CategoryName, categoryRequest.CategoryCode);
            if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            if (nameExists) return "Category Name already exists!";
            if (codeExists) return "Category Code already exists!";

            var category = _mapper.Map<ExpenseCategory>(categoryRequest);

            bool categoryAdded = await _categoryRepository.RegisterCategoryAsync(category);
            return categoryAdded ? "Category Added Successfully" : "Category failed to add!";
        }

        public async Task<List<ExpenseCategoryResponse>> GetAllCategoriesAsync()
        {
            // Add Cache as Data will not change Frequently
            var category = _mapper.Map<List<ExpenseCategoryResponse>>(await _categoryRepository.GetAllCategoriesAsync());
            return category;
        }
    }
}
