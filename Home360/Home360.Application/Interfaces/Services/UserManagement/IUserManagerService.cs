
using Home360.Application.DTOs;

namespace Home360.Application.Interfaces.Services
{
    public interface IUserManagerService
    {
        //Task<bool> UserExistsAsync(string userName, string mobileNo, string email);
        Task<string> RegisterUserAsync(UserRquest user);
        Task<UserResponse> ValidateCredentialsAsync(LoginRequest loginRequest);
        Task<List<UserResponse>> GetAllUsersAsync();
    }
}
