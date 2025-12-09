using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class PaymentMapper
    {
        public static PaymentDetail Map(this ProcessPaymentDto dto)
        {
            return new PaymentDetail
            {
                PaymentDetailId = Guid.NewGuid(),
                OrderId = dto.OrderId,
                PaymentMethod = dto.PaymentMethod,
                TransactionId = Guid.NewGuid().ToString("N"), // auto mock transaction id
                PaymentStatus = PaymentStatus.success,
                AmountPaid = dto.AmountPaid,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static FetchPaymentDto Map(this PaymentDetail entity)
        {
            return new FetchPaymentDto(
                entity.PaymentDetailId,
                entity.OrderId,
                entity.PaymentMethod,
                entity.TransactionId,
                entity.PaymentStatus,
                entity.AmountPaid,
                entity.CreatedAt
            );
        }
    }
}
