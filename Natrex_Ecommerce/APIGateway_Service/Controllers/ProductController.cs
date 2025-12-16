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
    }
}
