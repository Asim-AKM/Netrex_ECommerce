namespace Application_Service.DTO_s.Payment_PayoutDtos
{
    public record AddSellerPayoutDto(Guid SellerId, Guid OrderId, Double AmountToPay);
    
}
