using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Consumer;
using Microservices.Infrastructure.Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Extensions
{
    internal static class KafkaProcessorExtensions
    {
        internal static IServiceCollection AddKafkaProducer(
            this IServiceCollection services,
            KafkaConfig kafkaConfig
        )
        {
            if (kafkaConfig.Producers != null)
            {

                services.AddSingleton<IMessageInternalProducer>(provider =>
                {
                    IMessageMapper messageMapper = provider.GetRequiredService<IMessageMapper>();
                    return new MessageInternalProducer(kafkaConfig, messageMapper);
                });

                services.AddMessageOutbox(kafkaConfig);
            }

            return services;
        }
        internal static IServiceCollection AddKafkaConsumers(
            this IServiceCollection services,
            KafkaConfig kafkaConfig)
        {

            if (kafkaConfig.Consumers != null)
            {
                services.AddTransient<IMessageProcessor, MessageProcessor>();

                if (kafkaConfig.Consumers.Events.Topics.Count() > 0)
                {
                    AddMessageConsumerWorkerWithProcessor(services, kafkaConfig, TypeWorker.Event);
                }

                if (kafkaConfig.Consumers.Commands.Topics.Count() > 0)
                {
                    AddMessageConsumerWorkerWithProcessor(services, kafkaConfig, TypeWorker.Command);
                }
            }

            return services;
        }
        private static IServiceCollection AddMessageConsumerWorkerWithProcessor(
            this IServiceCollection services,
            KafkaConfig kafkaConfig,
            TypeWorker typeWorker
        )
        {
            if (typeWorker == TypeWorker.Event)
            {
                services.AddHostedService(provider =>
                {
                    //IMessageProcessor messageProcessor = provider.GetRequiredService<IMessageProcessor>();
                    ILogger<EventConsumerWorker> logger = provider.GetRequiredService<ILogger<EventConsumerWorker>>();
                    IServiceScopeFactory scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                    return new EventConsumerWorker(logger, kafkaConfig.Consumers.Events, kafkaConfig.BootstrapServers, scopeFactory);
                });
            }
            if (typeWorker == TypeWorker.Command)
            {
                services.AddHostedService(provider =>
                {
                    //IMessageProcessor messageProcessor = provider.GetRequiredService<IMessageProcessor>();
                    ILogger<CommandConsumerWorker> logger = provider.GetRequiredService<ILogger<CommandConsumerWorker>>();
                    IServiceScopeFactory scopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                    return new CommandConsumerWorker(logger, kafkaConfig.Consumers.Commands, kafkaConfig.BootstrapServers, scopeFactory);
                });
            }

            return services;
        }

    }
}
