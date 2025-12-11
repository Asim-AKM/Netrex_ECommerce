using Application_Service.DTO_s.PaymentAndPayoutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    /// <summary>
    /// Interface for managing invoice operations in the application layer.
    /// Provides methods to generate new invoices and fetch existing invoices.
    /// </summary>
    /// <remarks>
    /// Part of the Application layer in Clean Architecture.
    /// Implementations of this interface should handle all business logic
    /// related to invoice creation and retrieval.
    /// </remarks>
    public interface IInvoiceManager
    {
        /// <summary>
        /// Generates a new invoice based on the provided <see cref="InvoiceDto"/>.
        /// </summary>
        /// <param name="dto">The invoice data transfer object containing order ID and total amount.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Implementation should map the DTO to a domain entity, 
        /// persist it using a repository, and commit changes via unit of work.
        /// </remarks>
        Task GenerateInvoice(InvoiceDto dto);

        /// <summary>
        /// Fetches an invoice by its unique identifier.
        /// </summary>
        /// <param name="InvoiceId">The unique identifier of the invoice to retrieve.</param>
        /// <returns>
        /// A <see cref="FetchInvoiceDto"/> containing invoice details if found;
        /// otherwise, returns null.
        /// </returns>
        /// <remarks>
        /// Implementation should retrieve the invoice from the repository,
        /// map it to a DTO, and handle cases where the invoice does not exist.
        /// </remarks>
        Task<FetchInvoiceDto> FetchInvoice(Guid InvoiceId);
    }
}
