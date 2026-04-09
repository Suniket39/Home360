using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseCategoryTypeController : ControllerBase
    {
        private readonly IExpenseTypeService _typeService;

        public ExpenseCategoryTypeController(IExpenseTypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost]
        [Route("registerType")]
        public async Task<IActionResult> RegisterCategoryAsync(ExpenseTypeRequest type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            // TODO common method for adding common entity model data
            string result = await _typeService.RegisterTypesAsync(type);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllCategoryTypes")]
        public async Task<List<ExpenseTypeResponse>> GetAllCategoriesAsync()
        {
            return await _typeService.GetAllTypesAsync();
        }
    }
}
