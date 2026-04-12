using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScreenMasterController : ControllerBase
    {
        private readonly IScreenMasterService _screenMasterService;

        public ScreenMasterController(IScreenMasterService screenMasterService)
        {
            _screenMasterService = screenMasterService;
        }

        [HttpPost]
        [Route("addScreen")]
        public async Task<IActionResult> RegisterScreenAsync(ScreenMasterRequest roleRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            // TODO common method for adding common entity model data
            string result = await _screenMasterService.RegisterScreenAsync(roleRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllScreens")]
        public async Task<List<ScreenMasterResponse>> GetAllScreensAsync()
        {
            return await _screenMasterService.GetAllScreensAsync();
        }
    }
}
