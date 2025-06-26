using Microservices.Messages.Base;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public interface IMessageProducer
    {
        Task PublishMessage<T>(T message) where T : Message;
    }
}
