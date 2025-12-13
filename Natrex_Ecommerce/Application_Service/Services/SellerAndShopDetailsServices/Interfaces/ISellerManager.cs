using Application_Service.DTO_s.SellerDtos;

namespace Application_Service.Services.SellerAndShopDetailsServices.Interfaces
{
    /// <summary>
    /// Defines contract methods for managing Seller operations including creation, updating, deletion, and fetching seller information.
    /// </summary>
    public interface ISellerManager
    {
        /// <summary>
        /// Creates a new seller record.
        /// </summary>
        /// <param name="createSellerDto">The data required to create a new seller.</param>
        /// <returns>A task representing the asynchronous create operation.</returns>
        Task CreateSeller(CreateSellerDto createSellerDto);

        /// <summary>
        /// Updates an existing seller record.
        /// </summary>
        /// <param name="updateSellerDto">The updated seller information.</param>
        /// <returns>Returns the updated seller DTO.</returns>
        Task<UpdateSellerDto> UpdateSeller(UpdateSellerDto updateSellerDto);

        /// <summary>
        /// Deletes a seller based on the provided SellerId.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller to delete.</param>
        /// <returns>
        /// Returns <c>true</c> if deletion is successful; otherwise <c>false</c>.
        /// </returns>
        Task<bool> DeleteSeller(Guid SellerId);

        /// <summary>
        /// Retrieves a seller by its unique identifier.
        /// </summary>
        /// <param name="SellerId">The unique identifier of the seller.</param>
        /// <returns>
        /// Returns the seller details if found; otherwise <c>null</c>.
        /// </returns>
        Task<GetByIdSellerDto?> GetSellerById(Guid SellerId);
        Task<GetAllSellerDto> GetAllSeller(GetAllSellerDto getAllSellers);
    }
}
