using System.Text.Json;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Infrastructure.Kafka.Persistence.Models
{
    public class OutboxMessage: Entity<long>, IAggregateRoot
    {        
        protected OutboxMessage() { }     
        public OutboxMessage(object message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            Type = message.GetType().FullName + ", " + message.GetType().Assembly.GetName().Name;
            Payload = JsonSerializer.Serialize(message, message.GetType());
        }               
        public virtual string Type { get; protected set; }
        public virtual string Payload { get; protected set; }
                
        public virtual object RecreateMessage()
        {
            var messageType = System.Type.GetType(Type);
            if (messageType == null)
                throw new InvalidOperationException($"Could not resolve type: {Type}");
            return JsonSerializer.Deserialize(Payload, messageType);
        }
    }
}
