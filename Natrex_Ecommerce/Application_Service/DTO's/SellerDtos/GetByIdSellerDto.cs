namespace Application_Service.DTO_s.SellerDtos
{
    /// <summary>
    /// Represents the details of a seller returned when fetching by its unique identifier.
    /// </summary>
    /// <param name="SellerId">The unique identifier of the seller.</param>
    /// <param name="UserId">The unique identifier of the user associated with the seller.</param>
    /// <param name="ShopId">The unique identifier of the shop associated with the seller.</param>
    /// <param name="StoreName">The name of the store.</param>
    /// <param name="StoreDescription">The description of the store.</param>
    /// <param name="Address">The address of the store.</param>
    public record GetByIdSellerDto
    (
        Guid SellerId,
        Guid UserId,
        Guid ShopId,
        string StoreName,
        string StoreDescription,
        string Address
    );
}
