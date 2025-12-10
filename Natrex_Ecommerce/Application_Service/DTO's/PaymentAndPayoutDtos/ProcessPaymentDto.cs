using Domain_Service.Enums;
using System;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) used for processing a payment.
    /// Contains essential information required to create a payment record.
    /// </summary>
    /// <remarks>
    /// This DTO is immutable (read-only) and uses the C# 9 record type.
    /// It is intended for scenarios such as initiating a payment transaction
    /// from the frontend or API request to the payment processing service.
    /// </remarks>
    /// <param name="OrderId">Unique identifier of the order for which the payment is being processed.</param>
    /// <param name="PaymentMethod">Method of payment used (e.g., Cash, Card, JazzCash, Easypaisa).</param>
    /// <param name="AmountPaid">Amount to be paid by the customer.</param>
    public record ProcessPaymentDto(
        Guid OrderId,
        PaymentMethod PaymentMethod,
        double AmountPaid
    );
}
