using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.PaymentAndPayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    public interface ISellerPayoutManager
    {
        Task<ApiResponse<AddSellerPayoutDto>> CreateSellerPayout(AddSellerPayoutDto dto);
        Task<ApiResponse<GetSellerPayoutByIdDto>> UpdateSellerPayoutAsPaid(Guid sellerPayoutId);
        Task<ApiResponse<GetSellerPayoutByIdDto>> GetSellerPayoutById(Guid sellerPayoutId);

    }
}
