using Home360.API.Core.Auth;
using Home360.Application;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers.UserManager
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] LoginRequest login)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid login request.");

            var res = await _authService.AuthenticateAsync(login);

            if (res == null)
                return Unauthorized("Invalid username or password.");
            SetTokenCookie(res.RefreshToken);
            return Ok(res);
        }


        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // True -> for HTTPS only
                SameSite = SameSiteMode.None, // Strict for cross-site requests, Lax for same-site requests, None for both
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
