using Home360.Domain.Entities;

namespace Home360.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        Task<bool> SaveRefreshTokenAsync(string token, int userId);
        Task<User> GetUserOnTokenAsync(string token);
        Task<bool> RevokeRefreshTokenAsync(string token);
    }
}
