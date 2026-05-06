using Home360.Application.DTOs;
using Home360.Application.Interfaces.Services.BillTracker;
using Microsoft.AspNetCore.Mvc;

namespace Home360.API.Controllers.BillsTracker
{
    public class BillsController : ControllerBase
    {
        private readonly IBillsService _billsService;

        public BillsController(IBillsService billsService)
        {
            _billsService = billsService;
        }

        [HttpPost]
        [Route("addBill")]
        public async Task<IActionResult> RegisterBillAsync(BillRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _billsService.RegisterBillAsync(request);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateBill")]
        public async Task<IActionResult> UpateBillAsync(BillRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Model");
            }

            string result = await _billsService.UpdateBillAsync(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllBills")]
        public async Task<List<BillResponse>> GetAllBillsAsync()
        {
            return await _billsService.GetAllBillsAsync();
        }
    }
}