using Azure;

namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class AdminSellerController : ControllerBase
    {
        private readonly IAdminSellerService _adminsellerservice;

        public AdminSellerController(IAdminSellerService adminsellerservice)
        {
            _adminsellerservice = adminsellerservice;
        }

        // GET: /api/admin/seller/pending
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingSellers()
        {
            var response = await _adminsellerservice.GetPendingSellersAsync();
            return StatusCode((int)response.Status, response);
        }

        // PUT: /api/admin/seller/approve/{sellerId}
        [HttpPut("approve")]
        public async Task<IActionResult> ApproveSeller(Guid sellerId)
        {
            var response = await _adminsellerservice.ApproveSellerAsync(sellerId);
            return StatusCode((int)response.Status, response);

        }

        // PUT: /api/admin/seller/reject/{sellerId}
        [HttpPut("reject")]
        public async Task<IActionResult> RejectSeller(Guid sellerId)
        {
            var response = await _adminsellerservice.RejectSellerAsync(sellerId);
            return StatusCode((int)response.Status, response);

        }

        // PUT: /api/admin/seller/suspend/{sellerId}
        [HttpPut("suspend")]
        public async Task<IActionResult> SuspendSeller(Guid sellerId)
        {
            var response = await _adminsellerservice.SuspendSellerAsync(sellerId);
            return StatusCode((int)response.Status, response);
        }
    }
}
