using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _sellerPayoutService.CreateSellerPayout(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("GetSellerPayoutById/{sellerPayoutId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSellerPayoutById([FromRoute] Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutService.GetSellerPayoutById(sellerPayoutId);
            return StatusCode((int)payout.Status, payout);
        }

        [HttpPut("UpdateSellerPayoutAsPaid/{sellerPayoutId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSellerPayoutAsPaid([FromRoute] Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutService.UpdateSellerPayoutAsPaid(sellerPayoutId);
            return StatusCode((int)payout.Status, payout);
        }
    }
}
