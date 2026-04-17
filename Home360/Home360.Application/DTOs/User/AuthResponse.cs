using Home360.Application.DTOs;

namespace Home360.Application
{
    public class AuthResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpirations { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public UserResponse User { get; set; } = new UserResponse();
        public List<UserAccessDto> UserAccess { get; set; } = new();
        public List<MenuAccessDto> MenuAccess { get; set; } = new();
    }
}
