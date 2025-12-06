using Application_Service.DTO_s.Payment_PayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class GenerateInvoiceMapper
    {
        public static Invoice Map(this InvoiceDto dto)
        {
            return new Invoice
            {
                InvoiceId = Guid.NewGuid(),
                OrderId = dto.OrderId,
                CreatedAt = DateTime.UtcNow,
                Total = dto.Total
            };
        }
    }
}
