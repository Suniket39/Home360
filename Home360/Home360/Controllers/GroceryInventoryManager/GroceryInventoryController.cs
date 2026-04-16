using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    public class GroceryInventoryController : ControllerBase
    {
        private readonly IGroceryInventoryService _groceryInventoryService;

        public GroceryInventoryController(IGroceryInventoryService groceryInventoryService)
        {
            _groceryInventoryService = groceryInventoryService;
        }

        [HttpPost]
        [Route("addInventory")]
        public async Task<IActionResult> RegisterInventoryAsync(GroceryInventoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _groceryInventoryService.RegisterInventoryAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllInventories")]
        public async Task<List<GroceryInventoryResponse>> GetAllCategoriesAsync()
        {
            return await _groceryInventoryService.GetAllInventoriesAsync();
        }
    }
}