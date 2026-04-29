using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Home360.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    public class GroceryItemController : ControllerBase
    {
        private readonly IGroceryItemService _groceryItemService;

        public GroceryItemController(IGroceryItemService groceryItemService)
        {
            _groceryItemService = groceryItemService;
        }

        [HttpPost]
        [Route("addItem")]
        public async Task<IActionResult> RegisterItemAsync(GroceryItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _groceryItemService.RegisterItemAsync(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("updateInventory")]
        public async Task<IActionResult> UpdateInventoryAsync(GroceryItemRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");

            return Ok(await _groceryItemService.UpdateGroceryItemAsync(request));
        }

        [HttpGet]
        [Route("getAllItems")]
        public async Task<List<GroceryItemResponse>> GetAllItemsAsync()
        {
            return await _groceryItemService.GetAllItemsAsync();
        }
    }
}
