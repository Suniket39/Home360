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

            string result = await _expenseCategoryService.RegisterCategoryAsync(category);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateCategory")]
        public async Task<IActionResult> UpdateMonthlyCartAsync(ExpenseCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }
            return Ok(await _expenseCategoryService.UpdateCategoryAsync(request));
        }

        [HttpGet]
        [Route("getAllCategories")]
        public async Task<List<ExpenseCategoryResponse>> GetAllCategoriesAsync()
        {
            return await _expenseCategoryService.GetAllCategoriesAsync();
        }
    }
}
