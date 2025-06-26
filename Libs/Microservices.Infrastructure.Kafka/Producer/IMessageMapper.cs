using Microservices.Messages.Base;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public interface IMessageMapper
    {
        void AddMessage<TMessage>(string topicKey) where TMessage : Message;
        IEnumerable<string> GetAllEventTopics();
        IEnumerable<string> GetCommandTopicsForMessage(Message message);
    }
}