using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Repositories;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;

namespace Home360.Application.Services
{
    public class GroceryItemService : IGroceryItemService
    {
        private readonly IGroceryItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GroceryItemService(IGroceryItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<string> RegisterItemAsync(GroceryItemRequest itemRequest)
        {
            //var (nameExists, codeExists) = await _inventoryRepository.CheckDuplicateTypeNameOrCode(categoryRequest.ExpenseTypeName, categoryRequest.ExpenseTypeCode);
            //if (nameExists && codeExists) return "Catgory Name & Code already exists!";
            //if (nameExists) return "Category Name already exists!";
            //if (codeExists) return "Category Code already exists!";

            var item = _mapper.Map<GroceryItem>(itemRequest);

            bool itemAdded = await _itemRepository.RegisterGroceryItemAsync(item);
            return itemAdded ? "Item Added Successfully" : "Item failed to add!";
        }

        public async Task<string> UpdateGroceryItemAsync(GroceryItemRequest itemRequest)
        {
            var itemExists = await _itemRepository.GetItemOnIdAsync(itemRequest.ItemId);
            if (itemExists == null) return "Item does not exists!";

            itemExists.ItemName = itemRequest.ItemName;
            itemExists.ItemUnit = itemRequest.ItemUnit;
            itemExists.Status = itemRequest.Status;
            if (!string.IsNullOrEmpty(itemRequest.ItemDescription))
                itemExists.ItemDescription = itemRequest.ItemDescription;

            bool updated = await _itemRepository.UpdateGroceryItemAsync(itemExists);
            return updated ? "Item Updated Successfully" : "Item failed to Update!";
        }

        public async Task<List<GroceryItemResponse>> GetAllItemsAsync()
        {
            // Add Pagination if Data Grows
            return _mapper.Map<List<GroceryItemResponse>>(await _itemRepository.GetAllGroceryItemsAsync());
        }
    }
}

