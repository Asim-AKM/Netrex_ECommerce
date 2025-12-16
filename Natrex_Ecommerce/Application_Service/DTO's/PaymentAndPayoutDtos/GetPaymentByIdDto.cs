using Domain_Service.Enums;

namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    /// <summary>
    /// Data Transfer Object (DTO) for fetching payment details.
    /// Used to transfer PaymentDetail information between layers 
    /// without exposing the entity directly.
    /// </summary>
    /// <remarks>
    /// This DTO is read-only (immutable) and uses the C# 9 record type.
    /// It is intended for scenarios like listing payments, viewing payment details, etc.
    /// </remarks>
    /// <param name="PaymentDetailId">Unique identifier of the payment detail record.</param>
    /// <param name="OrderId">Unique identifier of the associated order.</param>
    /// <param name="PaymentMethod">The method used for payment (e.g., Cash, Card, JazzCash, Easypaisa).</param>
    /// <param name="TransactionId">The transaction reference number returned by the payment gateway.</param>
    /// <param name="PaymentStatus">Current status of the payment (e.g., Pending, Paid, Failed).</param>
    /// <param name="AmountPaid">Amount actually paid by the user for this order.</param>
    /// <param name="CreatedAt">Timestamp when this payment record was created.</param>
    public record GetPaymentByIdDto(
        Guid PaymentDetailId,
        Guid OrderId,
        PaymentMethod PaymentMethod,
        string TransactionId,
        PaymentStatus PaymentStatus,
        double AmountPaid,
        DateTime CreatedAt
    );
}
