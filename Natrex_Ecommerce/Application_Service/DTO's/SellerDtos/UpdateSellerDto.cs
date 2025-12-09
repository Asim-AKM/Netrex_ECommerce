namespace Application_Service.DTO_s.SellerDtos
{
    /// <summary>
    /// Data Transfer Object used for updating an existing seller's information.
    /// </summary>
    public record UpdateSellerDto
    (
        /// <summary>
        /// The unique identifier of the seller.
        /// </summary>
        Guid SellerId,

        /// <summary>
        /// The unique identifier of the user associated with the seller.
        /// </summary>
        Guid UserId,

        /// <summary>
        /// The unique identifier of the shop associated with the seller.
        /// </summary>
        Guid ShopId,

        /// <summary>
        /// The name of the store.
        /// </summary>
        string StoreName,

        /// <summary>
        /// A brief description of the store.
        /// </summary>
        string StoreDescription,

        /// <summary>
        /// The physical address of the store.
        /// </summary>
        string Address
    );
}
