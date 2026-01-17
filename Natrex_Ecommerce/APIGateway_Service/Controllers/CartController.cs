using Application_Service.DTO_s.CartAndOrderDtos.CartDtos;
using Application_Service.Services.CartAndOrderModuleServices.CartServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }

        [HttpPost("CreateCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCart([FromBody] AddCartDto dto)
        {
            var response = await _cartManager.CreateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

        [HttpPut("UpdateCart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto dto)
        {
            var response = await _cartManager.UpdateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("DeleteCart/{cartId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCart(Guid cartId)
        {
            var response = await _cartManager.DeleteAsync(cartId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("GetCartById/{cartId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCartById(Guid cartId)
        {
            var response = await _cartManager.GetByIdAsync(cartId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("GetAllCarts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCarts()
        {
            var response = await _cartManager.GetAllAsync();
            return StatusCode((int)response.Status, response);
        }
    }
}

