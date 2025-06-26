using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using IUnitOfWork = Microservices.Demo.Policies.Service.Domain.Policies.Interfaces.IUnitOfWork;

namespace Microservices.Demo.Policies.Service.Framework.Data
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
