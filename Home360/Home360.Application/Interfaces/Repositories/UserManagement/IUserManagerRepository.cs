using Home360.Domain.Entities;

namespace Home360.Application.Interfaces.Repositories
{
    public interface IUserManagerRepository
    {
        Task<bool> RegisterUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<bool> UserNameExistsAsync(string userName);
        Task<bool> UserExistsAsync(string userName, string mobileNo, string email);
        Task<User> ActiveUserExistsAsync(string userName);                                     
    }
}
