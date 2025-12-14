namespace Domain_Service.Enums
{
    /// <summary>
    /// Defines the payment methods supported by the system.
    /// These values represent the platform through which the customer
    /// completes the payment for their order.
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Payment made using EasyPaisa mobile wallet.
        /// Example: Customer enters EasyPaisa account number or approves via app.
        /// </summary>
        EasyPaisa,

        /// <summary>
        /// Payment made using JazzCash mobile wallet.
        /// Example: Customer pays through JazzCash app or voucher code.
        /// </summary>
        JazzCash
    }

}
