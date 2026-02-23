                                                                                                                                                                                                                       using Home360.Application.Interfaces.Services;

namespace Home360.Application.Services
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
            
        }

        public Task<AuthResponse> AuthenticateAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateTokenAsync(string userId, string email, string role)
        {
            throw new NotImplementedException();
        }
    }
}
