using Application_Service.DTO_s.Payment_PayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentController(IPaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("ProcessPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentDto dto)
        {
            await _paymentManager.ProcessPayment(dto);
            return Created("","Payment Processed Successfully (mock integration)");
        }

        [HttpGet("FetchPayment/{paymentId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchPayment(Guid paymentId)
        {
            var result = await _paymentManager.FetchPayment(paymentId);

            if (result == null)
                return NotFound("Payment Not Found");

            return Ok(result);
        }
    }
}
