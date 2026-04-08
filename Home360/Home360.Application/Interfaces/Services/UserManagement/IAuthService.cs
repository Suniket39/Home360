namespace Home360.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateAsync(LoginRequest loginRequest);
        Task<string> GenerateTokenAsync(string userId, string email, string role);
        Task<AuthResponse> RefreshTokenAsync(string refreshToken);
        Task<string> RevokeTokenAsync(string refreshToken);
    }
}
