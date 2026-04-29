using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class MonthlyCartService : IMonthlyCartService
    {
        private readonly IMonthlyCartRepository _monthlyCartRepository;
        private readonly IMapper _mapper;

        public MonthlyCartService(IMonthlyCartRepository monthlyCartRepository, IMapper mapper)
        {
            _monthlyCartRepository = monthlyCartRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterMonthlyCartAsync(MonthlyCartRequest cartRequest)
        {
            //var (nameExists, codeExists) = await _inventoryRepository.CheckDuplicateTypeNameOrCode(categoryRequest.ExpenseTypeName, categoryRequest.ExpenseTypeCode);
            //if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            //if (nameExists) return "Category Name already exists!";
            //if (codeExists) return "Category Code already exists!";

            var cart = _mapper.Map<MonthlyCart>(cartRequest);

            bool categoryAdded = await _monthlyCartRepository.RegisterMonthlyCartAsync(cart);
            return categoryAdded ? "Product added into Cart successfully" : "Cart failed to add!";
        }

        public async Task<string> UpdateMonthlyCartAsync(MonthlyCartRequest cartRequest)
        {
            var cartExists = await _monthlyCartRepository.GetMonthlyCartByIdAsync(cartRequest.CartId);
            if (cartExists == null) return "Cart does not exists!";

            cartExists.ItemId = cartRequest.ItemId;
            cartExists.RequiredQty = cartRequest.RequiredQty;
            cartExists.IsPurchased = cartRequest.IsPurchased;
            cartExists.Price = cartRequest.Price;

            bool cartUpdated = await _monthlyCartRepository.UpdateMonthlyCartAsync(cartExists);
            return cartUpdated ? "Cart Updated Successfully" : "Cart failed to update!";
        }

        public async Task<List<MonthlyCartResponse>> GetAllMonthlyCartAsync()
        {
            // Add Pagination if Data Grows
            return _mapper.Map<List<MonthlyCartResponse>>(await _monthlyCartRepository.GetAllMonthlyCartAsync());
        }
    }
}