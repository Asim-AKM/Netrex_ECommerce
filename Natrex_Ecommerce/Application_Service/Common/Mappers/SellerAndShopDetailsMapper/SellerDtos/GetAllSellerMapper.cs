using Application_Service.DTO_s.SellerDtos;
using Domain_Service.Entities.SellerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.SellerDtos
{
    public static class GetAllSellerMapper
    {

        public static GetAllSellerDto MapToDto(this Seller seller)
        {
            return new GetAllSellerDto
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
