using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;

namespace Microservices.Demo.Pricing.Service.Framework.Data
{
    public static class SeederExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await DbSeeder.SeedAsync(uow);
        }
    }
}
