using Application_Service.DTO_s.Payment_PayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
