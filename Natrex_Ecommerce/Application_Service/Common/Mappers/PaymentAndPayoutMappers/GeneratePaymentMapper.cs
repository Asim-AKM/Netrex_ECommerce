using Application_Service.DTO_s.PaymentAndPayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;
using Domain_Service.Enums;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    /// <summary>
    /// Static mapper class for converting between Payment-related DTOs and Entities.
    /// Provides extension methods to map <see cref="ProcessPaymentDto"/> to <see cref="PaymentDetail"/>
    /// and <see cref="PaymentDetail"/> to <see cref="FetchPaymentDto"/>.
    /// </summary>
    public static class PaymentMapper
    {
        /// <summary>
        /// Maps a <see cref="ProcessPaymentDto"/> to a <see cref="PaymentDetail"/> entity.
        /// </summary>
        /// <param name="dto">The payment DTO containing the data to be processed.</param>
        /// <returns>A new <see cref="PaymentDetail"/> entity with a generated PaymentDetailId and TransactionId,
        /// current UTC creation timestamp, and success status.</returns>
        /// <remarks>
        /// This method automatically generates:
        /// - PaymentDetailId (new Guid)
        /// - TransactionId (mocked Guid string)
        /// - CreatedAt (DateTime.UtcNow)
        /// - PaymentStatus is set to Success by default.
        /// </remarks>
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

        /// <summary>
        /// Maps a <see cref="PaymentDetail"/> entity to a <see cref="FetchPaymentDto"/>.
        /// </summary>
        /// <param name="entity">The <see cref="PaymentDetail"/> entity to convert.</param>
        /// <returns>A <see cref="FetchPaymentDto"/> containing the same payment details for read operations.</returns>
        /// <remarks>
        /// This method is intended for sending payment details to the client
        /// without exposing the internal entity directly.
        /// </remarks>
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
