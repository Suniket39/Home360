using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IScreenMasterService
    {
        Task<string> RegisterScreenAsync(ScreenMasterRequest screen);
        Task<List<ScreenMasterResponse>> GetAllScreensAsync();
    }
}
