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
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto addProductDto)
        {
             await _productManager.AddProduct(addProductDto);
            return Ok("Product Created Successfully");
        }

        [HttpPut("UpdateProduct/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTOS updateProductDto)
        {
            await _productManager.UpdateProduct(updateProductDto);
            return Ok("Product Updated Successfully");
        }
        //[HttpDelete("DeleteProduct/{ProductId:guid}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        //{
        //    var result = await _productManager.DeleteProduct(productId);
        //    //if (result)
        //    //{
        //    //    return Ok("Product Deleted Successfully");
        //    //}
        //    //return NotFound("Product Not Found");
        //}
        [HttpGet("GetProductById/{ProductId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByProductId([FromRoute] Guid GetByproductId)
        {
            var product = await _productManager.GetByProductId(GetByproductId);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Product Not Found");
        }
    }
}
