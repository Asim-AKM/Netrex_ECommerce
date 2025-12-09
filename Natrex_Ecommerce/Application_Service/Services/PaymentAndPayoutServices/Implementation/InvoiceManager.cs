using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.Payment_PayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    /// <summary>
    /// Service class responsible for managing invoice-related operations.
    /// Implements <see cref="IInvoiceManager"/> interface.
    /// </summary>
    /// <remarks>
    /// This class is part of the Application layer in Clean Architecture.
    /// It interacts with the <see cref="IUnitOfWork"/> to perform database operations
    /// and uses mappers to convert between domain entities and DTOs.
    /// </remarks>
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work instance for accessing repositories and committing changes.</param>
        public InvoiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Fetches an invoice by its unique identifier.
        /// </summary>
        /// <param name="InvoiceId">Unique identifier of the invoice to fetch.</param>
        /// <returns>
        /// A <see cref="FetchInvoiceDto"/> containing invoice details if found; otherwise, returns null.
        /// </returns>
        /// <remarks>
        /// Uses <see cref="UnitOfWork.Invoices"/> repository to retrieve the invoice.
        /// Maps the domain entity to a DTO before returning to the caller.
        /// </remarks>
        public async Task<FetchInvoiceDto> FetchInvoice(Guid InvoiceId)
        {
            var fetchinvoice = await _unitOfWork.Invoices.GetById(InvoiceId);
            if (fetchinvoice == null)
            {
                return null!;
            }

            return fetchinvoice.Map();
        }

        /// <summary>
        /// Generates a new invoice based on the provided <see cref="InvoiceDto"/>.
        /// </summary>
        /// <param name="dto">The invoice data transfer object containing order ID and total amount.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <remarks>
        /// Maps the DTO to a domain <see cref="Invoice"/> entity,
        /// creates the invoice using the repository, and saves changes via the unit of work.
        /// </remarks>
        public async Task GenerateInvoice(InvoiceDto dto)
        {
            var invoice = dto.Map();
            await _unitOfWork.Invoices.Create(invoice);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
