using AutoMapper;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Application.Interfaces.Services;
using Home360.Domain.Entities;


namespace Home360.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly IRoleAccessManagerService _roleAccessManagerService;
        private readonly IScreenMasterService _screenMasterService;

        public AuthService(IUserManagerService userManagerService,
                            IJwtService jwtService,
                            IMapper mapper,
                            IRoleAccessManagerService roleAccessManagerService,
                            IScreenMasterService screenMasterService)
        {
            _userManagerService = userManagerService;
            _jwtService = jwtService;
            _mapper = mapper;
            _roleAccessManagerService = roleAccessManagerService;
            _screenMasterService = screenMasterService;
        }

        public async Task<AuthResponse> AuthenticateAsync(LoginRequest loginRequest)
        {
            try
            {
                var userValid = await _userManagerService.ValidateCredentialsAsync(loginRequest);
                if (userValid == null)
                    throw new UnauthorizedAccessException("Invalid username or password.");

                var accessToken = await _jwtService.GenerateAccessToken(_mapper.Map<User>(userValid)); //JWT Token
                var refreshToken = _jwtService.GenerateRefreshToken();

                //Call here UserScreenAccessMenu and send response
                var roleAccess  = await _roleAccessManagerService.GetRoleAccessOnRoleIdAsync(userValid.RoleId);
                var screenMaster = await _screenMasterService.GetAllScreensAsync();// add Cache
                foreach (var access in roleAccess)
                { 
                    var screen = screenMaster.FirstOrDefault(s => s.ScreenId == access.ScreenId);
                    if (screen != null)
                    {
                        var menuDto = new MenuAccessDto();
                        menuDto.SceenId = screen.ScreenId;
                        menuDto.ScreenCode = screen.ScreenCode;
                        menuDto.MenuName = screen.MenuName;
                        menuDto.MenuIcon = screen.MenuIcon;
                        menuDto.RoutingUrl = screen.RoutingURL;
                    }   
                }
                //Add refreshToken
                await _jwtService.SaveRefreshTokenAsync(refreshToken, userValid.UserId);

                return new AuthResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    AccessTokenExpirations = DateTime.UtcNow.AddMinutes(15), // Example expiration time
                    User = new UserResponse
                    {
                        UserId = userValid.UserId,
                        Email = userValid.Email,
                        Roles = userValid.Roles
                    }
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<string> GenerateTokenAsync(string userId, string email, string role)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
        {
            var user = await _jwtService.GetUserOnTokenAsync(refreshToken);
            if (user == null) return null;

            var oldToken = user.RefreshTokens.SingleOrDefault(rt => rt.Token == refreshToken);
            if (!oldToken.IsActive) return null;

            var newAccessToken =await _jwtService.GenerateAccessToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();
            // Save the new refresh token and invalidate the old one
            await _jwtService.SaveRefreshTokenAsync(newRefreshToken, user.UserId);
            var isRemoved = await _jwtService.RevokeRefreshTokenAsync(refreshToken);
            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                AccessTokenExpirations = DateTime.UtcNow.AddMinutes(15), // Example expiration time
                User = new UserResponse
                {
                    UserId = user.UserId,
                    Email = user.Email
                }
            };
        }

        public async Task<string> RevokeTokenAsync(string refreshToken)
        {
            var user = await _jwtService.GetUserOnTokenAsync(refreshToken);
            if (user == null) return null;

            var oldToken = user.RefreshTokens.SingleOrDefault(rt => rt.Token == refreshToken);
            if (!oldToken.IsActive) return null;

            var isRemoved = await _jwtService.RevokeRefreshTokenAsync(refreshToken);
            return "Token revoked successfully.";
        }
    }
}
