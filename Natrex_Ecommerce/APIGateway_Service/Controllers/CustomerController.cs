using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customermanager;
        public CustomerController(ICustomerManager customermanager)
        {
            _customermanager = customermanager;
        }

        [HttpPut("updateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDto request)
        {
            var response = await _customermanager.UpdateCustomer(request);
            return StatusCode((int)response.Status, response);
        }
        [HttpDelete("deleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var respone = await _customermanager.DeleteCustomer(id);
            return StatusCode((int)respone.Status, respone);
        }

        [HttpDelete("getAllCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response = await _customermanager.GetAllCustomers();
            return StatusCode((int)response.Status, response);
        }


    }
}
