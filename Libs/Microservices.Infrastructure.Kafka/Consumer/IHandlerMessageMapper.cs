using System.Reflection;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public interface IHandlerMessageMapper
    {
        void AddHandlerMessage<THandlerMessage>();
        IEnumerable<Assembly> GetAssemblies();
    }
}