using Application_Service.DTO_s.ShopDetailsDtos;
using Application_Service.Services.SellerAndShopDetailsServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopDetailsController : ControllerBase
    {
        private readonly IShopDetailsManager _manager;

        public ShopDetailsController(IShopDetailsManager shopDetails)
        {
            _manager = shopDetails;
        }

        [HttpPost("CreateShopDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto)
        {
           var Data=await _manager.CreateShopDetails(createShopDetailsDto);
            return Ok(Data);
        }
        [HttpPut("UpdateShopDetails/{SellerId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto)
        {
          var Data=await _manager.UpdateShopDetails(updateShopDetailsDto);
          return Ok(Data);
        }
        [HttpDelete("DeleteShopDetails/{ShopDetailsId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteShopDetails(Guid ShopDetailsId)
        {
            bool Response=await _manager.DeleteShopDetails(ShopDetailsId);
            return Ok(Response);
        }
        [HttpGet("ShopDetailsId/{ShopDetailsId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdShopDetails(Guid ShopDetailsId)
        {
            var Data= await _manager.GetByIdShopDetails(ShopDetailsId);
            return Ok(Data);
        }
        [HttpGet("GetAllShopDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllShopDetails(GetAllShopDetailsDto getAllShopDetailsDto)
        {
            var Details = await _manager.GetAllShopDetails(getAllShopDetailsDto);
            return Ok(Details);
        }

    }
}
