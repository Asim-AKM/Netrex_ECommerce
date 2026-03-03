using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductReviewManager _productReviewManager;
        public ProductReviewController(IProductReviewManager productReviewManager)
        {
            _productReviewManager = productReviewManager;
        }
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] AddProductReviewsDto dto)
        {
            var result = await _productReviewManager.AddReviewAsync(dto);
            return Ok(result);
        }
    }
}
