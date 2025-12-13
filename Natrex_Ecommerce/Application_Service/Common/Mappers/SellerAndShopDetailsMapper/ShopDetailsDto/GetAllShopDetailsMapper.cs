using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class GetAllShopDetailsMapper
    {
        public static ShopDetail Map(this GetAllShopDetailsDto getAll)
        {
            return new ShopDetail
            {
                ShopDetailsId = getAll.ShopDetailsId,
                CategoryName = getAll.CategoryName
            };
        }
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
