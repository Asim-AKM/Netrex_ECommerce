using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    /// <summary>
    /// Concrete repository implementation for <see cref="IInvoiceRepo"/>.
    /// Handles data operations for <see cref="Domain_Service.Entities.PaymentAndPayout.Invoice"/> entities.
    /// </summary>
    /// <remarks>
    /// This class is part of the Infrastructure layer in Clean Architecture.
    /// It uses <see cref="ApplicationDbContext"/> to interact with the database.
    /// All invoice-specific CRUD operations should be implemented here.
    /// </remarks>
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepo"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The database context used to access invoice data.</param>
        public InvoiceRepo(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        /// <summary>
        /// (Optional) Add invoice-specific database operations here.
        /// Examples include:
        /// <list type="bullet">
        /// <item>Get invoices by OrderId</item>
        /// <item>Get invoices within a date range</item>
        /// <item>Calculate total revenue from invoices</item>
        /// </list>
        /// </summary>
    }
}
