using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts.Configurations;
using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts
{
    public partial class MessagingDbContext : DbContext
    {
        private readonly KafkaConfig _kafkaConfig;
        public MessagingDbContext(DbContextOptions<MessagingDbContext> options, KafkaConfig kafkaConfig) 
            : base(options) 
        {
            _kafkaConfig = kafkaConfig;
        }

        public DbSet<OutboxMessage> OutboxMessage { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
            modelBuilder.Entity<OutboxMessage>().ToTable(_kafkaConfig.Persistence.Outbox.TableName);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
