using Microservices.Infrastructure.Kafka.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public class CommandConsumerWorker : MessageConsumerWorker
    {
        public CommandConsumerWorker(
            ILogger<MessageConsumerWorker> logger, 
            //IMessageProcessor processor, 
            TopicConfig topicConfig, 
            string bootstrapServers, 
            IServiceScopeFactory  scopeFactory
        ) : base(logger, topicConfig, bootstrapServers, scopeFactory)
        {
        }
    }
}
