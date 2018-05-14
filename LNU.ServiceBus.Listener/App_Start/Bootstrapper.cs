using Autofac;
using EmailService.API;
using EmailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LNU.ServiceBus.Listener
{
    static class Bootstrapper
    {
        public static void Bootstrap(ContainerBuilder builder)
        {
            builder.Register(c => new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailAdress"], ConfigurationManager.AppSettings["EmailPassword"])
            }).As<SmtpClient>();
            builder.RegisterType<EmailClient>().As<IEmailService>();
        }
    }
}
