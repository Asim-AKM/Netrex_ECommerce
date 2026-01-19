using Application_Service.DTO_s.CartAndOrderDtos.CartItemDtos;
using Application_Service.Services.CartAndOrderModuleServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemManager _cartItemManager;

        public CartItemController(ICartItemManager cartItemManager)
        {
            _cartItemManager = cartItemManager;
        }

        
        [HttpPost("CartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCartItem(AddCartItemDto dto)
        {
            var response = await _cartItemManager.CreateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

       
        [HttpGet("CartItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartItemById(Guid cartItemId)
        {
            var response = await _cartItemManager.GetByIdAsync(cartItemId);
            return StatusCode((int)response.Status, response);
        }

        
        [HttpGet("CartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCartItems()
        {
            var response = await _cartItemManager.GetAllAsync();
            return StatusCode((int)response.Status, response);
        }

        
        [HttpPut("CartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemDto dto)
        {
            var response = await _cartItemManager.UpdateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

        
        [HttpDelete("CartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCartItem(Guid cartItemId)
        {
            var response = await _cartItemManager.DeleteAsync(cartItemId);
            return StatusCode((int)response.Status, response);
        }

        
        [HttpGet("CartItemByCartAndProductId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCartAndProduct(Guid cartId, Guid productId)
        {
            var response = await _cartItemManager.GetByCartAndProductAsync(cartId, productId);
            return StatusCode((int)response.Status, response);
        }
    }
}
