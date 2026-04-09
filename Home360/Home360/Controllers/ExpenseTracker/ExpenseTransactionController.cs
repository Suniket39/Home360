using Home360.API.Core.Auth;
using Home360.Application.DTOs;
using Home360.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenseTransactionController : ControllerBase
    {
        private readonly IExpenseTransactionService _expenseTransactionService;

        public ExpenseTransactionController(IExpenseTransactionService expenseTransactionService)
        {
            _expenseTransactionService = expenseTransactionService;
        }

        [HttpPost]
        [Route("addExpense")]
        public async Task<IActionResult> RegisterCategoryAsync(ExpenseTransactionRequest tranRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            // TODO common method for adding common entity model data
            string result = await _expenseTransactionService.RegisterTransactionAsync(tranRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllExpenses")]
        public async Task<List<ExpenseTransactionResponse>> GetAllTransactionsAsync()
        {
            return await _expenseTransactionService.GetAllTransactionsAsync();
        }
    }
}
