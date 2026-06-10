using Home360.Application;
using Home360.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Home360.API.Core.Middleware
{
    public class JwtHandlerMiddleware : IMiddleware
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IAuthService _authService; 

        public JwtHandlerMiddleware(IOptions<JwtSettings> jwtSettings, IAuthService authService)
        {
            _jwtSettings = jwtSettings.Value;
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate _next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                await AttachAccountToContext(context, token);

            await _next(context);
        }

        private async Task  AttachAccountToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.SecretKey); // Replace with your actual secret key

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = _jwtSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1) // Allow 1 min clock skew

                }, out SecurityToken validatedToken);                    
                
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
                var userName = jwtToken.Claims.First(x => x.Type == "unique_name").Value;
                //var userAccess = jwtToken.Claims.First(x => x.Type == "UserAccess").Value;
                var userRoleMenuAccess = await _authService.GetUserRoleSpecificMenuAccess(userId);
                var userAccess = userRoleMenuAccess.Item1;

                context.Items["UserId"] = userId;
                context.Items["UserName"] = userName;
                context.Items["UserAccess"] = userAccess;
                //context.Session.SetInt32("UserId", userId);
                //context.Session.SetString("UserName", userName);
                //context.Items["UserAccess"]= userAccess;
            }
            catch(Exception ex) 
            {
                //Logger.Error("Error in JWT middleware - " + ex);
                throw new Exception("Error in JWT token " + ex.Message);
            }
        }
    }
}
