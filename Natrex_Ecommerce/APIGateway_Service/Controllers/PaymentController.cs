using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    /// <summary>
    /// Handles all payment-related API endpoints such as 
    /// processing payments and fetching payment details.
    /// </summary>
    /// <remarks>
    /// This controller acts as the entry point for payment operations 
    /// in the API Gateway. It communicates with 
    /// <see cref="IPaymentDetailManager"/> which contains the business logic.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentDetailManager _paymentManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentController"/>.
        /// </summary>
        /// <param name="paymentManager">
        /// The business logic service responsible for managing payment operations.
        /// </param>
        public PaymentController(IPaymentDetailManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        /// <summary>
        /// Processes a new payment request.
        /// </summary>
        /// <param name="dto">
        /// The payment data sent by the client (amount, orderId, method, etc.).
        /// </param>
        /// <returns>
        /// Returns <see cref="CreatedResult"/> if the payment is processed successfully.
        /// </returns>
        /// <response code="201">Payment processed successfully.</response>
        /// <response code="400">Invalid or missing payment data.</response>
        [HttpPost("ProcessPayment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentDto dto)
        {
            await _paymentManager.ProcessPayment(dto);

            return Created(
                string.Empty,
                "Payment Processed Successfully (mock integration)"
            );
        }

        /// <summary>
        /// Fetches payment details using a payment identifier.
        /// </summary>
        /// <param name="paymentId">The unique GUID of the payment record.</param>
        /// <returns>
        /// Returns the payment data if found; otherwise NotFound.
        /// </returns>
        /// <response code="200">Payment details retrieved successfully.</response>
        /// <response code="404">Payment not found.</response>
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
