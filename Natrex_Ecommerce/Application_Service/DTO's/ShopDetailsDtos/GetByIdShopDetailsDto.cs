using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.DTO_s.ShopDetailsDtos
{
    public record GetByIdShopDetailsDto(Guid ShopDetailsId,string CategoryName);
}
