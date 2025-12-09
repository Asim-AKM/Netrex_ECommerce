namespace Application_Service.DTO_s.SellerDtos
{
    /// <summary>
    /// Represents the data required to create a new seller.
    /// </summary>
    /// <param name="SellerId">The unique identifier of the seller to be created.</param>
    /// <param name="UserId">The unique identifier of the user associated with the seller.</param>
    /// <param name="ShopId">The unique identifier of the shop associated with the seller.</param>
    /// <param name="StoreName">The name of the store.</param>
    /// <param name="StoreDescription">The description of the store.</param>
    /// <param name="Address">The address of the store.</param>
    public record CreateSellerDto
    (
        Guid SellerId,
        Guid UserId,
        Guid ShopId,
        string StoreName,
        string StoreDescription,
        string Address
    );
}
