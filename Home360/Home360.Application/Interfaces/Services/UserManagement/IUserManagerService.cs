
using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IUserManagerService
    {
        Task<string> RegisterUserAsync(UserRquest user);
    }
}
