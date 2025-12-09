using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    public static class FetchInvoiceMapper
    {
        public static FetchInvoiceDto Map(this Invoice invoice)
        {
            return new FetchInvoiceDto
                (
                invoice.InvoiceId,
                invoice.OrderId,
                invoice.CreatedAt,
                invoice.Total
                );
        }
    }
}
