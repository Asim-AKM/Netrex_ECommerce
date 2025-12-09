using Domain_Service.Enums;
using System;

namespace Application_Service.DTO_s.Payment_PayoutDtos
{
    public record ProcessPaymentDto( Guid OrderId,PaymentMethod PaymentMethod,double AmountPaid );
}
