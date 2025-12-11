using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    /// <summary>
    /// Static mapper class for converting <see cref="Invoice"/> entities
    /// into <see cref="FetchInvoiceDto"/> objects.
    /// </summary>
    /// <remarks>
    /// This mapper provides a simple and safe way to transform invoice data
    /// from the domain layer entity to a DTO suitable for presentation or API responses.
    /// </remarks>
    public static class FetchInvoiceMapper
    {
        /// <summary>
        /// Maps an <see cref="Invoice"/> entity to a <see cref="FetchInvoiceDto"/>.
        /// </summary>
        /// <param name="invoice">The <see cref="Invoice"/> entity to map.</param>
        /// <returns>A <see cref="FetchInvoiceDto"/> containing the same invoice details
        /// for read-only or API output purposes.</returns>
        /// <remarks>
        /// This method ensures that only relevant invoice data (InvoiceId, OrderId, CreatedAt, Total)
        /// is exposed to the client, keeping domain entities encapsulated.
        /// </remarks>
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
