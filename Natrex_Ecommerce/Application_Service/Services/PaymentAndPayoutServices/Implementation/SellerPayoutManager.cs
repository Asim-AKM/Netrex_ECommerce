using Application_Service.Common.APIResponses;
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
        public async Task<ApiResponse<AddSellerPayoutDto>> CreateSellerPayout(AddSellerPayoutDto dto)
        {
            var sellerPayout = dto.Map();
            await _sellerPayoutRepository.Create(sellerPayout);
            await _sellerPayoutRepository.SaveChangesAsync();
            return ApiResponse<AddSellerPayoutDto>.Success(dto, "Seller Payout Created Successfully", ResponseType.Created);
        }

        public async Task<ApiResponse<GetSellerPayoutByIdDto>> GetSellerPayoutById(Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutRepository.GetById(sellerPayoutId);
            if (payout == null)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail("Seller Payout not found", ResponseType.NotFound);
            }
            var response = payout.Map();
            return ApiResponse<GetSellerPayoutByIdDto>.Success(response, "Seller Payout retrieved successfully", ResponseType.Ok);

        }

        public async Task<ApiResponse<GetSellerPayoutByIdDto>> UpdateSellerPayoutAsPaid(Guid sellerPayoutId)
        {
            var payout = await _sellerPayoutRepository.GetById(sellerPayoutId);
            if (payout == null)
            {
                return ApiResponse<GetSellerPayoutByIdDto>.Fail("Seller Payout not found", ResponseType.NotFound);
            }

            payout.PaymentStatus = PaymentStatus.success;
            payout.PayOutDate = DateTime.UtcNow;

            await _sellerPayoutRepository.Update(payout);
            await _sellerPayoutRepository.SaveChangesAsync();
            return ApiResponse<GetSellerPayoutByIdDto>.Success(payout.Map(), "Seller Payout Updated As Paid Successfully", ResponseType.Ok);
        }
    }
}
