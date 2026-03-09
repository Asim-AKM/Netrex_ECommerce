namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _usermanager;
        public UserController(IUserManager usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto dto)
        {
            var response = await _usermanager.UpdateUserAsync(dto);
            return StatusCode((int)response.Status, response);
        }
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var response = await _usermanager.DeleteUserAsync(id);
            return StatusCode((int)response.Status, response);
        }
        [HttpGet("getall")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usermanager.GetAllUserAsync();
            return StatusCode((int)response.Status, response);
        }

        [HttpPut("updatestatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateUserStatusDto dto)
        {
            var response = await _usermanager.UpdateUserStatusAsync(dto);
            return StatusCode((int)response.Status, response);
        }
    }
}
