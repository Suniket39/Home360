using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserManagerController : ControllerBase
    {
        private readonly IUserManagerService _userManager;

        public UserManagerController(IUserManagerService userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }
            //Call Common Hadler for setiing userInfo
            string result = await _userManager.RegisterUserAsync(userRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("allUsers")]
        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            return await _userManager.GetAllUsersAsync();
        }
    }
}
