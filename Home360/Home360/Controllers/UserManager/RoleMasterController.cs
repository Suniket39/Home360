using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleMasterController : ControllerBase
    {
        private readonly IRoleMasterService _roleMasterService;

        public RoleMasterController(IRoleMasterService roleMasterService)
        {
            _roleMasterService = roleMasterService;
        }

        [HttpPost]
        [Route("addRole")]
        public async Task<IActionResult> RegisterRoleAsync(RoleMasterRequest roleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            // TODO common method for adding common entity model data
            string result = await _roleMasterService.RegisterRoleAsync(roleRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllRoles")]
        public async Task<List<RoleMasterResponse>> GetAllRolesAsync()
        {
            return await _roleMasterService.GetAllRolesAsync();
        }
    }
}
