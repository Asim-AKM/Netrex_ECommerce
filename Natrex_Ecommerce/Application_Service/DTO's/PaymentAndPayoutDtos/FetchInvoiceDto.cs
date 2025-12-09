using System;

namespace Application_Service.DTO_s.Payment_PayoutDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) for fetching invoice details.
    /// Used to transfer invoice information from the domain layer
    /// to the presentation or API layer without exposing the entity directly.
    /// </summary>
    /// <remarks>
    /// This DTO is immutable (read-only) and uses the C# 9 record type.
    /// It is intended for scenarios like listing invoices, viewing invoice details, or sending API responses.
    /// </remarks>
    /// <param name="InvoiceId">Unique identifier of the invoice record.</param>
    /// <param name="OrderId">Unique identifier of the associated order.</param>
    /// <param name="CreatedAt">Timestamp when the invoice was created.</param>
    /// <param name="Total">Total amount of the invoice.</param>
    public record FetchInvoiceDto(
        Guid InvoiceId,
        Guid OrderId,
        DateTime CreatedAt,
        double Total
    );
}
