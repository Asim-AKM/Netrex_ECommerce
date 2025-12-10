using Domain_Service.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain_Service.Entities.SellerPaymentModule
{
    /// <summary>
    /// Represents a payout transaction made to a seller for a completed order.
    /// </summary>
    /// <remarks>
    /// This entity captures all information related to seller settlements,
    /// including payout amount, status, and associated order details.
    /// It is part of the Seller Payment / Settlement module.
    /// </remarks>
    public class SellerPayout
    {
        /// <summary>
        /// Primary key that uniquely identifies each seller payout record.
        /// </summary>
        [Key]
        public Guid SellerPayoutId { get; set; }

        /// <summary>
        /// Foreign key referencing the seller who will receive the payout.
        /// </summary>
        public Guid SellerId { get; set; }

        /// <summary>
        /// Foreign key referencing the order for which payout is being made.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// The total amount the seller will receive for the order after
        /// applying commissions, fees, and other calculations.
        /// </summary>
        public double AmountToPay { get; set; }

        /// <summary>
        /// Indicates whether the payout is pending, successful, or failed.
        /// </summary>
        /// <seealso cref="PaymentStatus"/>
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// The date and time when the payout was completed or is scheduled.
        /// </summary>
        public DateTime PayOutDate { get; set; }
    }
}
