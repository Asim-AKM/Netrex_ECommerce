using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    /// <summary>
    /// Provides business logic for invoice-related operations such as
    /// generating invoices and retrieving invoice details.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="IInvoiceManager"/> and acts as an
    /// application service in the Payment and Payout module.
    /// 
    /// It follows Clean Architecture principles by interacting with the
    /// data layer through repository abstractions.
    /// </remarks>
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IRepository<Invoice> _genericrepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceManager"/> class.
        /// </summary>
        /// <param name="repository">
        /// Generic repository used for invoice persistence operations.
        /// </param>
        public InvoiceManager(IRepository<Invoice> repository)
        {
            _genericrepository = repository;
        }

        /// <summary>
        /// Retrieves an invoice by its unique identifier.
        /// </summary>
        /// <param name="InvoiceId">
        /// The unique identifier of the invoice to retrieve.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{FetchInvoiceDto}"/> containing invoice data
        /// when found; otherwise, returns a NotFound response.
        /// </returns>
        public async Task<ApiResponse<FetchInvoiceDto>> GetInvoiceById(Guid InvoiceId)
        {
            var fetchinvoice = await _genericrepository.GetById(InvoiceId);

            if (fetchinvoice == null)
            {
                return ApiResponse<FetchInvoiceDto>.Fail(
                    "Invoice not found",
                    ResponseType.NotFound);
            }

            var invoicedto = fetchinvoice.Map();

            return ApiResponse<FetchInvoiceDto>.Success(
                invoicedto,
                "Invoice retrieved successfully",
                ResponseType.Ok);
        }

        /// <summary>
        /// Generates a new invoice using the provided invoice data.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing invoice creation information.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{InvoiceDto}"/> indicating successful
        /// invoice creation.
        /// </returns>
        public async Task<ApiResponse<InvoiceDto>> GenerateInvoice(InvoiceDto dto)
        {
            var invoice = dto.Map();

            await _genericrepository.Create(invoice);
            await _genericrepository.SaveChangesAsync();

            return ApiResponse<InvoiceDto>.Success(
                dto,
                "Invoice generated successfully",
                ResponseType.Created);
        }
    }
}
