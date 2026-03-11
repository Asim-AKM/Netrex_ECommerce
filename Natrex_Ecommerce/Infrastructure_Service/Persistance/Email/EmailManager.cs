namespace Infrastructure_Service.Persistance.Email
{
    public class EmailManager : IEmailManager
    {
        private static readonly string _smtpServer = "smtp.gmail.com";
        private static readonly int _port = 587;
        private static readonly string _fromEmail = "netrexecommerce@gmail.com";
        private static readonly string _password = "uyrh nuap pnwh gjpd"; 
        private static readonly string _fromName = "Netrex Ecommerce";

        public async Task<bool> SendRegistrationOtpEmail(string toEmail, string userName, string otp)
        {
            var subject = "Email Verification - Netrex Ecommerce";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                        .container {{ max-width: 600px; margin: 50px auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
                        .header {{ text-align: center; color: #2980b9; margin-bottom: 20px; }}
                        .otp-box {{ background-color: #ecf0f1; padding: 20px; text-align: center; border-radius: 5px; margin: 20px 0; }}
                        .otp {{ font-size: 32px; font-weight: bold; color: #2c3e50; letter-spacing: 5px; }}
                        .footer {{ margin-top: 30px; text-align: center; color: #7f8c8d; font-size: 12px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Welcome to Netrex Ecommerce!</h1>
                        </div>
                        <p>Hi {userName},</p>
                        <p>Thank you for registering with Netrex Ecommerce. To complete your registration, please verify your email address using the OTP below:</p>
                        <div class='otp-box'>
                            <div class='otp'>{otp}</div>
                        </div>
                        <p><strong>This OTP is valid for 5 minutes.</strong></p>
                        <p>If you didn't request this verification, please ignore this email.</p>
                        <div class='footer'>
                            <p>&copy; 2025 Netrex Ecommerce. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            return await SendEmailAsync(toEmail, subject, body);
        }

        public async Task<bool> SendPasswordResetOtpEmail(string toEmail, string userName, string otp)
        {
            var subject = "Password Reset OTP - Netrex Ecommerce";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                        .container {{ max-width: 600px; margin: 50px auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
                        .header {{ text-align: center; color: #e74c3c; margin-bottom: 20px; }}
                        .otp-box {{ background-color: #fadbd8; padding: 20px; text-align: center; border-radius: 5px; margin: 20px 0; }}
                        .otp {{ font-size: 32px; font-weight: bold; color: #c0392b; letter-spacing: 5px; }}
                        .footer {{ margin-top: 30px; text-align: center; color: #7f8c8d; font-size: 12px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Password Reset Request</h1>
                        </div>
                        <p>Hi {userName},</p>
                        <p>We received a request to reset your password. Use the OTP below to reset your password:</p>
                        <div class='otp-box'>
                            <div class='otp'>{otp}</div>
                        </div>
                        <p><strong>This OTP is valid for 5 minutes.</strong></p>
                        <p>If you didn't request a password reset, please ignore this email or contact support if you have concerns.</p>
                        <div class='footer'>
                            <p>&copy; 2025 Netrex Ecommerce. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            return await SendEmailAsync(toEmail, subject, body);
        }

        public async Task<bool> SendWelcomeEmail(string toEmail, string userName)
        {
            var subject = "Welcome to Netrex Ecommerce!";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                        .container {{ max-width: 600px; margin: 50px auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
                        .header {{ text-align: center; color: #27ae60; margin-bottom: 20px; }}
                        .footer {{ margin-top: 30px; text-align: center; color: #7f8c8d; font-size: 12px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>🎉 Welcome to Netrex!</h1>
                        </div>
                        <p>Hi {userName},</p>
                        <p>Your email has been successfully verified! You can now enjoy shopping on Netrex Ecommerce.</p>
                        <p>Start exploring our wide range of products and enjoy amazing deals!</p>
                        <div class='footer'>
                            <p>&copy; 2025 Netrex Ecommerce. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            return await SendEmailAsync(toEmail, subject, body);
        }

        public async Task<bool> SendOrderConfirmationEmail(string toEmail, string orderDetails)
        {
            var subject = "Order Confirmation - Netrex Ecommerce";
            var body = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
                        .container {{ max-width: 600px; margin: 50px auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
                        .header {{ text-align: center; color: #2980b9; margin-bottom: 20px; }}
                        .footer {{ margin-top: 30px; text-align: center; color: #7f8c8d; font-size: 12px; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Order Confirmed!</h1>
                        </div>
                        <p>Your order has been successfully placed.</p>
                        <div>{orderDetails}</div>
                        <div class='footer'>
                            <p>&copy; 2025 Netrex Ecommerce. All rights reserved.</p>
                        </div>
                    </div>
                </body>
                </html>
            ";

            return await SendEmailAsync(toEmail, subject, body);
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_fromName, _fromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;
                message.Body = new TextPart("html") { Text = body };

                using var client = new SmtpClient();
                await client.ConnectAsync(_smtpServer, _port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_fromEmail, _password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return true; // SUCCESS
            }
            catch (Exception)
            {
                return false; // FAILURE
            }
        }
    }
}
