using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Consumer;
using Microservices.Infrastructure.Kafka.Producer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Extensions
{
    internal static class KafkaMapperExtensions
    {
        internal static IServiceCollection AddKafkaHandler(
           this IServiceCollection services,
           Action<HandlerMessageMapper> mappingHandlerConfig,
           HandlerMessageMapper handlerMessageMapper,
           KafkaConfig kafkaConfig
       )
        {            
            mappingHandlerConfig(handlerMessageMapper);

            foreach (var assembly in handlerMessageMapper.GetAssemblies())
            {
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            }

            return services;
        }
        internal static IServiceCollection AddKafkaMessage(
            this IServiceCollection services,
            Action<MessageMapper> mappingConfig,
            MessageMapper messageMapper,
            KafkaConfig kafkaConfig
        )
        {  
            mappingConfig(messageMapper);

            return services;
        }
    }
}
