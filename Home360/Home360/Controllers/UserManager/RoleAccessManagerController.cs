using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers.UserManager
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleAccessManagerController : ControllerBase
    {
        private readonly IRoleAccessManagerService _roleAccessManager;

        public RoleAccessManagerController(IRoleAccessManagerService roleAccessManager)
        {
            _roleAccessManager = roleAccessManager;
        }

        [HttpPost]
        [Route("addRoleAccess")]
        public async Task<IActionResult> RegisterScreenAsync(RoleAccessManagerRequest roleAccessRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            string result = await _roleAccessManager.RegisterRoleAccessAsync(roleAccessRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllRoleAccess")]
        public async Task<List<RoleAccessManagerResponse>> GetAllScreensAsync()
        {
            return await _roleAccessManager.GetAllRoleAccessAsync();
        }
    }
}

