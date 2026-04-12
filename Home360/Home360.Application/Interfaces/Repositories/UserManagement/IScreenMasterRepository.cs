using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IScreenMasterRepository
    {
        Task<bool> RegisterScreenAsync(ScreenMaster screen);
        Task<List<ScreenMaster>> GetAllScreensAsync();
        Task<bool> ScreenCodeExistsAsync(string screenCode);
    }
}
