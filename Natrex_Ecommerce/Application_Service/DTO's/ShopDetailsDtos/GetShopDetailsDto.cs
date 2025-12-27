namespace Application_Service.DTO_s.ShopDetailsDtos
{
    /// <summary>
    /// Data Transfer Object for retrieving shop details.
    /// </summary>
    /// <remarks>
    /// This DTO is used when fetching shop details from the system and contains the relevant information.
    /// </remarks>
    /// <param name="ShopDetailsId">Unique identifier of the shop detail.</param>
    /// <param name="CategoryName">Category name of the shop detail.</param>
    public record GetShopDetailsDto(
        Guid ShopDetailsId,
        string CategoryName
    );
}
