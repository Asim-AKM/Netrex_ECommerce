using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
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
