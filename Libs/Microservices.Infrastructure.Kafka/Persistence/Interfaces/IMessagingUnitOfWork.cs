using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Infrastructure.Kafka.Persistence.Interfaces
{
    public interface IMessagingUnitOfWork : IGenericUnitOfWork
    {       
        IOutboxMessageRepository OutboxMessage { get; }
    }
}
