using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IMonthlyCartRepository
    {
        Task<bool> RegisterMonthlyCartAsync(MonthlyCart inventory);
        Task<List<MonthlyCart>> GetAllMonthlyCartAsync();
        Task<MonthlyCart> GetMonthlyCartByIdAsync(int id);
    }
}
