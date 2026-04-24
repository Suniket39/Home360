using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers.GroceryInventoryManager
{
    public class MonthlyCartController : ControllerBase
    {
        private readonly IMonthlyCartService _monthlyCartService;

        public MonthlyCartController(IMonthlyCartService monthlyCartService)
        {
            _monthlyCartService = monthlyCartService;
        }

        [HttpPost]
        [Route("addCart")]
        public async Task<IActionResult> RegisterMonthlyCartAsync(MonthlyCartRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _monthlyCartService.RegisterMonthlyCartAsync(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("addCart")]
        public async Task<IActionResult> UpdateMonthlyCartAsync(MonthlyCartRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _monthlyCartService.UpdateMonthlyCartAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllMonthlyCart")]
        public async Task<List<MonthlyCartResponse>> GetAllMonthlyCartAsync()
        {
            return await _monthlyCartService.GetAllMonthlyCartAsync();
        }
    }
}

