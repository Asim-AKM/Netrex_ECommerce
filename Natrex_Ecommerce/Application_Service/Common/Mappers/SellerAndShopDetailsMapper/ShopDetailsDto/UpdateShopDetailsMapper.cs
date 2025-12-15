using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class UpdateShopDetailsMapper
    {
        public static UpdateShopDetailsDto MapToUpdateDto(this ShopDetail shopDetail)
        {
            return new UpdateShopDetailsDto
                (
                shopDetail.ShopDetailsId,
                shopDetail.CategoryName
                );
        }
        public static ShopDetail MapToDomain(this UpdateShopDetailsDto shopDetailsDto)
        {
            return new ShopDetail
            {
                ShopDetailsId = shopDetailsDto.ShopDetailsId,
                CategoryName= shopDetailsDto.CategoryName,
            };
        }
    }
}
