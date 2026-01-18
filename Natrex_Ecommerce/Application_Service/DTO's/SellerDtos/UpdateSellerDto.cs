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
