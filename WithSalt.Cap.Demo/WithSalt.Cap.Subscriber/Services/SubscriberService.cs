using DotNetCore.CAP;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithSalt.Cap.Subscriber.Services
{
    class SubscriberService : ISubscriberService
    {
        private ILogger<SubscriberService> _logger;

        public SubscriberService(ILogger<SubscriberService> logger)
        {
            _logger = logger;
        }

        [CapSubscribe("DefaultCapDemo")]
        public void ReceivedMessage(string content)
        {
            _logger.LogInformation("Receive from CAP:" + content);
        }
    }
}
