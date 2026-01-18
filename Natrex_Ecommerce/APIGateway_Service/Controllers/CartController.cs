using Application_Service.DTO_s.Cart_OrderDtos.CartDtos;
using Application_Service.Services.CartAndOrderModuleServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CartController : ControllerBase
    {

        private readonly ICartManager _cartManager;

        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }


        [HttpPost("Cart")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCart([FromBody] AddCartDto dto)
        {
            var response = await _cartManager.CreateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

        [HttpPut("Cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto dto)
        {
            var response = await _cartManager.UpdateAsync(dto);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("Cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart(Guid cartId)
        {
            var response = await _cartManager.DeleteAsync(cartId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("CartById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartById(Guid cartId)
        {
            var response = await _cartManager.GetByIdAsync(cartId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("Cart")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCarts()
        {
            var response = await _cartManager.GetAllAsync();
            return StatusCode((int)response.Status, response);
        }
    }
}

