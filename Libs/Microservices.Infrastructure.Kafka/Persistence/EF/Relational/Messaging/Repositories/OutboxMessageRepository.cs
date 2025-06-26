using Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Contexts;
using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Infrastructure.Kafka.Persistence.EF.Relational.Messaging.Repositories
{
    public class OutboxMessageRepository : Repository<OutboxMessage, MessagingDbContext>, IOutboxMessageRepository
    {
        public OutboxMessageRepository(MessagingDbContext context) : base(context) { }
        public async Task<List<OutboxMessage>> GetOutboxMessageToPushAsync()
        {
            return await _context.OutboxMessage
                .OrderBy(m => m.Id)
                .Take(50)
                .ToListAsync();
        }

    }
}
