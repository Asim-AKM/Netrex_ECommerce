using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    /// <summary>
    /// Repository for performing CRUD operations on <see cref="Domain_Service.Entities.PaymentAndPayout.Invoice"/> entities.
    /// Provides a clean abstraction over the database for the Invoice module.
    /// </summary>
    /// <remarks>
    /// Part of the Infrastructure layer in Clean Architecture.
    /// Uses <see cref="ApplicationDbContext"/> to interact with the database.
    /// All invoice-specific operations should be implemented in this class.
    /// </remarks>
    public class InvoiceRepo : IInvoiceRepo
    {
        /// <summary>
        /// EF Core database context for accessing invoice data.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepo"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application's database context for Invoice entities.</param>
        public InvoiceRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        // -----------------------------------------------------------------
        // NOTE:
        // Add invoice-specific database methods here, for example:
        //   - Get invoices by OrderId
        //   - Get invoices within a date range
        //   - Calculate total revenue from invoices
        // -----------------------------------------------------------------
    }
}
