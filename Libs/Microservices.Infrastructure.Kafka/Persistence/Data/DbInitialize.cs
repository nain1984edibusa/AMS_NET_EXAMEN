using Microservices.Infrastructure.Kafka.Persistence.Interfaces;

namespace Microservices.Infrastructure.Kafka.Persistence.Data
{
    public static class DbInitialize
    {
        public static async Task InitializeAsync(IMessagingUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();
        }
    }
}
