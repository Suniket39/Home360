using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IMonthlyCartService
    {
        Task<string> RegisterMonthlyCartAsync(MonthlyCartRequest request);
        Task<List<MonthlyCartResponse>> GetAllMonthlyCartAsync();
    }
}
