using Confluent.Kafka;
using Confluent.Kafka.Extensions.Diagnostics;
using Microservices.Infrastructure.Kafka.Config;
using Microservices.Infrastructure.Kafka.Util;
using Microservices.Messages.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public abstract class MessageConsumerWorker : BackgroundService
    {
        private readonly IConsumer<Ignore, Message> _consumer;
        private readonly ILogger<MessageConsumerWorker> _logger;
        private readonly TopicManager _topicManager;
        //private readonly IMessageProcessor _processor;
        private readonly TopicConfig _topicConfig;
        private readonly string _bootstrapServers;
        private readonly IServiceScopeFactory _scopeFactory;

        public MessageConsumerWorker(
            ILogger<MessageConsumerWorker> logger,
            //IMessageProcessor processor,
            TopicConfig topicConfig,
            string bootstrapServers,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _topicConfig = topicConfig;
            _bootstrapServers = bootstrapServers;
            _scopeFactory = scopeFactory;
            _topicManager = new TopicManager(_bootstrapServers, _topicConfig.Topics.Select(t => t.Values.FirstOrDefault()).ToList());

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _bootstrapServers,
                GroupId = _topicConfig.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            _consumer = new ConsumerBuilder<Ignore, Message>(consumerConfig)
                        .SetValueDeserializer(new JsonMessageDeserializer())
                        .Build();

            //_processor = processor;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(async () =>
            {
                await _topicManager.EnsureTopicsExistsAsync();

                _consumer.Subscribe(_topicConfig.Topics.Select(t => t.Values.FirstOrDefault()).ToList());

                while (!stoppingToken.IsCancellationRequested)
                {
                    await ProcessKafkaMessageAsync(stoppingToken);
                }

                _consumer.Close();
            }, stoppingToken);
        }
        public async Task ProcessKafkaMessageAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _consumer.ConsumeWithInstrumentation(async (consumeResult, token) =>
                {
                    if (consumeResult == null)
                    {
                        _logger.LogWarning("Received null consume result.");
                        return;
                    }

                    var message = consumeResult.Message?.Value;
                    if (message == null)
                    {
                        _logger.LogWarning("Message value is null.");
                        return;
                    }

                    bool processedOk = false;
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var _processor = scope.ServiceProvider.GetRequiredService<IMessageProcessor>();
                        try
                        {
                            switch (message)
                            {
                                case Command commandMessage:
                                    await _processor.ProcessCommand(commandMessage);
                                    _logger.LogInformation("Processed Command: {Message}", commandMessage);
                                    break;

                                case Event eventMessage:
                                    await _processor.ProcessEvent(eventMessage);
                                    _logger.LogInformation("Processed Event: {Message}", eventMessage);
                                    break;

                                default:
                                    _logger.LogWarning("Received unsupported message type: {MessageType}", message.GetType());
                                    break;
                            }

                            _logger.LogInformation("Received message: {Message}", message);
                            processedOk = true;
                        }
                        catch (HandlerNotRegisteredException ex)
                        {
                            _logger.LogError(ex, "Handler not registered for message type: {MessageType}", message.GetType());
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error processing Kafka message: {Error}", ex.Message);
                        }

                        _consumer.Commit(consumeResult);

                        //if (processedOk)
                        //{
                        //    _consumer.Commit(consumeResult);
                        //}                        
                    }
                }, stoppingToken);
            }            
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Kafka message consumption was canceled.");
            }
            catch (ConsumeException e)
            {
                _logger.LogError(e, "Kafka consume error: {Reason}", e.Error.Reason);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error processing Kafka message: {Error}", ex.Message);
            }
        }

        //public async Task ProcessKafkaMessageAsyncII(CancellationToken stoppingToken)
        //{
        //    try
        //    {
        //        var consumeResult = _consumer.Consume(stoppingToken);
        //        if (consumeResult != null)
        //        {
        //            var message = consumeResult.Message.Value;
                    
        //            switch (message)
        //            {
        //                case Command commandMessage:
        //                    await _processor.ProcessCommand(commandMessage);
        //                    _logger.LogInformation("Processed Command: {0}", commandMessage);
        //                    break;
        //                case Event eventMessage:
        //                    await _processor.ProcessEvent(eventMessage);
        //                    _logger.LogInformation("Processed Event: {0}", eventMessage);
        //                    break;
        //                default:
        //                    _logger.LogWarning("Received unsupported message type: {0}", message.GetType());
        //                    break;
        //            }

        //            _logger.LogInformation("Received message: {0}", message);
        //        }
        //    }
        //    catch (OperationCanceledException)
        //    {
        //        _logger.LogInformation("Consumption was canceled by the stopping token.");
        //    }
        //    catch (ConsumeException e)
        //    {
        //        _logger.LogError($"Kafka consume error: {e.Error.Reason}");
        //       // throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Unexpected error processing Kafka message: {ex.Message}");
        //        //throw;
        //    }
        //}
    }
}
