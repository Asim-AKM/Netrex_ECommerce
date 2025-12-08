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
            var sellerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var id = Guid.Parse(sellerId!);
             await _productServices.AddProduct(addProductDto, id);
            return Ok("Product Created Successfully");
        }
    }
}
