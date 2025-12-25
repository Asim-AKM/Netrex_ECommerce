using Application_Service.Common.APIResponses;
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
        Task <ApiResponse<CreateShopDetailsDto>> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto);
        Task <ApiResponse<UpdateShopDetailsDto>> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto);
        Task <ApiResponse<bool>> DeleteShopDetails(Guid ShopDetailId);
        Task <ApiResponse<GetByIdShopDetailsDto>> GetByIdShopDetails(Guid ShopDetailId);
        Task <ApiResponse<GetAllShopDetailsDto>> GetAllShopDetails();

    }
}
