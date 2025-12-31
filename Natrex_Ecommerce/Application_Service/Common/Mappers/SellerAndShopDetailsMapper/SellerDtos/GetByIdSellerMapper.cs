using Application_Service.DTO_s.SellerDtos;
using Domain_Service.Entities.SellerModule;
using System;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.SellerDtos
{
    /// <summary>
    /// Provides mapping extension methods for converting <see cref="Seller"/> entities to <see cref="GetSellerDto"/> objects.
    /// </summary>
    public static class GetByIdSellerMapper
    {
        /// <summary>
        /// Maps a <see cref="Seller"/> entity to a <see cref="GetSellerDto"/>.
        /// </summary>
        /// <param name="seller">The <see cref="Seller"/> entity to map.</param>
        /// <returns>A new <see cref="GetSellerDto"/> with properties copied from the <paramref name="seller"/> entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="seller"/> is null.</exception>
        public static GetSellerDto Map(this Seller seller)
        {
            if (seller is null)
            {
                throw new ArgumentNullException(nameof(seller));
            }

            return new GetSellerDto
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
