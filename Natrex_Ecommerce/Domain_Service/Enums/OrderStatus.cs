namespace Domain_Service.Enums
{
    /// <summary>
    /// Represents all the possible stages an order goes through 
    /// during its lifecycle in the system.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order has been created but payment is not completed yet.
        /// Example: User placed order but hasn't paid.
        /// </summary>
        Pending,

        /// <summary>
        /// Payment is verified and seller is preparing the order.
        /// Example: Packing, invoicing, warehouse processing.
        /// </summary>
        Processing,

        /// <summary>
        /// Order has been handed over to the courier.
        /// Tracking number is generated.
        /// </summary>
        Shipped,
 

        /// <summary>
        /// Order has been delivered successfully to the customer.
        /// </summary>
        Delivered,

        /// <summary>
        /// Order has been cancelled by the customer or system.
        /// Example: User cancelled or product was out of stock.
        /// </summary>
        Cancelled
    }

}
