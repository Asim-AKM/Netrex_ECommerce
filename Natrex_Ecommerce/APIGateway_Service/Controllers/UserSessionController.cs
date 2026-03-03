using Application_Service.Services.UserManagmentServices.Interface;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserSessionController : ControllerBase
    {
        private readonly IUserSessionManager _userSessionManager;
        public UserSessionController(IUserSessionManager userSessionManager)
        {
            _userSessionManager = userSessionManager;
        }
       
        [HttpGet("GetRefreshJwtToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var response = _userSessionManager.RefreshJwtToken(refreshToken);
            return StatusCode((int)response.Status, response);
        }

    }
}
