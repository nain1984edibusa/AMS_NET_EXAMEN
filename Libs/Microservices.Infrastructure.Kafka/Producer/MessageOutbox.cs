using Microservices.Infrastructure.Kafka.Persistence.Interfaces;
using Microservices.Infrastructure.Kafka.Persistence.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public class MessageOutbox
    {
        private readonly IMessageInternalProducer _messageInternalProducer;
        private readonly IMessagingUnitOfWork _unitOfWork;
        private readonly MessageOutboxLogger _logger;
        public MessageOutbox(
            IMessageInternalProducer messageInternalProducer,
            IMessagingUnitOfWork messagingUnitOfWork,
            ILogger<MessageOutbox> logger
        )
        {
            _messageInternalProducer = messageInternalProducer;
            _unitOfWork = messagingUnitOfWork;
            _logger = new MessageOutboxLogger(logger);
        }

        public async Task PushPendingMessagesAsync()
        {
            var messagesToPush = await FetchPendingMessagesAsync();
            _logger.LogPending(messagesToPush);

            foreach (var msg in messagesToPush)
                if (!await TryPush(msg))
                    break;
        }

        private async Task<IList<OutboxMessage>> FetchPendingMessagesAsync()
        {
            List<OutboxMessage> messagesToPush = await _unitOfWork.OutboxMessage.GetOutboxMessageToPushAsync();

            return messagesToPush;
        }
        private async Task<bool> TryPush(OutboxMessage msg)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await PublishMessage(msg);
                _unitOfWork.OutboxMessage.Remove(msg);
                await _unitOfWork.CompleteAsync();

                await _unitOfWork.CommitTransactionAsync();

                _logger.LogSuccessPush();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogFailedPush(e);
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
        }
        private async Task PublishMessage(OutboxMessage msg)
        {
            var deserializedMsg = msg.RecreateMessage();

            if (deserializedMsg is Microservices.Messages.Base.Message domainMsg)
            {
                await _messageInternalProducer.SendMessageAsync(domainMsg);
            }
            else
            {
                throw new InvalidOperationException($"Message type {deserializedMsg.GetType().Name} is not supported for publishing.");
            }
        }
    }    
}
