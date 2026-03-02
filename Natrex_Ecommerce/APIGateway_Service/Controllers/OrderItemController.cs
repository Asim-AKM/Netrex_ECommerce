using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class OrderItemController(IOrderItemManager orderItemService) : ControllerBase
    { 
 
        [HttpGet("GetByOrder/{orderId}")]
        public async Task<IActionResult> GetByOrderId(Guid orderId)
        {
            var response = await orderItemService.GetOrderItemsByOrderId(orderId);
            return StatusCode((int)response.Status, response);
        }
    }
}
