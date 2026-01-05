namespace Application_Service.DTO_s.ShopDetailsDtos
{
    /// <summary>
    /// Data Transfer Object for updating existing shop details.
    /// </summary>
    /// <remarks>
    /// This DTO is used when updating an existing shop detail record and contains the information to be modified.
    /// </remarks>
    /// <param name="ShopDetailsId">Unique identifier of the shop detail to update.</param>
    /// <param name="CategoryName">Updated category name of the shop detail.</param>
    public record UpdateShopDetailsDto(
        Guid ShopDetailsId,
        string CategoryName
    );
}
