using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.RepoInterfaces.UnitOfWork;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    public class PaymentDetailManager : IPaymentDetailManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessPayment(ProcessPaymentDto dto)
        {
            var payment = dto.Map();
            await _unitOfWork.PaymentDetails.Create(payment);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<FetchPaymentDto> FetchPayment(Guid paymentId)
        {
            var data = await _unitOfWork.PaymentDetails.GetById(paymentId);

            if (data == null)
                return null!;

            return data.Map();
        }
    }
}
