using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Persistence.Legacy;
using System;
using System.Threading.Tasks;

namespace LNU.ServiceBus.Listener
{
    class MsMqListener : IDisposable
    {
        private readonly string _queue;
        private readonly string _endpoint;
        private bool _disposed = false;
        private IEndpointInstance _endpointInstance;

        public MsMqListener(string queueName, string endpoint)
        {
            this._queue = queueName;
            this._endpoint = endpoint;
        }

        public async Task Listen()
        {
            var endpointConfiguration = new EndpointConfiguration(_endpoint);
            endpointConfiguration.UseSerialization<JsonSerializer>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.DisableFeature<TimeoutManager>();
            endpointConfiguration.UsePersistence<MsmqPersistence>().SubscriptionQueue(_queue);
            endpointConfiguration.UseTransport<MsmqTransport>();
            endpointConfiguration.SendFailedMessagesTo("error");

            _endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
        }

        public async void Dispose()
        {
            if (!_disposed)
            {
                await _endpointInstance.Stop().ConfigureAwait(false);
                _disposed = true;
            }
        }
    }
}
