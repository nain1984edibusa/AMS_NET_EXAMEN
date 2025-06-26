using Microservices.Demo.Policies.Search.Service.Framework.Messaging.Policy.Inbox.Events;
using Microservices.Infrastructure.Kafka.Extensions;
using Microsoft.Extensions.Configuration;

namespace Microservices.Demo.Policies.Search.Service.Framework.DI
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddKafka(configuration, opt =>
            {
                opt.AddHandlerMessage<PolicyCreatedEventHandler>();
            });

            return services;
        }
    }
}
