using Application_Service.Common.APIResponses;
using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{    
    public class PaymentDetailManager : IPaymentDetailManager
    {
        private readonly IRepository<PaymentDetail> _genericpaymentDetailRepository;
        public PaymentDetailManager(IRepository<PaymentDetail> repository)
        {
            _genericpaymentDetailRepository = repository;
        }
       
        public async Task<ApiResponse<ProcessPaymentDto>> ProcessPayment(ProcessPaymentDto dto)
        {    
            var payment = dto.Map();

            await _genericpaymentDetailRepository.Create(payment);
            await _genericpaymentDetailRepository.SaveChangesAsync();
            return ApiResponse<ProcessPaymentDto>.Success(dto, "Payment processed successfully",ResponseType.Created);
        }
        
        public async Task<ApiResponse<GetPaymentByIdDto>> GetPaymentById(Guid paymentId)
        {          
            var data = await _genericpaymentDetailRepository.GetById(paymentId);

            if (data == null)
            {
                return ApiResponse<GetPaymentByIdDto>.Fail("Payment not found",ResponseType.NotFound);
            }

            var response =  data.Map();
            return ApiResponse<GetPaymentByIdDto>.Success(response, "Payment retrieved successfully",ResponseType.Ok);
        }

    }
}
