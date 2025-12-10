using System;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used for creating a new invoice.
    /// Contains only the necessary information required to generate an invoice entity.
    /// </summary>
    /// <remarks>
    /// This DTO is immutable (read-only) and uses the C# 9 record type.
    /// It is intended for use in API requests or service calls where a new invoice needs to be generated.
    /// </remarks>
    /// <param name="OrderId">Unique identifier of the order associated with the invoice.</param>
    /// <param name="Total">Total amount of the invoice to be created.</param>
    public record InvoiceDto(
        Guid OrderId,
        double Total
    );
}
