using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IGroceryItemService
    {
        Task<string> RegisterItemAsync(GroceryItemRequest inventory);
        Task<string> UpdateGroceryItemAsync(GroceryItemRequest itemRequest);
        Task<List<GroceryItemResponse>> GetAllItemsAsync();
    }
}
