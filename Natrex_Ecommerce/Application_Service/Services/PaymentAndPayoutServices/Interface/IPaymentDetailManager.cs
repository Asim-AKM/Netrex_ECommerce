using Application_Service.DTO_s.Payment_PayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    /// <summary>
    /// Defines the contract for managing payment-related operations 
    /// such as processing and fetching payment details.
    /// </summary>
    public interface IPaymentDetailManager
    {
        /// <summary>
        /// Processes a new payment request.
        /// Converts input DTO into domain model and saves it using UnitOfWork.
        /// </summary>
        /// <param name="dto">
        /// The incoming payment data containing amount, reference, order ID, 
        /// and other required payment details.
        /// </param>
        /// <returns>
        /// A Task representing the asynchronous operation of payment creation.
        /// </returns>
        Task ProcessPayment(ProcessPaymentDto dto);

        /// <summary>
        /// Fetches a payment by its unique identifier.
        /// </summary>
        /// <param name="paymentId">
        /// The unique GUID of the payment record to retrieve.
        /// </param>
        /// <returns>
        /// A <see cref="FetchPaymentDto"/> containing payment information 
        /// or null if no payment is found for the given ID.
        /// </returns>
        Task<FetchPaymentDto> FetchPayment(Guid paymentId);
    }
}
