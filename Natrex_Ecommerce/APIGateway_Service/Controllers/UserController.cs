using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _usermanager;
        public UserController(IUserManager usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            return Ok( await  _usermanager.UpdateUserAsync(dto));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _usermanager.DeleteUserAsync(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usermanager.GetAllUserAsync());
        }
    }
}
