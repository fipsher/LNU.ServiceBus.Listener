using NServiceBus;
using System;

namespace LNU.ServiceBus.Listener.Core
{
    public class ListenerCommand<T> : ICommand
    {
        public Guid Id { get; set; }

        public T Message { get; set; }
    }
}
