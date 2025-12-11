using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Linq.Expressions;

namespace Application_Service.Common.Email
{
    internal class MailService
    {
        private static readonly string _smtpServer = "smtp.gmail.com";
        private static readonly int _port = 587;
        private static readonly string _fromEmail = "muhammadshoaob26@gmail.com";
        private static readonly string _password = " "; // Gmail app password

        public static async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Netrex Ecommerce", _fromEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                message.Body = new TextPart("html") { Text = body };

                using var client = new SmtpClient();

                await client.ConnectAsync(_smtpServer, _port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_fromEmail, _password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return false; // SUCCESS
            }
            catch (Exception)
            {
                return true; // FAILURE (internet issue, SMTP down, wrong password, etc.)
            }
        }
    }


}

