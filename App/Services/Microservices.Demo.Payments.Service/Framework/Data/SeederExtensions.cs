using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.Data
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
