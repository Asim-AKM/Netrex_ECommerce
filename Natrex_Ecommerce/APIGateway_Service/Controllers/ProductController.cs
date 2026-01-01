using Application_Service.DTO_s.ProductDTOS;
using Application_Service.Services.ProductManagementService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productmanager)
        {
            _productManager = productmanager;
        }
        
        [HttpPost("CreateProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto addProductDto)
        {
            var response =  await _productManager.AddProduct(addProductDto);
            return StatusCode((int)response.Status, response);
        }

        [HttpPut("UpdateProduct/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTOS updateProductDto)
        {
           var response =  await _productManager.UpdateProduct(updateProductDto);
            return StatusCode((int)response.Status,response);
        }
        [HttpDelete("DeleteProduct/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            var response = await _productManager.DeleteProduct(productId);
           
            return StatusCode((int)response.Status,response);
        }
        [HttpGet("GetProductById/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByProductId([FromRoute] Guid GetByproductId)
        {
            var response = await _productManager.GetByProductId(GetByproductId);
            return StatusCode((int)response.Status, response);
        }
    }
}
