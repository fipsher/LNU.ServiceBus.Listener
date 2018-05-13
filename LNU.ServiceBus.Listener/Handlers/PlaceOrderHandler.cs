using LNU.ServiceBus.Listener.Core;
//using NBUS6.Models;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;

namespace LNU.ServiceBus.Listener.Handlers
{
    public class PlaceOrderHandler : IHandleMessages<ListenerCommand<EmailMessage>>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(ListenerCommand<EmailMessage> message, IMessageHandlerContext context)
        {
            //log.Info($"Order for Product:{message.Message.Product} placed with id: {message.Message.Id}");
            log.Info($"Publishing: OrderPlaced for Order Id: {message.Id}");

            return Task.CompletedTask;
        }
    }
}
