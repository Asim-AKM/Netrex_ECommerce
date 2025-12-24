using Domain_Service.RepoInterfaces.PaymentAndPayout;
using Infrastructure_Service.Data;

namespace Infrastructure_Service.Persistance.Repositories.PaymentAndPayout
{
    /// <summary>
    /// Provides data access implementation for seller payout operations.
    /// </summary>
    /// <remarks>
    /// This class implements <see cref="ISellerPayoutRepo"/> and belongs to the
    /// Infrastructure layer of the application.
    /// 
    /// It is responsible for interacting with the database using
    /// <see cref="ApplicationDbContext"/> to manage seller payout data.
    /// </remarks>
    public class SellerPayoutRepo : ISellerPayoutRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SellerPayoutRepo"/> class.
        /// </summary>
        /// <param name="applicationDbContext">
        /// Database context used for seller payout persistence operations.
        /// </param>
        public SellerPayoutRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
