using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Service.Entities.PaymentAndPayout
{
    /// <summary>
    /// Represents an invoice entity in the domain layer.
    /// Contains details about a specific invoice generated for an order.
    /// </summary>
    /// <remarks>
    /// This class is part of the domain layer in Clean Architecture.
    /// It should be persisted via repository patterns and should not
    /// be exposed directly to the client; use DTOs instead.
    /// </remarks>
    public class Invoice
    {
        /// <summary>
        /// Unique identifier for the invoice.
        /// </summary>
        [Key]
        public Guid InvoiceId { get; set; }

        /// <summary>
        /// Unique identifier of the associated order for which this invoice is generated.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Date and time when the invoice was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Total amount of the invoice.
        /// </summary>
        public double Total { get; set; }
    }
}
