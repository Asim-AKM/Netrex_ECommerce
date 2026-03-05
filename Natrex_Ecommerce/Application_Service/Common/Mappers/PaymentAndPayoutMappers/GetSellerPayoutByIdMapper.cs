namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class GetSellerPayoutByIdMapper
    {
        public static GetSellerPayoutByIdDto Map(this SellerPayout sellerPayout)
        {
            return new GetSellerPayoutByIdDto(
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
