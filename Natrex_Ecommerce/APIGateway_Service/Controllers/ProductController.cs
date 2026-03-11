using Microsoft.AspNetCore.Authorization;

namespace APIGateway_Service.Controllers
{
    /// <summary>
    /// Handles all product-related API endpoints such as 
    /// creating, updating, deleting, and fetching product details.
    /// </summary>
    /// <remarks>
    /// This controller acts as the entry point for product operations
    /// in the API Gateway. It communicates with 
    /// <see cref="IProductManager"/> which contains the business logic.
    /// </remarks>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[Authorize(Roles = "Admin,Seller")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productmanager">The service responsible for product operations.</param>
        public ProductController(IProductManager productmanager, ILogger<ProductController> logger)
        {
            _productManager = productmanager;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="addProductDto">The product data to be added.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status201Created"/> if the product is successfully created.
        /// Returns <see cref="StatusCodes.Status400BadRequest"/> if the request is invalid.
        /// Returns <see cref="StatusCodes.Status500InternalServerError"/> if there is a server error.
        /// </returns>
        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto addProductDto)
        {
            var response = await _productManager.AddProduct(addProductDto);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Updates an existing product by its unique identifier.
        /// </summary>
        /// <param name="updateProductDto">The updated product data.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status200OK"/> if the update is successful.
        /// </returns>
        [HttpPut("UpdateProduct/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTOS updateProductDto)
        {
            var response = await _productManager.UpdateProduct(updateProductDto);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        /// <param name="productId">The GUID of the product to delete.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status200OK"/> if the product is deleted successfully.   
        /// Returns <see cref="StatusCodes.Status404NotFound"/> if the product does not exist.
        /// </returns>
        [HttpDelete("DeleteProduct/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            var response = await _productManager.DeleteProduct(productId);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Fetches a product by its unique identifier.
        /// </summary>
        /// <param name="GetByproductId">The GUID of the product to fetch.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status200OK"/> with product details if found.
        /// Returns <see cref="StatusCodes.Status404NotFound"/> if the product does not exist.
        /// </returns>
        [HttpGet("GetProductById/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByProductId([FromRoute] Guid GetByproductId)
        {
            var response = await _productManager.GetByProductId(GetByproductId);
            return StatusCode((int)response.Status, response);
        }
        [HttpGet("GetAllProducts/{SellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProducts([FromRoute] Guid SellerId)
        {
            var response = await _productManager.GetAllProducts(SellerId);
            return StatusCode((int)response.Status, response);

            //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            //if (!Guid.TryParse(userIdClaim, out var currentUserId))
            //{
            //    return StatusCode(StatusCodes.Status401Unauthorized, new ApiResponse<List<GetProductDto>>()
            //    {
            //        IsSuccess = false,
            //        Message = "Invalid user token",
            //        Status = ResponseType.Unauthorized
            //    });
            //}

            //if (User.IsInRole("Admin"))
            //{
            //    var response = await _productManager.GetAllProducts(SellerId);
            //    return StatusCode((int)response.Status, response);
            //}

            //if (currentUserId == SellerId)
            //{
            //    var response = await _productManager.GetAllProducts(SellerId);
            //    return StatusCode((int)response.Status, response);
            //}

            //_logger.LogWarning("User {UserId} tried to access products of seller {TargetSellerId}",
            //    currentUserId, SellerId);

            //return StatusCode(StatusCodes.Status403Forbidden, new ApiResponse<List<GetProductDto>>()
            //{
            //    IsSuccess = false,
            //    Message = "You are not authorized to access this resource.",
            //    Status = ResponseType.Forbidden
            //});
        }
        [HttpGet("GetAllProvinces")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllProvinces()
        {
            var response = await _productManager.GetAllProvinces();
            return StatusCode((int)response.Status, response);
        }
        [HttpGet("GetCitiesByProvinceId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCitiesByProvinceId(Guid Id)
        {
            var response = await _productManager.GetCitiesByProvinceId(Id);
            return StatusCode((int)response.Status, response);
        }

    }
}
