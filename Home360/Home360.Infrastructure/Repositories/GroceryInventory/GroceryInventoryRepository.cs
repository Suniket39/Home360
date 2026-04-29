using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class GroceryInventoryRepository : IGroceryInventory
    {
        private readonly IHomeContextFactory _homeContextFactory;
        public GroceryInventoryRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterInventoryAsync(GroceryInventory types)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.GroceryInventories.Add(types);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateInventoryAsync(GroceryInventory inventory)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.GroceryInventories.Update(inventory);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<GroceryInventory>> GetAllInventoriesAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.GroceryInventories.ToListAsync();
        }

        public async Task<GroceryInventory?> GetInventoryOnIdAsync(int inventoryId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.GroceryInventories.FirstOrDefaultAsync(x => x.InventoryId == inventoryId);
        }
    }
}
