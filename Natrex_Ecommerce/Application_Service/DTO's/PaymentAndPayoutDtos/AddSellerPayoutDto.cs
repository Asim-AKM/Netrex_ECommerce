namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    public record AddSellerPayoutDto(Guid SellerId, Guid OrderId, Double AmountToPay);
    
}
