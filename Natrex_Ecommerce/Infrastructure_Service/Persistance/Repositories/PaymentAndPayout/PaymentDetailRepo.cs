using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    /// <summary>
    /// Repository implementation for handling CRUD operations 
    /// related to <see cref="PaymentDetail"/> entity.
    /// 
    /// This class interacts directly with the database using 
    /// <see cref="ApplicationDbContext"/> and provides a clean 
    /// abstraction for the Payment module.
    /// </summary>
    public class PaymentDetailRepo : IPaymentDetailRepo
    {
        /// <summary>
        /// The application's database context used to perform
        /// database operations such as Create, Read, Update, Delete.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDetailRepo"/> class.
        /// Injects the <see cref="ApplicationDbContext"/> dependency.
        /// </summary>
        /// <param name="context">
        /// Represents the main EF Core database context responsible
        /// for interacting with the PaymentDetail table in the database.
        /// </param>
        public PaymentDetailRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        // -------------------------------------------------------------
        // NOTE:
        // Currently, this repository does not contain custom methods.
        // You can add custom payment-related queries here in the future.
        // Example:
        //    - Get payments by OrderId
        //    - Get all successful payments
        //    - Validate transaction existence
        //
        // This class is intentionally left minimal and clean.
        // -------------------------------------------------------------
    }
}
