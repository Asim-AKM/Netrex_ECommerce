using Application_Service.DTO_s.ShopDetailsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Service.Services.SellerAndShopDetailsServices.Interfaces
{
    public interface IShopDetailsManager
    {
        Task<CreateShopDetailsDto> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto);
        Task<UpdateShopDetailsDto> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto);
        Task<bool> DeleteShopDetails(Guid ShopDetailId);
        Task<GetByIdShopDetailsDto> GetByIdShopDetails(Guid ShopDetailId);
        Task<GetAllShopDetailsDto> GetAllShopDetails(GetAllShopDetailsDto getAll);

    }
}
