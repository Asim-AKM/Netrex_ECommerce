using Application_Service.DTO_s.SellerDtos;
using Application_Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    /// <summary>
    /// Handles all Seller-related API operations such as creation, updating, deletion, and fetching seller data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerManager _sellerManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerController"/> class.
        /// </summary>
        /// <param name="sellerManager">Service layer interface for seller operations.</param>
        public SellerController(ISellerManager sellerManager)
        {
            _sellerManager = sellerManager;
        }

        /// <summary>
        /// Creates a new seller record.
        /// </summary>
        /// <param name="dto">The seller data required for creation.</param>
        /// <returns>Returns the created seller data.</returns>
        /// <response code="200">Seller successfully created.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("CreateSeller")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSeller([FromBody] CreateSellerDto dto)
        {
            var response = await _sellerManager.InsertSeller(dto);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Updates an existing seller record.
        /// </summary>
        /// <param name="dto">Updated seller data.</param>
        /// <returns>Returns the updated seller information.</returns>
        /// <response code="200">Seller successfully updated.</response>
        /// <response code="400">Invalid seller data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("UpdateSeller/{sellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSeller([FromBody] UpdateSellerDto dto)
        {
            var response = await _sellerManager.UpdateSeller(dto);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Deletes an existing seller using SellerId.
        /// </summary>
        /// <param name="sellerId">Unique identifier of the seller to delete.</param>
        /// <returns>Returns 200 if deleted successfully.</returns>
        /// <response code="200">Seller successfully deleted.</response>
        /// <response code="400">Invalid seller ID.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("DeleteSeller/{sellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSeller(Guid sellerId)
        {
            var response = await _sellerManager.DeleteSeller(sellerId);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Retrieves a seller by its unique SellerId.
        /// </summary>
        /// <param name="sellerId">Unique identifier of the seller.</param>
        /// <returns>Returns seller data if found, otherwise an error response.</returns>
        /// <response code="200">Seller found.</response>
        /// <response code="404">Seller not found.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("GetSellerById/{sellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSellerById(Guid sellerId)
        {
            var response = await _sellerManager.GetSellerById(sellerId);
            return StatusCode((int)response.Status, response);
        }

        /// <summary>
        /// Retrieves all sellers.
        /// </summary>
        /// <returns>Returns a list of all sellers.</returns>
        /// <response code="200">Sellers list retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("GetAllSellers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSellers()
        {
            var response = await _sellerManager.GetAllSellerList();
            return StatusCode((int)response.Status, response);
        }
    }
}
