using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class CreateShopDetailsMapper
    {
        public static ShopDetail Map(this CreateShopDetailsDto createShopDetailsDto)
        {
            return new ShopDetail
            {
                ShopDetailsId=Guid.NewGuid(),
                CategoryName=createShopDetailsDto.CategoryName,
            };
        }
        public static CreateShopDetailsDto MapToCreateShopDto( this ShopDetail shopDetail)
        {
            return new CreateShopDetailsDto
                (
                shopDetail.ShopDetailsId,
                shopDetail.CategoryName
                );
        }
    }
}
