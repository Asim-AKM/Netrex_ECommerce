using Domain_Service.Enums;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    public record GetSellerPayoutByIdDto(
                          Guid SellerPayoutId,
                          Guid SellerId,
                          Guid OrderId,
                          double AmountToPay,
                          PaymentStatus PaymentStatus,
                          DateTime PayOutDate
                 );

}
