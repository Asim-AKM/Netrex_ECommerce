using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    /// <summary>
    /// Repository for performing CRUD operations on <see cref="PaymentDetail"/> entities.
    /// Provides a clean abstraction over the database for the Payment module.
    /// </summary>
    public class PaymentDetailRepo : IPaymentDetailRepo
    {
        /// <summary>
        /// EF Core database context for accessing <see cref="PaymentDetail"/> table.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDetailRepo"/> class.
        /// </summary>
        /// <param name="context">
        /// The application's <see cref="ApplicationDbContext"/> used to perform CRUD operations.
        /// </param>
        public PaymentDetailRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // -----------------------------------------------------------------
        // NOTE:
        // Custom repository methods related to PaymentDetail can be added here:
        //   - Get payments by OrderId
        //   - Get all successful payments
        //   - Validate transaction existence
        // This class is intentionally minimal to maintain a clean architecture.
        // -----------------------------------------------------------------
    }
}
