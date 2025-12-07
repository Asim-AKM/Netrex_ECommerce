using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAccountManger _useraccountservice;
        public UsersController(IUserAccountManger useraccountservice)
        {
            _useraccountservice = useraccountservice;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserRegisterDto dto)
        {
            return Ok(await _useraccountservice.CreateUserAsync(dto));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateUserDto dto)
        {
            return Ok(await _useraccountservice.UpdateUserAsync(dto));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _useraccountservice.DeleteUserAsync(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _useraccountservice.GetAllUserAsync());
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetbyUserId(Guid id)
        {
            return Ok(await _useraccountservice.GetUserbyId(id));
        }
    }
}
