using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Producer
{
    public class MessageProducerWorker: BackgroundService
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly IServiceScopeFactory _scopeFactory;
        
        public MessageProducerWorker(
            IServiceScopeFactory scopeFactory
        )
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (await _semaphore.WaitAsync(0, stoppingToken))
                {
                    try
                    {
                        using var scope = _scopeFactory.CreateScope();
                        var outbox = scope.ServiceProvider.GetRequiredService<MessageOutbox>();
                        await outbox.PushPendingMessagesAsync();
                    }
                    finally
                    {
                        _semaphore.Release();
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}
