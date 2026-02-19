namespace Domain_Service.RepoInterfaces.Email
{
    public interface IEmailManager
    {
        /// <summary>
        /// Sends OTP email for user registration verification
        /// </summary>
        Task<bool> SendRegistrationOtpEmail(string toEmail, string userName, string otp);

        /// <summary>
        /// Sends OTP email for password reset
        /// </summary>
        Task<bool> SendPasswordResetOtpEmail(string toEmail, string userName, string otp);

        /// <summary>
        /// Sends welcome email after successful registration
        /// </summary>
        Task<bool> SendWelcomeEmail(string toEmail, string userName);

        /// <summary>
        /// Sends order confirmation email to customer
        /// </summary>
        Task<bool> SendOrderConfirmationEmail(string toEmail, string orderDetails);

        /// <summary>
        /// Generic method to send any custom email
        /// </summary>
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
    }
}
