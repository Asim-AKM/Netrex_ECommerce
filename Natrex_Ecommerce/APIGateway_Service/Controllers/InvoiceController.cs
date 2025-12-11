using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Service.Controllers
{
    /// <summary>
    /// API Controller for managing invoice-related endpoints.
    /// Provides actions to generate a new invoice and fetch an existing invoice.
    /// </summary>
    /// <remarks>
    /// This controller is part of the API Gateway layer in Clean Architecture.
    /// It uses <see cref="IInvoiceManager"/> from the application layer
    /// to perform business logic and mapping between DTOs and entities.
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceController"/> class.
        /// </summary>
        /// <param name="invoiceService">The service responsible for invoice operations.</param>
        public InvoiceController(IInvoiceManager invoiceService)
        {
            _invoiceService = invoiceService;
        }

        /// <summary>
        /// Generates a new invoice for a specific order.
        /// </summary>
        /// <param name="dto">The <see cref="InvoiceDto"/> containing order ID and total amount.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status201Created"/> if the invoice is successfully created.
        /// Returns <see cref="StatusCodes.Status400BadRequest"/> if the request is invalid.
        /// </returns>
        /// <remarks>
        /// This action maps the DTO to a domain entity, creates the invoice via the service layer,
        /// and returns a success message upon completion.
        /// </remarks>
        [HttpPost("GenerateInvoice")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GenerateInvoice([FromBody] InvoiceDto dto)
        {
            await _invoiceService.GenerateInvoice(dto);
            return Created("", "Invoice Created Successfully");
        }

        /// <summary>
        /// Fetches an existing invoice by its unique identifier.
        /// </summary>
        /// <param name="InvoiceId">The unique identifier of the invoice to fetch.</param>
        /// <returns>
        /// Returns <see cref="StatusCodes.Status200OK"/> with <see cref="FetchInvoiceDto"/> if the invoice exists.
        /// Returns <see cref="StatusCodes.Status404NotFound"/> if the invoice is not found.
        /// Returns <see cref="StatusCodes.Status400BadRequest"/> for invalid requests.
        /// </returns>
        /// <remarks>
        /// This action calls the application service to retrieve the invoice,
        /// maps it to a DTO, and returns it to the client.
        /// </remarks>
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
