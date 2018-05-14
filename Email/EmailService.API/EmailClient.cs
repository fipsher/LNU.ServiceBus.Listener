using EmailService.Interfaces;
using System;
using System.Threading.Tasks;
using EmailService.Models;
using System.Net.Mail;

namespace EmailService.API
{
    public class EmailClient : IEmailService
    {
        private readonly SmtpClient _client;

        public EmailClient(SmtpClient client)
        {
            _client = client;
        }

        public async Task SendMailAsync(EmailMessage message)
        {
            await _client.SendMailAsync(ConvertMessage(message));
        }

        private MailMessage ConvertMessage(EmailMessage message)
        {
            return new MailMessage(message.FromAdress, new MailAddress(message.ToAdress))
            {
                Subject = String.IsNullOrEmpty(message.Subject) ? String.Empty : message.Subject,
                IsBodyHtml = message.IsHtml,
                Body = message.Message
            };
        }
    }
}
