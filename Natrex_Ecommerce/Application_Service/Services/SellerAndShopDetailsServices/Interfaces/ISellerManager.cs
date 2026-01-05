using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.SellerDtos;

namespace Application_Service.Services.Interface
{
    /// <summary>
    /// Defines contract methods for managing Seller operations including creation, updating, deletion, and fetching seller information.
    /// </summary>
    public interface ISellerManager
    {
        /// <summary>
        /// Creates a new seller record asynchronously.
        /// </summary>
        /// <param name="createSellerDto">The data required to create a new seller.</param>
        /// <returns>
        /// An <see cref="ApiResponse{T}"/> containing the created <see cref="CreateSellerDto"/> and HTTP status.
        /// </returns>
        Task<ApiResponse<CreateSellerDto>> InsertSeller(CreateSellerDto createSellerDto);

        /// <summary>
        /// Updates an existing seller record asynchronously.
        /// </summary>
        /// <param name="updateSellerDto">The updated seller information.</param>
        /// <returns>
        /// An <see cref="ApiResponse{T}"/> containing the updated <see cref="UpdateSellerDto"/> and HTTP status.
        /// </returns>
        Task<ApiResponse<UpdateSellerDto>> UpdateSeller(UpdateSellerDto updateSellerDto);

        /// <summary>
        /// Deletes a seller based on the provided unique identifier.
        /// </summary>
        /// <param name="sellerId">The unique identifier of the seller to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse{T}"/> containing <c>true</c> if deletion is successful; otherwise <c>false</c>, along with HTTP status.
        /// </returns>
        Task<ApiResponse<bool>> DeleteSeller(Guid sellerId);

        /// <summary>
        /// Retrieves a seller by its unique identifier asynchronously.
        /// </summary>
        /// <param name="sellerId">The unique identifier of the seller.</param>
        /// <returns>
        /// An <see cref="ApiResponse{T}"/> containing <see cref="GetSellerDto"/> if found; otherwise <c>null</c>, along with HTTP status.
        /// </returns>
        Task<ApiResponse<GetSellerDto?>> GetSellerById(Guid sellerId);

        /// <summary>
        /// Retrieves a list of all sellers asynchronously.
        /// </summary>
        /// <returns>
        /// An <see cref="ApiResponse{T}"/> containing a list of <see cref="GetSellerDto"/> and HTTP status.
        /// </returns>
        Task<ApiResponse<List<GetSellerDto>>> GetAllSellerList();
    }
}
