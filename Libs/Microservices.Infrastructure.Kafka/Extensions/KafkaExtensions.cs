using Confluent.Kafka;
using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Consumer;
using Microservices.Infrastructure.Kafka.Persistence.Data;
using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts;
using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Repositories;
using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Kafka.Producer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Microservices.Infrastructure.Kafka.Extensions
{
    public static class KafkaExtensions
    {
        public static IServiceCollection AddKafka(
          this IServiceCollection services,
          IConfigurationManager configuration,
          Action<HandlerMessageMapper> mappingHandlerConfig        
      )
        {
            var kafkaConfig = configuration.GetSection("Kafka").Get<KafkaConfig>();
            var messageMapper = new MessageMapper(kafkaConfig);
            var handlerMessageMapper = new HandlerMessageMapper();
            services.AddSingleton(kafkaConfig);
            services.AddSingleton<IMessageMapper>(messageMapper);
            services.AddSingleton<IHandlerMessageMapper>(handlerMessageMapper);

            services.AddKafkaHandler(mappingHandlerConfig,handlerMessageMapper, kafkaConfig);
            services.AddKafkaInternal(kafkaConfig);

            return services;
        }
        public static IServiceCollection AddKafka(
            this IServiceCollection services,
            IConfigurationManager configuration,
            Action<MessageMapper> mappingConfig
        )
        {
            var kafkaConfig = configuration.GetSection("Kafka").Get<KafkaConfig>();
            var messageMapper = new MessageMapper(kafkaConfig);
            var handlerMessageMapper = new HandlerMessageMapper();
            services.AddSingleton(kafkaConfig);
            services.AddSingleton<IMessageMapper>(messageMapper);
            services.AddSingleton<IHandlerMessageMapper>(handlerMessageMapper);

            services.AddKafkaMessage(mappingConfig, messageMapper, kafkaConfig);
            services.AddKafkaInternal(kafkaConfig);

            return services;
        }

        public static IServiceCollection AddKafka(
            this IServiceCollection services,
            IConfigurationManager configuration,
            Action<HandlerMessageMapper> mappingHandlerConfig,
            Action<MessageMapper> mappingConfig
        )
        {
            var kafkaConfig = configuration.GetSection("Kafka").Get<KafkaConfig>();
            var messageMapper = new MessageMapper(kafkaConfig);
            var handlerMessageMapper = new HandlerMessageMapper();
            services.AddSingleton(kafkaConfig);            
            services.AddSingleton<IMessageMapper>(messageMapper);
            services.AddSingleton<IHandlerMessageMapper>(handlerMessageMapper);


            services.AddKafkaHandler(mappingHandlerConfig, handlerMessageMapper, kafkaConfig);
            services.AddKafkaMessage(mappingConfig, messageMapper,kafkaConfig);
            services.AddKafkaInternal(kafkaConfig);

            return services;
        }

        private static IServiceCollection AddKafkaInternal(
            this IServiceCollection services,
            KafkaConfig kafkaConfig
        )
        {
            services.AddKafkaConsumers(kafkaConfig);
            services.AddKafkaProducer(kafkaConfig);

            return services;
        }


        public static async Task UseKafkaDataAsync(this IServiceProvider provider)
        {   
            using var scope = provider.CreateScope();
            var kafkaConfig = scope.ServiceProvider.GetRequiredService<KafkaConfig>();

            if (kafkaConfig.Persistence.Enabled)
            {
                var uow = scope.ServiceProvider.GetRequiredService<IMessagingUnitOfWork>();
                await DbInitialize.InitializeAsync(uow);
            }
        }
    }
}
