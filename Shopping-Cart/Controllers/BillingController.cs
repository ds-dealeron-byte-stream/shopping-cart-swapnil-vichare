using Dealeron_ass.Service;
using Microsoft.AspNetCore.Mvc;

namespace Dealeron_ass.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingController : ControllerBase
    {
        private readonly Service.IDiscountService _discountService;

        public BillingController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("calculate")]
        public ActionResult<BillResponse> CalculateBill([FromBody] BillRequest request)
        {
            var finalAmount = _discountService.CalculateFinalAmount(request.CustomerType, request.PurchaseAmount);
            return Ok(new BillResponse { FinalAmount = finalAmount });
        }
    }
}
