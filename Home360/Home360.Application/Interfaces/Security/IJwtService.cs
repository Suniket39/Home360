using Home360.Application.DTOs;
using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateAccessToken(User user);
        string GenerateRefreshToken();
        Task<bool> SaveRefreshTokenAsync(string token, int userId);
        Task<User> GetUserOnTokenAsync(string token);
        Task<bool> RevokeRefreshTokenAsync(string token);
        Task<(List<UserScreenAccessDto>, List<MenuAccessDto>)> GetUserRoleSpecificMenuAccess(int roleId);
    }
}
