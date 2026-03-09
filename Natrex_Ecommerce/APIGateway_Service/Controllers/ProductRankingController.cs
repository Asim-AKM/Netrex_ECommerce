namespace APIGateway_Service.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ProductRankingController : ControllerBase
    {
        private readonly IProductRankingManager _rankingManager;
        private readonly IProductManager _productManager;
        public ProductRankingController(IProductRankingManager rankingManager, IProductManager productManager)
        {
            _rankingManager = rankingManager;
            _productManager = productManager;
        }
        [HttpGet("best-sellers")]
        public async Task<IActionResult> GetBestSellers()
        {
            var response = await _rankingManager.GetBestSellersAsync();
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("trending")]
        public async Task<IActionResult> GetTrending()
        {
            var response = await _rankingManager.GetTrendingAsync();
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated()
        {
            var response = await _rankingManager.GetTopRatedAsync();
            return StatusCode((int)response.Status, response);
        }

        [HttpGet("homepage")]
        public async Task<IActionResult> GetHomepage([FromQuery] Guid? categoryid,[FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
        {
            var response = await _rankingManager.GetHomepageProductsAsync(categoryid, pageNumber, pageSize);
            return StatusCode((int)response.Status, response);
        }
        [HttpGet("new-arrivals")]
        public async Task<IActionResult> GetNewArrivals()
        {
            var response = await _rankingManager.GetNewArrivalsAsync();
            return StatusCode((int)response.Status, response);
        }
        [HttpGet("GetProductCategory")]
        public async Task<IActionResult> GetProductCategories()
        {
            var response = await _productManager.GetCategoriesAsync();
            return StatusCode((int)response.Status, response);
        }
    }
}
