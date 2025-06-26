using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts.Configurations
{
    public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {               
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Type)
                .HasColumnName("Type")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(m => m.Payload)
                .HasColumnName("JsonPayload")
                .IsRequired()
                .HasMaxLength(8000);
        }
    }
}
