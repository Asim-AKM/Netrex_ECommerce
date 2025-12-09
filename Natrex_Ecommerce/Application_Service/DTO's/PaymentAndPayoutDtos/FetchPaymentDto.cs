using Domain_Service.Enums;
using System;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    public record FetchPaymentDto( Guid PaymentDetailId,Guid OrderId,PaymentMethod PaymentMethod,string TransactionId,PaymentStatus PaymentStatus,double AmountPaid,DateTime CreatedAt );
}
