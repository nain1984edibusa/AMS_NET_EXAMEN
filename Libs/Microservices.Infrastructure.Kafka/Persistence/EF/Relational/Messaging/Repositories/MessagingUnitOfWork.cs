using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts;
using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;

namespace Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Repositories
{
    public class MessagingUnitOfWork : GenericUnitOfWork<MessagingDbContext>, IMessagingUnitOfWork
    {
        public IOutboxMessageRepository OutboxMessage { get; }

        public MessagingUnitOfWork(
            MessagingDbContext context, 
            IOutboxMessageRepository outboxMessage
        ) : base(context)
        {
            OutboxMessage = outboxMessage;
        }
    }

}
