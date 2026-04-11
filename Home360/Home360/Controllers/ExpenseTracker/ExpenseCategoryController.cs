using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }

        [HttpPost]
        [Route("registerCategory")]
        public async Task<IActionResult> RegisterCategoryAsync(ExpenseCategoryRequest category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            // TODO common method for adding common entity model data
            string result = await _expenseCategoryService.RegisterCategoryAsync(category);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllCategories")]
        public async Task<List<ExpenseCategoryResponse>> GetAllCategoriesAsync()
        {
            return await _expenseCategoryService.GetAllCategoriesAsync();
        }
    }
}
