using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class GroceryInventoryService : IGroceryInventoryService
    {
        private readonly IGroceryInventory _inventoryRepository;
        private readonly IMapper _mapper;

        public GroceryInventoryService(IGroceryInventory inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterInventoryAsync(GroceryInventoryRequest inventoryRequest)
        {
            //var (nameExists, codeExists) = await _inventoryRepository.CheckDuplicateTypeNameOrCode(categoryRequest.ExpenseTypeName, categoryRequest.ExpenseTypeCode);
            //if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            //if (nameExists) return "Category Name already exists!";
            //if (codeExists) return "Category Code already exists!";

            var inventory = _mapper.Map<GroceryInventory>(inventoryRequest);

            bool categoryAdded = await _inventoryRepository.RegisterInventoryAsync(inventory);
            return categoryAdded ? "Inventory Added Successfully" : "Inventory failed to add!";
        }

        public async Task<List<GroceryInventoryResponse>> GetAllInventoriesAsync()
        {
            // Add Pagination if Data Grows
            return _mapper.Map<List<GroceryInventoryResponse>>(await _inventoryRepository.GetAllInventoriesAsync());
        }
    }
}
