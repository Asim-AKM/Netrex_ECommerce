using Application_Service.DTO_s.Payment_PayoutDtos;
using Domain_Service.Entities.PaymentAndPayout;

namespace Application_Service.Common.Mappers.PaymentAndPayoutMappers
{
    /// <summary>
    /// Static mapper class for converting <see cref="InvoiceDto"/> objects
    /// into <see cref="Invoice"/> entities.
    /// </summary>
    /// <remarks>
    /// This mapper is intended for creating new Invoice domain entities
    /// from input DTOs when generating invoices for orders.
    /// </remarks>
    public static class GenerateInvoiceMapper
    {
        /// <summary>
        /// Maps an <see cref="InvoiceDto"/> to a new <see cref="Invoice"/> entity.
        /// </summary>
        /// <param name="dto">The <see cref="InvoiceDto"/> containing input data for invoice generation.</param>
        /// <returns>A new <see cref="Invoice"/> entity with a generated <see cref="Invoice.InvoiceId"/> 
        /// and current UTC creation timestamp.</returns>
        /// <remarks>
        /// This method automatically:
        /// - Generates a new unique <see cref="Invoice.InvoiceId"/> (Guid)
        /// - Sets <see cref="Invoice.CreatedAt"/> to <see cref="DateTime.UtcNow"/>
        /// - Copies <see cref="Invoice.OrderId"/> and <see cref="Invoice.Total"/> from the DTO
        /// 
        /// It ensures that the domain entity is properly initialized before being persisted.
        /// </remarks>
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
