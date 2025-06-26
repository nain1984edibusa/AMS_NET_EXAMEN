using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Infrastructure.Kafka.Persistence.Interfaces;

public interface IOutboxMessageRepository : IRepository<OutboxMessage>
{
    Task<List<OutboxMessage>> GetOutboxMessageToPushAsync();
}