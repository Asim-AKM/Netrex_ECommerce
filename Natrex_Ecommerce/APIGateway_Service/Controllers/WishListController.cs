namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class WishListController : ControllerBase
    {
        private readonly IWishListManager _wishListManager;
        public WishListController(IWishListManager wishListManager)
        {
            _wishListManager = wishListManager;
        }
        [HttpPost("WishListItem")]
        public async Task<IActionResult> CreateWishListItem(AddWishListItemDto request)
        {
            var response = await _wishListManager.AddWishListItem(request);
            return StatusCode((int)response.Status, response);
        }
        [HttpDelete("WishListItem/{wishListItemId}")]
        public async Task<IActionResult> DeleteWishListItem(Guid wishListItemId)
        {
            var response = await _wishListManager.DeleteWishListItem(wishListItemId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("WishListItem/{userId}")]
        public async Task<IActionResult> GetWishListItems(Guid userId)
        {
            var response = await _wishListManager.GetWishListItems(userId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("WishListCount/{userId}")]
        public async Task<IActionResult> GetWishListCount(Guid userId)
        {
            var response = await _wishListManager.GetWishListCount(userId);
            return StatusCode((int)response.Status, response);
        }

    }
}
