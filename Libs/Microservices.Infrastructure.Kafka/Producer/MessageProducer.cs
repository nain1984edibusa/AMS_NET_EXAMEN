using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microservices.Messages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IMessagingUnitOfWork _unitOfWork;
        private readonly KafkaConfig _kafkaConfig;
        private readonly IMessageInternalProducer _messageInternalProducer;

        public MessageProducer(
            IMessagingUnitOfWork messagingUnitOfWork,
            IMessageInternalProducer messageInternalProducer,
            KafkaConfig kafkaConfig
        )
        {
            _kafkaConfig = kafkaConfig;
            _messageInternalProducer = messageInternalProducer;
            _unitOfWork = messagingUnitOfWork;
        }

        public async Task PublishMessage<T>(T message) where T : Message
        {
            if (_kafkaConfig.Persistence.Enabled)
            {
                await _unitOfWork.OutboxMessage.AddAsync(new OutboxMessage(message));
                await _unitOfWork.CompleteAsync();
            }
            else
            {
                await _messageInternalProducer.SendMessageAsync(message);
            }
        }
    }
}
