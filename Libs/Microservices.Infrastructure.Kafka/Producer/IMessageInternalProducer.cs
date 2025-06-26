using Microservices.Messages.Base;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public interface IMessageInternalProducer
    {
        void Dispose();
        Task SendMessageAsync(Message message);
    }
}