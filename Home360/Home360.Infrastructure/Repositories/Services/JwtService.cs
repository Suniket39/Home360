using Home360.Application;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Home360.Domain.Entities;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Home360.Infrastructure.Repositories
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<JwtService> _logger;
        private readonly IHomeContextFactory _homeContextFactory;

        public JwtService(IOptions<JwtSettings> jwtSettings, ILogger<JwtService> logger, IHomeContextFactory homeContextFactory)
        {
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
            _homeContextFactory = homeContextFactory;
        }

        public async Task<string> GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey); // secret key from appsettings.json

            //var userSpecificMenu = await GetUserRoleSpecificMenuAccess(user.RoleId);
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new (ClaimTypes.Name, user.Username),
                new (ClaimTypes.Email, user.Email),
                //new Claim("UserAccess",  JsonSerializer.Serialize(userSpecificMenu.Item1)),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.Iat,
                     new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                     ClaimValueTypes.Integer64)
            };

            if(user.Role is not null)
            {
                claims.Add(new Claim("roleName", user.Role.RoleName));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            _logger.LogInformation("Generated JWT Token for UserId {UserId}: {Token}", user.UserId, tokenString);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            return RandomTokenString();
        }

        private static string RandomTokenString()
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[64];
            randomNumberGenerator.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes)
                   .Replace("+","-")
                   .Replace("/", "_")
                   .Replace("=", "");
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            return ValidateToken(token, validateLifetime: false);
        }

        public ClaimsPrincipal? ValidateToken(string token, bool validateLifetime = true)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateLifetime = validateLifetime,
                    ClockSkew = TimeSpan.FromMinutes(1) // Allow 1 min clock skew
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                if(validatedToken is not JwtSecurityToken jwtToken ||
                   !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    _logger.LogWarning("Token validation failed: Invalid token algorithm");
                    return null;
                }
                return principal;
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogWarning("Token validation failed: {Message}", ex.Message);
                throw;
            }
        }

        public async Task<bool> SaveRefreshTokenAsync(string token, int userId)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                var refreshToken = new RefreshToken
                {
                    Token = token,
                    UserId = userId,
                    Expires = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays),
                    Created = DateTime.UtcNow
                };

                context.RefreshToken.Add(refreshToken);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetUserOnTokenAsync(string token)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                var userAccount = await context.UserManager
                                        .Include(x => x.RefreshTokens)
                                        .FirstOrDefaultAsync(x => x.RefreshTokens.Any(t => t.Token == token));

                if (userAccount == null) return null;
                return userAccount;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> RevokeRefreshTokenAsync(string token)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                var refreshToken = await context.RefreshToken.FirstOrDefaultAsync(x => x.Token == token);
                if (refreshToken == null) return false;
                context.RefreshToken.Remove(refreshToken);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task<(List<UserScreenAccessDto>, List<MenuAccessDto>)> GetUserRoleSpecificMenuAccess(int roleId)
        {
            try
            {
                List<UserScreenAccessDto> userAccessList = new List<UserScreenAccessDto>();
                List<MenuAccessDto> menuDtoList = new List<MenuAccessDto>();
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                var roleAccess = await context.RoleAccessManager
                                 .Where(x => x.RoleId == roleId)
                                 .ToListAsync();
                var screenMaster = await context.ScreenMaster.AsNoTracking().ToListAsync();

                foreach (var access in roleAccess)
                {
                    var userAccessDto = new UserScreenAccessDto();
                    if (access.CanCreate) userAccessDto.CanCreate = access.CanCreate;
                    if (access.CanRead) userAccessDto.CanRead = access.CanRead;
                    if (access.CanUpdate) userAccessDto.CanUpdate = access.CanUpdate;
                    if (access.CanDeactivate) userAccessDto.CanDeactivate = access.CanDeactivate;

                    var screen = screenMaster.FirstOrDefault(x => x.ScreenId == access.ScreenId);
                    if (screen != null)
                    {
                        // Build user access string based on permissions (C, R, U, D)
                        var menuDto = new MenuAccessDto();
                        menuDto.SceenId = screen.ScreenId;
                        menuDto.ScreenCode = screen.ScreenCode;
                        menuDto.MenuName = screen.MenuName;
                        menuDto.MenuIcon = screen.MenuIcon;
                        menuDto.RoutingUrl = screen.RoutingURL;
                        if (access.CanCreate) userAccessDto.CanCreate = access.CanCreate;
                        if (access.CanRead) userAccessDto.CanRead = access.CanRead;
                        if (access.CanUpdate) userAccessDto.CanUpdate = access.CanUpdate;
                        if (access.CanDeactivate) userAccessDto.CanDeactivate = access.CanDeactivate;
                        userAccessDto.ScreenCode = screen.ScreenCode;
                        // Add to claims or user access list as needx`ed

                        menuDtoList.Add(menuDto);
                    }

                    userAccessList.Add(userAccessDto);
                }
                return (userAccessList, menuDtoList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
