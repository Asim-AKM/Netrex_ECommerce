using Application_Service.DTO_s.SellerDtos;
using Domain_Service.Entities.SellerModule;

namespace Application_Service.Common.Mappers.SellerAnShopDetailsMapper
{
    /// <summary>
    /// Provides mapping extension methods for converting <see cref="CreateSellerDto"/> objects to <see cref="Seller"/> entities.
    /// </summary>
    public static class CreateSellerMapper
    {
        /// <summary>
        /// Maps a <see cref="CreateSellerDto"/> to a <see cref="Seller"/> entity.
        /// </summary>
        /// <param name="createSellerDto">The DTO containing data for creating a new seller.</param>
        /// <returns>A new <see cref="Seller"/> entity with properties populated from the DTO.  
        /// The <see cref="Seller.SellerId"/>, <see cref="Seller.UserId"/>, and <see cref="Seller.ShopId"/> are generated as new GUIDs.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="createSellerDto"/> is null.</exception>
        public static Seller Map(this CreateSellerDto createSellerDto)
        {
            if (createSellerDto is null)
            {
                throw new ArgumentNullException(nameof(createSellerDto));
            }

            return new Seller
            {
                SellerId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ShopId = Guid.NewGuid(),
                StoreName = createSellerDto.StoreName,
                StoreDescription = createSellerDto.StoreDescription,
                Address = createSellerDto.Address,
            };
        }
    }
}
