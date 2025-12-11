using Application_Service.DTO_s.SellerDtos;
using Domain_Service.Entities.SellerModule;
using System;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper
{
    /// <summary>
    /// Provides mapping extension methods for converting between <see cref="UpdateSellerDto"/> and <see cref="Seller"/> entities.
    /// </summary>
    public static class UpdateSellerMapper
    {
        /// <summary>
        /// Maps an <see cref="UpdateSellerDto"/> to a <see cref="Seller"/> entity.
        /// </summary>
        /// <param name="updateSellerDto">The DTO containing updated seller information.</param>
        /// <returns>A new <see cref="Seller"/> entity populated with data from the DTO.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="updateSellerDto"/> is null.</exception>
        public static Seller Map(this UpdateSellerDto updateSellerDto)
        {
            if (updateSellerDto is null)
            {
                throw new ArgumentNullException(nameof(updateSellerDto));
            }

            return new Seller
            {
                SellerId = updateSellerDto.SellerId,
                UserId = updateSellerDto.UserId,
                ShopId = updateSellerDto.ShopId,
                StoreName = updateSellerDto.StoreName,
                StoreDescription = updateSellerDto.StoreDescription,
                Address = updateSellerDto.Address,
            };
        }

        /// <summary>
        /// Maps a <see cref="Seller"/> entity to an <see cref="UpdateSellerDto"/>.
        /// </summary>
        /// <param name="seller">The <see cref="Seller"/> entity to map.</param>
        /// <returns>A new <see cref="UpdateSellerDto"/> populated with data from the <paramref name="seller"/> entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="seller"/> is null.</exception>
        public static UpdateSellerDto MapDomainToDto(this Seller seller)
        {
            if (seller is null)
            {
                throw new ArgumentNullException(nameof(seller));
            }

            return new UpdateSellerDto
            (
                seller.SellerId,
                seller.UserId,
                seller.ShopId,
                seller.StoreName,
                seller.StoreDescription,
                seller.Address
            );
        }
    }
}
