using EmailService.Interfaces;
using EmailService.Models;
using LNU.ServiceBus.Listener.Core;
//using NBUS6.Models;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LNU.ServiceBus.Listener.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<ListenerCommand<EmailMessage>>
    {
        public PlaceOrderHandler(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        private static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
        private readonly IEmailService emailService;

        public async Task Handle(ListenerCommand<EmailMessage> message, IMessageHandlerContext context)
        {
            log.Info($"Sending Email: {message.Id} to {message.Message.ToAdress}");
            message.Message.FromAdress = new MailAddress(ConfigurationManager.AppSettings["EmailAdress"], $"LNU Emailer");

            try
            {
                await emailService.SendMailAsync(message.Message);
            }
            catch (Exception e)
            {
                log.Error("[WHoops] Email sending failed", e);
            }
        }
    }
}
