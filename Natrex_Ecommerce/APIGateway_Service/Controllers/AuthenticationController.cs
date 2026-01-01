using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request)
        {
            var response = await _authenticationManager.CreateUserAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var response = await _authenticationManager.LoginAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("ForgetPassoword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // e.g identifier not found
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ForgetPassword([FromBody] string userIdentifier)
        {
            var response = await _authenticationManager.ForgetPasswordAsync(userIdentifier);
            return StatusCode((int)response.Status, response);
        }
        [HttpPost("ConfirmOtp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConfirmOtp(CheckOtpDto request)
        {
            var response = await _authenticationManager.ConfirmOtp(request);
            return StatusCode((int)response.Status,response);
        }
    }
}
