using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceService;
        public InvoiceController(IInvoiceManager invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("GenerateInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateInvoice( [FromBody] InvoiceDto dto)
        {
            await _invoiceService.GenerateInvoice(dto);
            return Created("","Invoice Created Successfully");
        }

        [HttpGet("FetchInvoice/{InvoiceId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> FetchInvoice(Guid InvoiceId)
        {
            var fetchinvoice = await _invoiceService.FetchInvoice(InvoiceId);
            if (fetchinvoice == null)
            {
                return NotFound("Invoice Not Found");
            }
            return Ok(fetchinvoice);
        }
    }
}
