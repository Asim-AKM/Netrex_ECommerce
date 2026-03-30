using Application_Service.DTO_s.ChatBotDtos;
using Application_Service.Services.ChatBotService.Interfaces;

namespace ECommerce.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // [Authorize]   
    public class ChatController : ControllerBase
    {
        private readonly IChatManager _chatManager;

        public ChatController(IChatManager chatManager)
        {
            _chatManager = chatManager;
        }

        [HttpPost("send")]
        public async Task<ActionResult<ApiResponse<ChatResponseDto>>> SendMessage([FromBody] ChatRequest request)
        {
            // 👇 GUID UserId - filhaal temporary, baad mein claims se Get Karun gaa
            var userId = Guid.NewGuid();  // Ye temporary hai, har request pe naya user banega

            // Jab authorization implement karoge to ye use karun gaa
            // var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            // if (string.IsNullOrEmpty(userIdClaim))
            //     return Unauthorized(ApiResponse<ChatResponseDto>.Fail("User not authenticated", ResponseType.Unauthorized));
            // var userId = Guid.Parse(userIdClaim);

            var response = await _chatManager.ProcessMessageAsync(userId, request.Message);

            // Return appropriate HTTP status code based on ResponseType
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("history/{userId}")]
        public async Task<ActionResult<ApiResponse<object>>> GetChatHistory(Guid userId)
        {
            // Ye endpoint aapko alag se implement karna hoga agar chahiye to
            // Filhaal ke liye simple response return kar rahe hain
            return Ok(ApiResponse<object>.Success(null, "History endpoint - to be implemented"));
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }
}