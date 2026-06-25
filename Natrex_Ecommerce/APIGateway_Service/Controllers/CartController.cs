using Application_Service.DTO_s.CartDtos;
using Application_Service.Services.Cartservices.Interface;
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
        public async Task<IActionResult> CreateCart(AddCartDto dto)
        {
            await _cartManager.AddCart(dto);
            return Ok(dto);
        }

        [HttpPut("UpdateCart/{CartId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto dto)
        {
            await _cartManager.UpdateCart(dto);
            return Ok(dto);
        }

        [HttpDelete("RemoveCart/{CartId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveCart(Guid CartId)
        {
            await _cartManager.RemoveCart(CartId);
            return Ok();
        }

        [HttpGet("GetCartById/{CartId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCartById(Guid cartid)
        {
            var data= await _cartManager.GetCartById(cartid);
            if(data != null)
            {
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
