namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class AddSellerPayoutMapper
    {
        public static SellerPayout Map(this AddSellerPayoutDto dto)
        {
            return new SellerPayout
            {
                SellerPayoutId = Guid.NewGuid(),
                SellerId = dto.SellerId,
                OrderId = dto.OrderId,
                AmountToPay = dto.AmountToPay,
                PaymentStatus = PaymentStatus.pending,
                PayOutDate = DateTime.UtcNow
            };
        }
    }
}
