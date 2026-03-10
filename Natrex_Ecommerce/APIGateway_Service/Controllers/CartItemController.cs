namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemManager _manager;

        public CartItemController(ICartItemManager manager)
        {
            _manager = manager;
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCartItem([FromBody] AddCartItemDto dto)
        {
            //var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(UserId))
            //{
            //    return Unauthorized();
            //}
            var response = await _manager.CreateAsync(dto,Guid.Parse("da5cf415-5301-441f-ab18-e14a81734e73"));
            return StatusCode((int)response.Status, response);
        }
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCartItems()
        {
            //var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (string.IsNullOrEmpty(UserId))
            //{
            //    return Unauthorized();
            //}
            var response = await _manager.GetAllAsync(Guid.Parse("da5cf415-5301-441f-ab18-e14a81734e73"));
            return StatusCode((int)response.Status, response);
        }
        [HttpPut("IncreaseQuantity/{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> IncreaseQuantity(Guid cartItemId)
        {
            var response = await _manager.IncreaseQuantityAsync(cartItemId);
            return StatusCode((int)response.Status, response);
        }
        [HttpPut("DecreaseQuantity/{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DecreaseQuantity(Guid cartItemId)
        {
            var response = await _manager.DecreaseQuantityAsync(cartItemId);
            return StatusCode((int)response.Status, response);
        }
        [HttpDelete("{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCartItem(Guid cartItemId)
        {
            var response = await _manager.DeleteAsync(cartItemId);
            return StatusCode((int)response.Status, response);
        }
    }
}
