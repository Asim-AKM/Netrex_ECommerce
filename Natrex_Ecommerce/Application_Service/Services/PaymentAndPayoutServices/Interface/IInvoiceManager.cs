using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.PaymentAndPayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    /// <summary>
    /// Defines contract for managing invoice-related operations
    /// in the application layer.
    /// </summary>
    /// <remarks>
    /// This interface belongs to the Application layer in Clean Architecture.
    /// Implementations are responsible for handling business logic
    /// related to invoice creation and retrieval.
    /// </remarks>
    public interface IInvoiceManager
    {
        /// <summary>
        /// Generates a new invoice based on the provided invoice data.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing invoice creation details.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{InvoiceDto}"/> indicating successful
        /// invoice creation.
        /// </returns>
        /// <remarks>
        /// The implementation should map the DTO to a domain entity,
        /// persist it using a repository, and commit changes.
        /// </remarks>
        Task<ApiResponse<InvoiceDto>> GenerateInvoice(InvoiceDto dto);

        /// <summary>
        /// Retrieves an invoice by its unique identifier.
        /// </summary>
        /// <param name="InvoiceId">
        /// The unique identifier of the invoice.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{FetchInvoiceDto}"/> containing invoice data
        /// if found; otherwise, returns a NotFound response.
        /// </returns>
        /// <remarks>
        /// The implementation should retrieve the invoice from the repository,
        /// map it to a DTO, and handle cases where the invoice does not exist.
        /// </remarks>
        Task<ApiResponse<FetchInvoiceDto>> GetInvoiceById(Guid InvoiceId);
    }
}
