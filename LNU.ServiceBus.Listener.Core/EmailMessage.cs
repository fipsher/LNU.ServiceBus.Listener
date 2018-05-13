using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNU.ServiceBus.Listener.Core
{
    public class EmailMessage
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string ReceiverEmail { get; set; }
    }
}
