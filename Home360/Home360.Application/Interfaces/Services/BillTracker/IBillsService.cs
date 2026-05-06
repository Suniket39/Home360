using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services.BillTracker
{
    public interface IBillsService
    {
        Task<string> RegisterBillAsync(BillRequest category);
        Task<string> UpdateBillAsync(BillRequest tranRequest);
        Task<List<BillResponse>> GetAllBillsAsync();
    }
}
