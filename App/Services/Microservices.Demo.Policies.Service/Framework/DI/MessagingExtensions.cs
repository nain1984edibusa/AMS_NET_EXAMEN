using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Extensions;
using Microservices.Infrastructure.Kafka.Producer;

namespace Microservices.Demo.Policies.Service.Framework.DI
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddKafka(configuration, opt =>
            {
                opt.AddMessage<PolicyCreatedEvent>("Policy");
                opt.AddMessage<PolicyTerminatedEvent>("Policy");
            });

            return services;
        }
        public static async Task<WebApplication> UseDbMessagingAsync(this WebApplication app)
        {
            await app.Services.UseKafkaDataAsync();
            return app;
        }
    }
}
