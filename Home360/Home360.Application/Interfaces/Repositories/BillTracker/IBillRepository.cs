using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories.BlillTracker
{
    public interface IBillRepository
    {
        Task<bool> RegisterBillAsync(Bills bill);
        Task<bool> UpdateBillAsync(Bills bill);
        Task<List<Bills>> GetAllBillsAsync();
        Task<Bills?> GetBillOnIdAsync(int billId);
    }
}
