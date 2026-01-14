using Application_Service.DTO_s.CartAndOrderDtos.OrderDtos;
using Application_Service.Services.CartAndOrderModuleServices.OrderServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class OrderController(IOrderService orderService) : ControllerBase
    {
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)] // special case
        public async Task<IActionResult> Create([FromBody] AddOrderDto request)
        {
            var response = await orderService.CreateOrderAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("Cancel/{orderId}")]
        public async Task<IActionResult> Cancel(Guid orderId)
        {
            var response = await orderService.CancelOrderAsync(orderId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("GetById/{orderId}")]
        public async Task<IActionResult> GetById(Guid orderId)
        {
            var response = await orderService.GetOrderByIdAsync(orderId);
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("GetByCustomer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(Guid customerId)
        {
            var response = await orderService.GetOrdersByCustomerIdAsync(customerId);
            return StatusCode((int)response.Status, response);
        }

        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderDto request)
        {
            var response = await orderService.UpdateOrderStatusAsync(request);
            return StatusCode((int)response.Status, response);
        }
    }
}
