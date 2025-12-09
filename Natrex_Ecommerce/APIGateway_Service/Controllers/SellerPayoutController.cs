using Application_Service.DTO_s.Payment_PayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerPayoutController : ControllerBase
    {
        private readonly ISellerPayoutManager _sellerPayoutService;
        public SellerPayoutController(ISellerPayoutManager sellerPayoutService)
        {
            _sellerPayoutService = sellerPayoutService;
        }

        [HttpPost("CreateSellerPayout")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSellerPayout([FromBody] AddSellerPayoutDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _sellerPayoutService.CreateSellerPayout(request);
            return Created("", "Seller Payout Created Successfully");
        }

        [HttpGet("GetSellerPayoutById/{sellerPayoutId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSellerPayoutById([FromRoute] Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutService.GetSellerPayoutById(sellerPayoutId);
            if (payout == null)
            {
                return NotFound();
            }
            return Ok(payout);
        }

        [HttpPut("UpdateSellerPayoutAsPaid/{sellerPayoutId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSellerPayoutAsPaid([FromRoute] Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutService.GetSellerPayoutById(sellerPayoutId);
            if (payout == null)
            {
                return NotFound();
            }
            await _sellerPayoutService.UpdateSellerPayoutAsPaid(sellerPayoutId);
            return Ok("Seller Payout Updated As Paid Successfully");
        }
    }
}
