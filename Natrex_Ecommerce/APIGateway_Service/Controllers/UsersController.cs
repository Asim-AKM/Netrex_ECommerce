using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UsersController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(UserRegisterDto dto)
        {
            return Ok(await _userAccountService.CreateUserAsync(dto));

        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {
            return Ok(await _userAccountService.UpdateUserAsync(dto));

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await _userAccountService.DeleteUserAsync( id));
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _userAccountService.GetUsersAsync());
        }
    }
}
