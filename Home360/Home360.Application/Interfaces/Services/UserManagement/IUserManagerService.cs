
using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Services
{
    public interface IUserManagerService
    {
        //Task<bool> UserExistsAsync(string userName, string mobileNo, string email);
        Task<string> RegisterUserAsync(UserRquest user);
        Task<List<UserResponse>> GetAllUsersAsync();
    }
}
