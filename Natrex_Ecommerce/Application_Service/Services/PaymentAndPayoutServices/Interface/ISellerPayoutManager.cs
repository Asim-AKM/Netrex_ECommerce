using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.PaymentAndPayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    /// <summary>
    /// Defines contract for managing seller payout related operations
    /// in the application layer.
    /// </summary>
    /// <remarks>
    /// This interface belongs to the Application layer in Clean Architecture
    /// and is responsible for handling business logic related to
    /// seller payouts within the Payment and Payout module.
    /// </remarks>
    public interface ISellerPayoutManager
    {
        /// <summary>
        /// Creates a new seller payout.
        /// </summary>
        /// <param name="dto">
        /// Data transfer object containing seller payout creation details.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{AddSellerPayoutDto}"/> indicating successful
        /// creation of the seller payout.
        /// </returns>
        Task<ApiResponse<AddSellerPayoutDto>> CreateSellerPayout(AddSellerPayoutDto dto);

        /// <summary>
        /// Updates the seller payout status to paid.
        /// </summary>
        /// <param name="sellerPayoutId">
        /// The unique identifier of the seller payout.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetSellerPayoutByIdDto}"/> indicating successful
        /// update of the payout status.
        /// </returns>
        Task<ApiResponse<GetSellerPayoutByIdDto>> UpdateSellerPayoutAsPaid(Guid sellerPayoutId);

        /// <summary>
        /// Retrieves seller payout details by payout identifier.
        /// </summary>
        /// <param name="sellerPayoutId">
        /// The unique identifier of the seller payout.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse{GetSellerPayoutByIdDto}"/> containing payout data
        /// if found; otherwise, returns a NotFound response.
        /// </returns>
        Task<ApiResponse<GetSellerPayoutByIdDto>> GetSellerPayoutById(Guid sellerPayoutId);
    }
}
