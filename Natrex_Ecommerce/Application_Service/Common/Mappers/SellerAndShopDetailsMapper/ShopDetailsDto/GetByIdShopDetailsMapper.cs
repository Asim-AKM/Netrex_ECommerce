using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class GetByIdShopDetailsMapper
    {
        public static GetShopDetailsDto Map(this ShopDetail shopDetail)
        {
          return  new GetShopDetailsDto
                (
                shopDetail.ShopDetailsId,
                shopDetail.CategoryName
                );
        }
    }
}
