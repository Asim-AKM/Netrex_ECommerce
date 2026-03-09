namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductViewController : ControllerBase
    {
        private readonly IProductViewManager _productViewManager;
        public ProductViewController(IProductViewManager productViewManager)
        {
            _productViewManager = productViewManager;
        }
        [HttpPost("ProductView")]
        public async Task<IActionResult> AddView(AddProductViewDto dto)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var updatedDto = dto with { IPAddress = ip };
            return Ok(await _productViewManager.AddViewAsync(updatedDto));
        }
    }
}
