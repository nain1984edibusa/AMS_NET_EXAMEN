using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Framework.Data
{
    public static class SeederExtensions
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IReadModelUnitOfWork>();

            await DbSeeder.SeedAsync(uow);
        }
    }
}
