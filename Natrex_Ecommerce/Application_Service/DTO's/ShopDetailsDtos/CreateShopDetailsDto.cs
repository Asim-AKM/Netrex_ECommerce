namespace Application_Service.DTO_s.ShopDetailsDtos
{
    /// <summary>
    /// Data Transfer Object for creating a new Shop Detail.
    /// </summary>
    /// <remarks>
    /// This DTO is used when creating a new shop detail record and contains the necessary information.
    /// </remarks>
    /// <param name="ShopDetailsId">Unique identifier for the shop detail.</param>
    /// <param name="CategoryName">Category name of the shop detail.</param>
    public record CreateShopDetailsDto(
        Guid ShopDetailsId,
        string CategoryName
    );
}
