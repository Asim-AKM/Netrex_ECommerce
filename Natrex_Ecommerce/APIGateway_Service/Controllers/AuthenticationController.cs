using Application_Service.DTO_s.UserManagmentDto_s;
using Application_Service.DTO_s.UsersDto.Accounts;
using Application_Service.Services.UserManagmentServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthenticationManager authenticationManager, ILogger<AuthenticationController> logger)
        {
            _authenticationManager = authenticationManager;
            _logger = logger;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] CreateUserDto request)
        {
            _logger.LogInformation("Register Endpoint hit for Email: {Email}", request.Email);
            var response = await _authenticationManager.CreateUserAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            _logger.LogInformation("Login endpoint hit for Identifier: {UserIdentifier}", request.UserIdentifier);
            var response = await _authenticationManager.LoginAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("ForgetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // e.g identifier not found
        public async Task<IActionResult> ForgetPassword([FromBody] UserIdentifierDto request)
        {
            var response = await _authenticationManager.ForgetPasswordAsync(request.UserIdentifier);
            return StatusCode((int)response.Status, response);
        }
        [HttpPost("ConfirmOtp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConfirmOtp([FromBody] CheckOtpDto request)
        {
            var response = await _authenticationManager.ConfirmOtp(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("VerifyEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyRegistrationOtpDto request)
        {
            var response = await _authenticationManager.VerifyRegistrationOtpAsync(request);
            return StatusCode((int)response.Status, response);
        }

        [HttpPost("ResendOtp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ResendOtp([FromBody] EmailDto request)
        {
            var response = await _authenticationManager.ResendRegistrationOtpAsync(request.Email);
            return StatusCode((int)response.Status, response);
        }

        [HttpDelete("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Logout([FromBody] string refreshToken)
        {
            var response = await _authenticationManager.LogoutAsync(refreshToken);
            return StatusCode((int)response.Status, response);

        }
    }
}
