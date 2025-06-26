using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public class MessageOutboxLogger
    {
        private readonly ILogger<MessageOutbox> logger;

        public MessageOutboxLogger(ILogger<MessageOutbox> logger)
        {
            this.logger = logger;
        }

        public void LogPending(IEnumerable<OutboxMessage> messages)
        {
            if (messages.Any() )
            {
                logger.LogInformation($"{messages.Count()} messages about to be pushed.");
            }            
        }

        public void LogSuccessPush()
        {
            logger.LogInformation("Successfully pushed message");
        }

        public void LogFailedPush(Exception e)
        {
            logger.LogError(e, "Failed to push message from outbox");
        }
    }
}
