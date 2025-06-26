using Microservices.Demo.Payments.Service.Framework.Messaging.Policy.Inbox;
using Microservices.Infrastructure.Kafka.Extensions;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddKafka(configuration, opt =>
            {
                opt.AddHandlerMessage<PolicyCreatedEventHandler>();
                opt.AddHandlerMessage<PolicyTerminatedEventHandler>();
            });

            return services;
        }
    }
}
