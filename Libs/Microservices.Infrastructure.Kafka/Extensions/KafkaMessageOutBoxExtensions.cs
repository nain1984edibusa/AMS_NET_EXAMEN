using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts;
using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Repositories;
using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Kafka.Producer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Extensions
{
    internal static class KafkaMessageOutBoxExtensions
    {
        internal static IServiceCollection AddMessageOutbox(
            this IServiceCollection services,
            KafkaConfig kafkaConfig
        )
        {
            services.AddDbContext<MessagingDbContext>(options =>
            {
                options.UseSqlServer(kafkaConfig.Persistence.Outbox.MessagingConnection,
                    opt => opt.MigrationsHistoryTable("__EFMigrationsHistory_MessageOutbox")
                );

                if (kafkaConfig.Persistence.Outbox.DisableLogs)
                {
                    options.UseLoggerFactory(NullLoggerFactory.Instance);
                }
            });

            services.AddScoped<IOutboxMessageRepository, OutboxMessageRepository>();
            services.AddScoped<IMessagingUnitOfWork, MessagingUnitOfWork>();
            services.AddScoped<IMessageProducer, MessageProducer>();

            services.AddScoped<MessageOutbox>();

            if (kafkaConfig.Persistence != null && kafkaConfig.Persistence.Enabled && kafkaConfig.Persistence.Outbox != null)
            {                
                services.AddHostedService<MessageProducerWorker>();
            }

            return services;
        }
    }
}
