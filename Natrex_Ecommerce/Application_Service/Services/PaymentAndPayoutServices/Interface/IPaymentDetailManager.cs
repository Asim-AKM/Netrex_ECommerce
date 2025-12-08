using Application_Service.DTO_s.Payment_PayoutDtos;

namespace Application_Service.Services.PaymentAndPayoutServices.Interface
{
    public interface IPaymentDetailManager
    {
        Task ProcessPayment(ProcessPaymentDto dto);
        Task<FetchPaymentDto> FetchPayment(Guid paymentId);
    }
}
