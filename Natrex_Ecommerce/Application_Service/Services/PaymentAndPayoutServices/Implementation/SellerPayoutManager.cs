using Application_Service.Common.Mappers.PaymentAndPayoutMappers;
using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Application_Service.Services.PaymentAndPayoutServices.Interface;
using Domain_Service.Entities.SellerPaymentModule;
using Domain_Service.Enums;
using Domain_Service.RepoInterfaces.GenericRepo;

namespace Application_Service.Services.PaymentAndPayoutServices.Implementation
{
    public class SellerPayoutManager : ISellerPayoutManager
    {
        private readonly IRepository<SellerPayout> _sellerPayoutRepository;
        public SellerPayoutManager(IRepository<SellerPayout> sellerpayoutrepo)
        {
            _sellerPayoutRepository = sellerpayoutrepo;
        }
        public async Task CreateSellerPayout(AddSellerPayoutDto dto)
        {
            var sellerPayout = dto.Map();
            await _sellerPayoutRepository.Create(sellerPayout);
            await _sellerPayoutRepository.SaveChangesAsync();
        }

        public async Task<FetchSellerPayoutDto> GetSellerPayoutById(Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutRepository.GetById(sellerPayoutId);
            if (payout == null)
            {
                return null!;
            }
            return payout.Map();


        }

        public async Task UpdateSellerPayoutAsPaid(Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutRepository.GetById(sellerPayoutId);
            if (payout == null)
            {
                return;
            }

            payout.PaymentStatus = PaymentStatus.success;
            payout.PayOutDate = DateTime.UtcNow;

            await _sellerPayoutRepository.Update(payout);
            await _sellerPayoutRepository.SaveChangesAsync();
        }
    }
}
