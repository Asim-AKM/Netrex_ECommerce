using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomermanager _customermanager;
        public CustomerController(ICustomermanager customermanager)
        {
            _customermanager = customermanager;
        }

        
        [HttpPut("updateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerDto request)
        {
            await _customermanager.UpdateCustomer(request);
            return Ok();
        }
        [HttpDelete("deleteCustomer")]
        public async Task<IActionResult> DeleteCustomer( Guid id)
        {
            await _customermanager.DeleteCustomer(id);
            return Ok();
        }

        [HttpDelete("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer(Guid id)
        {
            await _customermanager.DeleteCustomer(id);
            return Ok();
        }


    }
}
