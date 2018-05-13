using LNU.ServiceBus.App.Core;
using LNU.ServiceBus.Listener;
using System.Collections.Generic;
using System.Configuration;

namespace LNU.ServiceBus.App
{
    public class ServiceFactory : IService
    {
        private readonly List<IService> services;

        public ServiceFactory()
        {
            services = new List<IService>{
                new MsMqListenerService(ConfigurationManager.AppSettings["queue"], ConfigurationManager.AppSettings["endpoint"])
            };
        }

        public void OnStart()
        {
            services.ForEach(service => service.OnStart());
        }

        public void OnStop()
        {
            services.ForEach(service => service.OnStop());
        }
    }
}
