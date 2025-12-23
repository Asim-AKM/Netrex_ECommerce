using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.PaymentAndPayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    /// <summary>
    /// Defines contract for payment detail related business operations.
    /// </summary>
    /// <remarks>
    /// This interface represents the application service abstraction for
    /// processing payments and retrieving payment details in the
    /// Payment and Payout module.
    /// </remarks>
    public interface IPaymentDetailManager
    {
        /// <summary>
        /// Processes a payment based on the provided payment information.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing payment processing details.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{ProcessPaymentDto}"/> indicating
        /// successful processing of the payment.
        /// </returns>
        Task<ApiResponse<ProcessPaymentDto>> ProcessPayment(ProcessPaymentDto dto);

        /// <summary>
        /// Retrieves payment details by payment identifier.
        /// </summary>
        /// <param name="paymentId">
        /// The unique identifier of the payment.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetPaymentByIdDto}"/> containing payment data
        /// if found; otherwise, returns a NotFound response.
        /// </returns>
        Task<ApiResponse<GetPaymentByIdDto>> GetPaymentById(Guid paymentId);
    }
}
