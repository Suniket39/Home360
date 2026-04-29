using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IGroceryItemRepository
    {
        Task<bool> RegisterGroceryItemAsync(GroceryItem item);
        Task<bool> UpdateGroceryItemAsync(GroceryItem item);
        Task<List<GroceryItem>> GetAllGroceryItemsAsync();
        Task<GroceryItem?> GetItemOnIdAsync(int itemId);
    }
}
