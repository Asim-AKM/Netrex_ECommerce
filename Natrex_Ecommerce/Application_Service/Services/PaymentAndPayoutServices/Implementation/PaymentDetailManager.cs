using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.Payment_PayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    /// <summary>
    /// Service responsible for handling business logic related to Payment Details.
    /// 
    /// This class manages:
    ///     - Processing payments
    ///     - Fetching stored payment information
    /// 
    /// It communicates with the database through <see cref="IUnitOfWork"/>,
    /// ensuring that all payment-related operations are transactional,
    /// consistent, and follow clean architecture principles.
    /// </summary>
    public class PaymentDetailManager : IPaymentDetailManager
    {
        /// <summary>
        /// The UnitOfWork instance used to access repository objects
        /// and manage transactions inside the Payment module.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of <see cref="PaymentDetailManager"/>.
        /// Injects <see cref="IUnitOfWork"/> for database operations.
        /// </summary>
        /// <param name="unitOfWork">
        /// The UnitOfWork abstraction responsible for coordinating
        /// PaymentDetail repository calls and committing changes.
        /// </param>
        public PaymentDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Processes a payment by mapping the incoming DTO to a PaymentDetail entity,
        /// saving it through the repository, and committing the transaction.
        /// 
        /// This method is responsible for:
        ///     - Creating a new payment entry
        ///     - Saving PaymentMethod, AmountPaid, TransactionId, PaymentStatus
        ///     - Automatically assigning CreatedAt timestamp
        /// </summary>
        /// <param name="dto">The incoming payment data sent from the client.</param>
        public async Task ProcessPayment(ProcessPaymentDto dto)
        {
            // Convert DTO → PaymentDetail entity using mapper extension
            var payment = dto.Map();

            // Save payment detail in the repository
            await _unitOfWork.PaymentDetails.Create(payment);

            // Commit transaction (EF Core SaveChanges)
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves payment information using PaymentDetail ID.
        /// Returns a formatted FetchPaymentDto object.
        ///
        /// Steps:
        ///     1. Find payment record by ID
        ///     2. Return null if not found
        ///     3. Convert entity → DTO
        /// </summary>
        /// <param name="paymentId">The unique identifier for a payment record.</param>
        /// <returns>
        /// <see cref="FetchPaymentDto"/> if found; otherwise <c>null</c>.
        /// </returns>
        public async Task<FetchPaymentDto> FetchPayment(Guid paymentId)
        {
            // Fetch payment detail record from the DB
            var data = await _unitOfWork.PaymentDetails.GetById(paymentId);

            // If not found, return null
            if (data == null)
                return null!;

            // Convert entity → DTO and return
            return data.Map();
        }
    }
}
