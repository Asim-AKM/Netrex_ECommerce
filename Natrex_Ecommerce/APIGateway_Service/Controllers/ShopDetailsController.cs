using Application_Service.DTO_s.ShopDetailsDtos;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    /// <summary>
    /// Handles all ShopDetails-related API operations such as creation, updating, deletion, and fetching shop detail records.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShopDetailsController : ControllerBase
    {
        private readonly IShopDetailsManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopDetailsController"/> class.
        /// </summary>
        /// <param name="shopDetails">Service layer interface for shop details operations.</param>
        public ShopDetailsController(IShopDetailsManager shopDetails)
        {
            _manager = shopDetails;
        }

        /// <summary>
        /// Creates a new shop detail record.
        /// </summary>
        /// <param name="createShopDetailsDto">The shop details data required for creation.</param>
        /// <returns>Returns the created shop detail data.</returns>
        /// <response code="200">Shop details successfully created.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("CreateShopDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto)
        {
            var data = await _manager.CreateShopDetails(createShopDetailsDto);
            return StatusCode((int)data.Status, data);
        }

        /// <summary>
        /// Updates an existing shop detail record.
        /// </summary>
        /// <param name="updateShopDetailsDto">Updated shop details data.</param>
        /// <returns>Returns the updated shop detail information.</returns>
        /// <response code="200">Shop details successfully updated.</response>
        /// <response code="400">Invalid shop details data.</response>
        /// <response code="404">Shop detail not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("UpdateShopDetails/{SellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto)
        {
            var data = await _manager.UpdateShopDetails(updateShopDetailsDto);
            return StatusCode((int)data.Status, data);
        }

        /// <summary>
        /// Deletes an existing shop detail by its unique ShopDetailsId.
        /// </summary>
        /// <param name="ShopDetailsId">Unique identifier of the shop detail to delete.</param>
        /// <returns>Returns 200 if deleted successfully.</returns>
        /// <response code="200">Shop detail successfully deleted.</response>
        /// <response code="400">Invalid shop detail ID.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("DeleteShopDetails/{ShopDetailsId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteShopDetails(Guid ShopDetailsId)
        {
            var data = await _manager.DeleteShopDetails(ShopDetailsId);
            return StatusCode((int)data.Status, data);
        }

        /// <summary>
        /// Retrieves a shop detail by its unique ShopDetailsId.
        /// </summary>
        /// <param name="ShopDetailsId">Unique identifier of the shop detail.</param>
        /// <returns>Returns shop detail data if found, otherwise an error response.</returns>
        /// <response code="200">Shop detail found.</response>
        /// <response code="404">Shop detail not found.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("ShopDetailsId/{ShopDetailsId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdShopDetails(Guid ShopDetailsId)
        {
            var data = await _manager.GetByIdShopDetails(ShopDetailsId);
            return StatusCode((int)data.Status, data);
        }

        /// <summary>
        /// Retrieves a list of all shop details.
        /// </summary>
        /// <returns>Returns a list of shop details if found, otherwise an error response.</returns>
        /// <response code="200">Shop details found.</response>
        /// <response code="404">No shop details found.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("GetAllShopDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllShopDetails()
        {
            var details = await _manager.GetAllShopDetails();
            return StatusCode((int)details.Status, details);
        }
    }
}
