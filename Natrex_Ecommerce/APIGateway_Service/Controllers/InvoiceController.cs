using Application_Service.DTO_s.Payment_PayoutDtos;
using Application_Service.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("GenerateInvoice")]
        public async Task<IActionResult> GenerateInvoice( [FromBody] InvoiceDto dto)
        {
            await _invoiceService.GenerateInvoice(dto);
            return Ok("Invoice created successfully");
        }

        [HttpGet("FetchInvoice/{InvoiceId}")]
        public async Task<IActionResult> FetchInvoice(Guid InvoiceId)
        {
            var fetchinvoice = await _invoiceService.FetchInvoice(InvoiceId);
            if (fetchinvoice == null)
            {
                return NotFound("Invoice not found");
            }
            return Ok(fetchinvoice);
        }
    }
}
