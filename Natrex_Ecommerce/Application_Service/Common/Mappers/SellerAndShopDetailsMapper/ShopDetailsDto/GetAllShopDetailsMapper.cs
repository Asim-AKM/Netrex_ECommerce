using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class GetAllShopDetailsMapper
    {
        public static GetAllShopDetailsDto MapToDto(this ShopDetail shopDetail)
        {
            return new GetAllShopDetailsDto
                (
                    shopDetail.ShopDetailsId,
                    shopDetail.CategoryName
                );
        }
    }
}
