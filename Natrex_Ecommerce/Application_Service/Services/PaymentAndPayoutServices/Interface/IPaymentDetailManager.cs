using Application_Service.Common.APIResponses;
using Application_Service.DTO_s.PaymentAndPayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    public interface IPaymentDetailManager
    {
        Task<ApiResponse<ProcessPaymentDto>> ProcessPayment(ProcessPaymentDto dto);
        Task<ApiResponse<GetPaymentByIdDto>> GetPaymentById(Guid paymentId);
    }
}
