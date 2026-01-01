using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.ShopDetailsDtos;


namespace Application_Service.Services.SellerAndShopDetailsServices.Interfaces
{
    public interface IShopDetailsManager
    {
        Task <ApiResponse<CreateShopDetailsDto>> CreateShopDetails(CreateShopDetailsDto createShopDetailsDto);
        Task <ApiResponse<UpdateShopDetailsDto>> UpdateShopDetails(UpdateShopDetailsDto updateShopDetailsDto);
        Task <ApiResponse<bool>> DeleteShopDetails(Guid ShopDetailId);
        Task <ApiResponse<GetShopDetailsDto>> GetByIdShopDetails(Guid ShopDetailId);
        Task <ApiResponse<List<GetShopDetailsDto>>> GetAllShopDetails();

    }
}
