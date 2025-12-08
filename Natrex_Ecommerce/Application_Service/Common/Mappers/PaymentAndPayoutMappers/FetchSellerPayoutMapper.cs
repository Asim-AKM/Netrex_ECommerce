using Application_Service.DTO_s.Payment_PayoutDtos;
using Domain_Service.Entities.SellerPaymentModule;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class FetchSellerPayoutMapper
    {
        public static FetchSellerPayoutDto Map(this SellerPayout sellerPayout)
        {
            return new FetchSellerPayoutDto(
                sellerPayout.SellerPayoutId,
                sellerPayout.SellerId,
                sellerPayout.OrderId,
                sellerPayout.AmountToPay,
                sellerPayout.PaymentStatus,
                sellerPayout.PayOutDate
            );
        }
    }
}
