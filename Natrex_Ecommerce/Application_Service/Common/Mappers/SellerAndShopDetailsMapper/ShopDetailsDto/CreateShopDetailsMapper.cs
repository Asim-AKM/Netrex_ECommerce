using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class CreateShopDetailsMapper
    {
        public static ShopDetail Map(this CreateShopDetailsDto createShopDetailsDto)
        {
            return new ShopDetail
            {
                ShopDetailsId = Guid.NewGuid(),
                CategoryName = createShopDetailsDto.CategoryName,
            };
        }
    }
}
