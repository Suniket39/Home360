using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IGroceryInventory
    {
        Task<bool> RegisterInventoryAsync(GroceryInventory inventory);
        Task<List<GroceryInventory>> GetAllInventoriesAsync();
    }
}
