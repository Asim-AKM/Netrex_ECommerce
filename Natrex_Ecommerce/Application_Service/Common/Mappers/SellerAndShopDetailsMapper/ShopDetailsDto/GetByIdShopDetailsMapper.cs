using Application_Service.DTO_s.ShopDetailsDtos;
using Domain_Service.Entities.SellerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Common.Mappers.SellerAndShopDetailsMapper.ShopDetailsDto
{
    public static class GetByIdShopDetailsMapper
    {
        public static GetByIdShopDetailsDto Map(this ShopDetail shopDetail)
        {
          return  new GetByIdShopDetailsDto
                (
                shopDetail.ShopDetailsId,
                shopDetail.CategoryName
                );
        }
    }
}
