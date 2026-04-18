using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers.UserManager
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsyn([FromBody] RevokeTokenRequest request)
        {
            if (string.IsNullOrEmpty(Request.Cookies["refreshToken"]))
                return BadRequest("Refresh token is missing.");

            var response = await _authService.RefreshTokenAsync(request.Token);
            if (response == null) return Unauthorized("Invalid refresh token.");
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost]
        [Route("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync([FromBody] RevokeTokenRequest request)
        {
            if (string.IsNullOrEmpty(Request.Cookies["refreshToken"]))
                return BadRequest("Refresh token is missing.");
            var result = await _authService.RevokeTokenAsync(request.Token);
            if (result == null) return NotFound("Token not found.");
            return Ok(result);
        }

        #region Private Methods
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

        #endregion
    }
}
