using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Services
{
    public interface IMonthlyCartService
    {
        Task<string> RegisterMonthlyCartAsync(MonthlyCartRequest request);
        Task<string> UpdateMonthlyCartAsync(MonthlyCartRequest request);
        Task<List<MonthlyCartResponse>> GetAllMonthlyCartAsync();
    }
}
