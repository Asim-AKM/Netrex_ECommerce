using Application_Service.Services.ProductManagementService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRankingController : ControllerBase
    {
        private readonly IProductRankingManager _rankingManager;
        public ProductRankingController(IProductRankingManager rankingManager)
        {
            _rankingManager = rankingManager;
        }
        [HttpGet("best-sellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var result = await _rankingManager.GetBestSellersAsync();
            return Ok(result);
        }

        [HttpGet("trending")]
        public async Task<IActionResult> GetTrending()
        {
            var result = await _rankingManager.GetTrendingAsync();
            return Ok(result);
        }

        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated()
        {
            var result = await _rankingManager.GetTopRatedAsync();
            return Ok(result);
        }

        [HttpGet("homepage")]
        public async Task<IActionResult> GetHomepage()
        {
            var result = await _rankingManager.GetHomepageProductsAsync();
            return Ok(result);
        }

        [HttpGet("new-arrivals")]
        public async Task<IActionResult> GetNewArrivals()
        {
            var result = await _rankingManager.GetNewArrivalsAsync();
            return Ok(result);
        }
    }
}
