using MediatR;
using Microservices.Messages.Base;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _provider;
        public MessageProcessor(
            IMediator mediator,
            IServiceProvider provider
        )
        {
            _mediator = mediator;
            _provider = provider;
        }

        public async Task ProcessCommand(Message message)
        {
            EnsureHandlerRegistered(message.GetType());
            await _mediator.Send((dynamic)message);
        }

        public async Task ProcessEvent(Message message)
        {
            EnsureHandlerRegistered(message.GetType());
            await _mediator.Send((dynamic)message);
        }
        private void EnsureHandlerRegistered(Type messageType)
        {            
            var handlerType = typeof(IRequestHandler<>).MakeGenericType(messageType);
            var handler = _provider.GetService(handlerType);
                        
            if (handler == null)
                throw new HandlerNotRegisteredException($"No handler registered for message type {messageType.FullName}");            
        }

    }
}
