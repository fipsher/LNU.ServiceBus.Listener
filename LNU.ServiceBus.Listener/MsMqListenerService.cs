using LNU.ServiceBus.App.Core;

namespace LNU.ServiceBus.Listener
{
    public class MsMqListenerService : IService
    {
        private readonly string _queueName;
        private readonly string _endpoint;
        private MsMqListener _listener;

        public MsMqListenerService(string queueName, string endpoint)
        {
            this._queueName = queueName;
            this._endpoint = endpoint;
        }

        public async void OnStart()
        {
            _listener = new MsMqListener(_queueName, _endpoint);

            await _listener.Run().ConfigureAwait(false);
        }

        public void OnStop()
        {
            _listener?.Dispose();
        }
    }
}
