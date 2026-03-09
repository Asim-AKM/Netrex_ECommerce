namespace Application_Service.DTO_s.PaymentAndPayoutDtos
{
    /// <summary>
    /// Data Transfer Object used to receive payment details from the client
    /// during the checkout process.
    /// 
    /// This DTO supports multiple payment methods including:
    /// 1. Cash on Delivery (COD)
    /// 2. Online Card Payment
    /// 3. Bank Transfer
    /// 4. Mobile Wallets (EasyPaisa, JazzCash, NayaPay, etc.)
    /// 
    /// Depending on the selected payment method, only the relevant fields
    /// will be used by the backend service.
    /// </summary>
    public record PaymentDetailDto(

        /// <summary>
        /// Main payment method selected by the user.
        /// Possible values:
        /// "online"  -> User will pay using card, bank transfer, or wallet
        /// "cod"     -> Cash on Delivery
        /// </summary>
        string PaymentMethod,

        /// <summary>
        /// Specifies the type of online payment.
        /// Possible values:
        /// "card"    -> Credit/Debit card payment
        /// "bank"    -> Bank transfer
        /// "wallet"  -> Mobile wallet payment
        /// </summary>
        string OnlineOption,


        // =============================
        // Card Payment Details
        // =============================

        /// <summary>
        /// Credit or debit card number entered by the user.
        /// Used only when OnlineOption = "card".
        /// </summary>
        string CardNumber,

        /// <summary>
        /// Name of the card holder as written on the card.
        /// Used only when OnlineOption = "card".
        /// </summary>
        string CardHolderName,

        /// <summary>
        /// Card expiry date (format example: MM/YY).
        /// Used only when OnlineOption = "card".
        /// </summary>
        string ExpiryDate,

        /// <summary>
        /// Card verification value (CVV).
        /// Used only when OnlineOption = "card".
        /// </summary>
        string CVV,


        // =============================
        // Bank Transfer Details
        // =============================

        /// <summary>
        /// Name of the bank selected by the user
        /// (Example: HBL, UBL, Meezan Bank).
        /// Used only when OnlineOption = "bank".
        /// </summary>
        string BankName,

        /// <summary>
        /// File path or reference to the uploaded payment receipt
        /// for bank transfer verification.
        /// Used only when OnlineOption = "bank".
        /// </summary>
        string ReceiptFilePath,


        // =============================
        // Mobile Wallet Payment Details
        // =============================

        /// <summary>
        /// Name of the mobile wallet used for payment.
        /// Examples: EasyPaisa, JazzCash, NayaPay, SadaPay.
        /// Used only when OnlineOption = "wallet".
        /// </summary>
        string WalletName,

        /// <summary>
        /// Mobile number associated with the selected wallet.
        /// Used to verify the wallet payment.
        /// </summary>
        string MobileNumber
    );
}