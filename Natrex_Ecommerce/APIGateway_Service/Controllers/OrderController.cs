namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class OrderController(IOrderManager orderService) : ControllerBase
    {
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)] // special case
        public async Task<IActionResult> Create([FromBody] PaymentDetailDto paymentDetailDto)
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(UserId))
            {
                return Unauthorized();
            }
            var response = await orderService.CreateOrderAsync(Guid.Parse(UserId),paymentDetailDto);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Cancel(Guid orderId)
        {
            var response = await orderService.CancelOrderAsync(orderId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(Guid orderId)
        {
            var response = await orderService.GetOrderByIdAsync(orderId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetByCustomer()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(UserId))
            {
                return Unauthorized();
            }
            var response = await orderService.GetOrdersByCustomerIdAsync(Guid.Parse(UserId));
            return StatusCode((int)response.Status, response);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderDto request)
        {
            var response = await orderService.UpdateOrderStatusAsync(request);
            return StatusCode((int)response.Status, response);
        }
    }
}
