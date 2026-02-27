using Application_Service.DTO_s.UserManagmentDto_s.UserSessionDto_s;
using Application_Service.DTO_s.UserManagmentDto_s.WishList;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

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
            var response = _wishListManager.AddWishListItem(request);
            return StatusCode((int)response.Status, response);
        }
        [HttpDelete("WishListItem")]
        public async Task<IActionResult> DeleteWishListItem(DeleteWishListItemDto request)
        {
            var response = _wishListManager.DeleteWishListItem(request);
            return StatusCode((int)response.Status, response);
        }

    }
}
