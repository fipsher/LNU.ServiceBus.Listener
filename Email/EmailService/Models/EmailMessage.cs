using System.Net.Mail;

namespace EmailService.Models
{
    public class EmailMessage
    {
        public string Subject { get; set; }

        public string Message { get; set; }

        public bool IsHtml { get; set; }

        public MailAddress FromAdress { get; set; }

        public string ToAdress { get; set; }
    }
}
