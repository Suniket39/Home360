using Home360.Application.Interfaces.Repositories;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories
{
    public class GroceryItemRepository : IGroceryItemRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public GroceryItemRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterGroceryItemAsync(GroceryItem types)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.GroceryItems.Add(types);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<GroceryItem>> GetAllGroceryItemsAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.GroceryItems.ToListAsync();
        }
    }
}

