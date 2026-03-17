using Microsoft.AspNetCore.Authorization;

namespace APIGateway_Service.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customermanager;
        public CustomerController(ICustomerManager customermanager)
        {
            _customermanager = customermanager;
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("updateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDto request)
        {
            var response = await _customermanager.UpdateCustomer(request);
            return StatusCode((int)response.Status, response);
        }

        [Authorize(Roles ="Customer")]
        [HttpDelete("deleteCustomer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var respone = await _customermanager.DeleteCustomer(id);
            return StatusCode((int)respone.Status, respone);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customermanager.GetAllCustomers();
            return StatusCode((int)response.Status, response);
        }

        [Authorize(Roles ="Customer")]
        [HttpPost("updateProfileImage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProfileImage(IFormFile File, [FromForm] Guid UserId)
        {
            if (File == null || File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            try
            {
                var response = await _customermanager.UpdateProfileImage(UserId, File);
                return StatusCode((int)response.Status, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal server error", Error = ex.Message });
            }
        }
    }
}
