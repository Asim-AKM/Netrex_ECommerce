using Domain_Service.Enums;
using System;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    public record ProcessPaymentDto( Guid OrderId,PaymentMethod PaymentMethod,double AmountPaid );
}
