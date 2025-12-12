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
        private readonly IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto addProductDto)
        {

            await _productServices.AddProduct(addProductDto);
            return Ok("Product Created Successfully");
        }
        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid productId)
        {
            var result = await _productServices.DeleteProduct(productId);
            if (result)
            {
                return Ok("Product Deleted Successfully");
            }
            return NotFound("Product Not Found");
        }
        [HttpGet("{GetByproductId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByProductId([FromRoute] Guid GetByproductId)
        {
            var product = await _productServices.GetByProductId(GetByproductId);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Product Not Found");
        }
    }
}
