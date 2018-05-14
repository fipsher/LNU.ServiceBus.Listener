using EmailService.Models;
using System.Threading.Tasks;

namespace EmailService.Interfaces
{
    public interface IEmailService
    {
        Task SendMailAsync(EmailMessage message);
    }
}
