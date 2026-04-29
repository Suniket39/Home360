using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IGroceryInventoryService
    {
        Task<string> RegisterInventoryAsync(GroceryInventoryRequest inventory);
        Task<string> UpdateInventoryAsync(GroceryInventoryRequest inventoryRequest);
        Task<List<GroceryInventoryResponse>> GetAllInventoriesAsync();
    }
}
